#if TOOLS
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
            if (value != ((RayCast3DAdapter?)RayCast)?.RayCast)
            {
                RayCast = value is null ? null : new RayCast3DAdapter(ref value);
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
            if (value != ((Area3DAdapter?)Area)?.Area)
            {
                Area = value is null ? null : new Area3DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
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
