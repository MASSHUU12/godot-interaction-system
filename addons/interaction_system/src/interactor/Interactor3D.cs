#if TOOLS
using System.Collections.Generic;
using Godot;
using Godot.Collections;
using InteractionSystem.Classes;

namespace InteractionSystem;

[Tool]
public partial class Interactor3D : InteractorSpatial
{
    [Export]
    public RayCast3D? RayCast3D
    {
        get => ((RayCast3DAdapter?)RayCast)?.RayCast;
        set
        {
            if (value != ((RayCast3DAdapter?)RayCast)?.RayCast && value is not null)
            {
                RayCast = new RayCast3DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
    }

    [Export]
    public Area3D? Area3D
    {
        get => ((Area3DAdapter?)Area)?.Area;
        set
        {
            if (value != ((Area3DAdapter?)Area)?.Area && value is not null)
            {
                Area = new Area3DAdapter(ref value);
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
                "Please add a RayCast3D or Area3D to this node.";
            warnings.Add(warning);
        }

        warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

        return warnings.ToArray();
    }

    public Interactable3D? GetClosestInteractable()
    {
        if (Area3D is null)
        {
            return null;
        }

        Array<Area3D> list = Area3D.GetOverlappingAreas();
        float distance;
        float closestDistance = float.MaxValue;
        Interactable3D? closestInteractable = null;

        foreach (Area3D body in list)
        {
            NodePath meta = body.GetMeta("interactable").As<NodePath>();
            Interactable? interactable = GetInteractableFromPath(meta);

            if (interactable is not Interactable3D)
            {
                continue;
            }

            distance = body.GlobalPosition.DistanceTo(Area3D.GlobalPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestInteractable = (Interactable3D)interactable;
            }
        }

        return closestInteractable;
    }
}
#endif
