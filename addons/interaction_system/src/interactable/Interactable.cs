using System;
using System.Collections.Generic;
using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem;

public partial class Interactable : Node
{
    [Signal] public delegate void InteractedEventHandler(Interactor interactor);
    [Signal] public delegate void LongInteractedEventHandler(Interactor interactor);
    [Signal] public delegate void ClosestEventHandler(Interactor interactor);
    [Signal] public delegate void NotClosestEventHandler(Interactor interactor);
    [Signal] public delegate void FocusedEventHandler(Interactor interactor);
    [Signal] public delegate void UnfocusedEventHandler(Interactor interactor);

    protected IArea? Area { get; set; }

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            return;
        }

        Area?.SetMeta("interactable", GetPath());
    }

    public override string[] _GetConfigurationWarnings()
    {
        List<string> warnings = new();

        if (Area is null)
        {
            const string warning = "This node does not have the ability to be interacted with. " +
                "Please add an Area2D/3D to this node.";
            warnings.Add(warning);
        }

        warnings.AddRange(base._GetConfigurationWarnings() ?? Array.Empty<string>());

        return warnings.ToArray();
    }
}
