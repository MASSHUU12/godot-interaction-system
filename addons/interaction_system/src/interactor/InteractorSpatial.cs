using System.Collections.Generic;
using System.Linq;
using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem;

public abstract partial class InteractorSpatial : Interactor
{
    protected IRayCast? RayCast { get; set; }
    protected IArea? Area { get; set; }

    public override string[] _GetConfigurationWarnings()
    {
        List<string> warnings = new();

        if (RayCast is null && Area is null)
        {
            const string warning = "This node does not have the ability to interact with the world. " +
                "Please add a RayCast or Area to this node.";
            warnings.Add(warning);
        }

        warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

        return warnings.ToArray();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Engine.IsEditorHint())
        {
            return;
        }

        CheckRayCast();
        CheckArea();
    }

    protected Interactable? GetRayCastedInteractable()
    {
        Node? collider = RayCast?.GetCollider();

        return collider is Area2D or Area3D
            ? GetInteractableFromPath(
                collider.GetMeta("interactable").As<NodePath>()
            )
            : null;
    }

    protected void CheckRayCast()
    {
        if (RayCast is null)
        {
            return;
        }

        Interactable? newRayCasted = GetRayCastedInteractable();

        if (newRayCasted == CachedRayCasted)
        {
            return;
        }

        if (IsInstanceValid(CachedRayCasted))
        {
            Unfocus(CachedRayCasted!);
        }

        if (IsInstanceValid(newRayCasted))
        {
            Focus(newRayCasted!);
        }

        CachedRayCasted = newRayCasted;
    }

    protected void CheckArea()
    {
        if (Area is null)
        {
            return;
        }

        Interactable? newClosest = GetClosestInteractable();

        if (newClosest == CachedClosest)
        {
            return;
        }

        if (IsInstanceValid(CachedClosest))
        {
            NotClosest(CachedClosest!);
        }

        if (IsInstanceValid(newClosest))
        {
            Closest(newClosest!);
        }

        CachedClosest = newClosest;
    }

    public Interactable? GetClosestInteractable()
    {
        if (Area is null)
        {
            return null;
        }

        IEnumerable<IArea> overlappingAreas = Area.GetOverlappingAreas();

        if (!overlappingAreas.Any())
        {
            return null;
        }

        Interactable? closestInteractable = null;
        float closestDistance = float.MaxValue;

        foreach (IArea body in overlappingAreas)
        {
            NodePath meta = body.GetMeta("interactable").As<NodePath>();

            float distance = body.GlobalPosition.DistanceTo(Area.GlobalPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestInteractable = GetInteractableFromPath(meta);
            }
        }

        return closestInteractable;
    }
}
