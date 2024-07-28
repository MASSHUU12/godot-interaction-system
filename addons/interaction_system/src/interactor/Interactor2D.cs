#if TOOLS
using System.Collections.Generic;
using Godot;
using Godot.Collections;
using InteractionSystem.Classes;

namespace InteractionSystem;

[Tool]
public partial class Interactor2D : InteractorSpatial
{
    [Export]
    public RayCast2D? RayCast2D
    {
        get => ((RayCast2DAdapter?)RayCast)?.RayCast;
        set
        {
            if (value != ((RayCast2DAdapter?)RayCast)?.RayCast && value is not null)
            {
                RayCast = new RayCast2DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
    }

    [Export]
    public Area2D? Area2D
    {
        get => ((Area2DAdapter?)Area)?.Area;
        set
        {
            if (value != ((Area2DAdapter?)Area)?.Area && value is not null)
            {
                Area = new Area2DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
    }

    public override string[] _GetConfigurationWarnings()
    {
        List<string> warnings = new();

        if (RayCast is null && Area is null)
        {
            const string warning = "This node does not have the ability to interact with the world. " +
                "Please add a RayCast2D or Area2D to this node.";
            warnings.Add(warning);
        }

        warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

        return warnings.ToArray();
    }

    public Interactable2D? GetClosestInteractable()
    {
        if (Area2D is null)
        {
            return null;
        }

        Array<Area2D> list = Area2D.GetOverlappingAreas();
        float distance;
        float closestDistance = float.MaxValue;
        Interactable2D? closestInteractable = null;

        if (list.Count == 0)
        {
            return null;
        }

        foreach (Area2D body in list)
        {
            NodePath meta = body.GetMeta("interactable").As<NodePath>();
            Interactable? interactable = GetInteractableFromPath(meta);

            if (interactable is not Interactable2D)
            {
                continue;
            }

            distance = body.GlobalPosition.DistanceTo(Area2D.GlobalPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestInteractable = (Interactable2D)interactable;
            }
        }

        return closestInteractable;
    }
}
#endif
