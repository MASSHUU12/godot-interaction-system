#if TOOLS
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
            if (value != ((RayCast2DAdapter?)RayCast)?.RayCast)
            {
                RayCast = value is null ? null : new RayCast2DAdapter(ref value);
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
            if (value != ((Area2DAdapter?)Area)?.Area)
            {
                Area = value is null ? null : new Area2DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
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
