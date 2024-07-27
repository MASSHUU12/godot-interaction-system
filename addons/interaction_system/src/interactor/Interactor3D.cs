#if TOOLS
using System.Collections.Generic;
using Godot;
using Godot.Collections;
using InteractionSystem.Classes;

namespace InteractionSystem;

[Tool]
public partial class Interactor3D : Interactor
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
        get => _area;
        set
        {
            if (value != _area)
            {
                _area = value;
                UpdateConfigurationWarnings();
            }
        }
    }

    protected Area3D? _area;

    public override string[] _GetConfigurationWarnings()
    {
        List<string> warnings = new();

        if (RayCast is null && _area is null)
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
