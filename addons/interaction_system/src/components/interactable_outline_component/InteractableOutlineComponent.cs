using System.Collections.Generic;
using Godot;

namespace InteractionSystem;

[Tool]
public partial class InteractableOutlineComponent : Node
{
    [Export] public bool Enabled { get; set; } = true;
    [Export]
    public Node Outline
    {
        get => _outline;
        set
        {
            if (value != _outline)
            {
                _outline = value;
                UpdateConfigurationWarnings();
            }
        }
    }
    [Export]
    public Interactable Prop
    {
        get => _prop;
        set
        {
            if (value != _prop)
            {
                _prop = value;
                UpdateConfigurationWarnings();
            }
        }
    }

    [ExportGroup("Outline On")]
    [Export] public bool OutlineOnFocus { get; set; } = true;
    [Export] public bool OutlineOnClosest { get; set; } = true;

#nullable disable
    private Interactable _prop;
    private Node _outline;
    private MeshInstance2D _outline2D;
    private MeshInstance3D _outline3D;
#nullable restore

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            return;
        }

        Prop.Focused += OnFocus;
        Prop.Unfocused += OnFocusLost;
        Prop.Closest += OnClosest;
        Prop.NotClosest += OnNotClosest;

        InitializeOutline();

        HideOutline();
    }

    public override string[] _GetConfigurationWarnings()
    {
        List<string> warnings = new();

        if (Outline is null)
        {
            warnings.Add("Outline is null");
        }
        else if (Outline is not MeshInstance2D and not MeshInstance3D)
        {
            warnings.Add("Outline is not a MeshInstance2D or MeshInstance3D");
        }

        if (Prop is null)
        {
            warnings.Add("Prop is null");
        }
        else if (Prop is not Interactable)
        {
            warnings.Add("Prop is not an Interactable");
        }

        return warnings.ToArray();
    }

    private void InitializeOutline()
    {
        if (Outline is MeshInstance2D)
        {
            _outline2D = Outline as MeshInstance2D;
        }
        else if (Outline is MeshInstance3D)
        {
            _outline3D = Outline as MeshInstance3D;
        }
    }

    private void ShowOutline()
    {
        _outline2D?.Show();
        _outline3D?.Show();
    }

    private void HideOutline()
    {
        _outline2D?.Hide();
        _outline3D?.Hide();
    }

    private void OnFocus(Interactor interactor)
    {
        if (OutlineOnFocus)
        {
            ShowOutline();
        }
    }

    private void OnFocusLost(Interactor interactor)
    {
        if (OutlineOnFocus)
        {
            HideOutline();
        }
    }

    private void OnClosest(Interactor interactor)
    {
        if (OutlineOnClosest)
        {
            ShowOutline();
        }
    }

    private void OnNotClosest(Interactor interactor)
    {
        if (OutlineOnClosest)
        {
            HideOutline();
        }
    }
}
