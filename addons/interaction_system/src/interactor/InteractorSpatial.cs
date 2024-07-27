using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem;

public abstract partial class InteractorSpatial : Interactor
{
    protected IRayCast? RayCast { get; set; }

    protected Interactable? GetRayCastedInteractable()
    {
        Node? collider = RayCast?.GetCollider();
        NodePath? path = null;

        if (collider is Area2D area2D)
        {
            path = area2D.GetMeta("interactable").As<NodePath>();
        }
        else if (collider is Area3D area3D)
        {
            path = area3D.GetMeta("interactable").As<NodePath>();
        }

        return path is not null ? GetInteractableFromPath(path) : null;
    }
}
