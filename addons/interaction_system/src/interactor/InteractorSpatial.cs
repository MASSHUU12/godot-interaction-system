using System;
using System.Collections.Generic;
using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem;

public abstract partial class InteractorSpatial : Interactor
{
    protected IRayCast? RayCast { get; set; }
    protected IArea? Area { get; set; }

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

    public override string[] _GetConfigurationWarnings()
    {
        List<string> warnings = new();

        if (RayCast is null && Area is null)
        {
            const string warning = "This node does not have the ability to interact with the world. " +
                "Please add a RayCast or Area to this node.";
            warnings.Add(warning);
        }

        warnings.AddRange(base._GetConfigurationWarnings() ?? Array.Empty<string>());

        return warnings.ToArray();
    }
}
