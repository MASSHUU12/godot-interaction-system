using System.Collections.Generic;
using Godot;
using InteractionSystem.Enums;

namespace InteractionSystem;

[Tool]
public partial class InteractableHighlighterComponent : Node
{
    [Export] public bool Enabled { get; set; } = true;

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
    [Export]
    public Node Mesh
    {
        get => _mesh;
        set
        {
            if (value != _mesh)
            {
                _mesh = value;
                UpdateConfigurationWarnings();
            }
        }
    }
    [Export]
    public ShaderMaterial Shader
    {
        get => _shader;
        set
        {
            if (value != _shader)
            {
                _shader = value;
                UpdateConfigurationWarnings();
            }
        }
    }
    [Export] public EHighlightOn HighlightOn { get; set; } = EHighlightOn.Always;

#nullable disable
    private Node _mesh;
    private ShaderMaterial _shader;
    private Interactable _prop;
    private MeshInstance2D _mesh2D;
    private MeshInstance3D _mesh3D;
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

        InitializeMesh();
    }

    public override void _Process(double delta)
    {
        if (Engine.IsEditorHint())
        {
            return;
        }

        if (!Enabled)
        {
            HideHighlighter();
            return;
        }
        if (HighlightOn == EHighlightOn.Always)
        {
            ShowHighlighter();
        }
    }

    public override string[] _GetConfigurationWarnings()
    {
        List<string> warnings = new();

        if (Mesh is null)
        {
            warnings.Add("Mesh is null");
        }
        else if (Mesh is not MeshInstance2D and not MeshInstance3D)
        {
            warnings.Add("Mesh is not a MeshInstance2D or MeshInstance3D");
        }

        if (Shader is null)
        {
            warnings.Add("Shader is null");
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

    private void InitializeMesh()
    {
        if (Mesh is MeshInstance2D)
        {
            _mesh2D = Mesh as MeshInstance2D;
        }
        else if (Mesh is MeshInstance3D)
        {
            _mesh3D = Mesh as MeshInstance3D;
        }
    }

    private void ShowHighlighter()
    {
        if (!Enabled)
        {
            return;
        }

        if (_mesh2D is not null && _mesh2D.Material is null)
        {
            _mesh2D.Material = Shader;
        }
        else if (_mesh3D is not null && _mesh3D.MaterialOverlay is null)
        {
            _mesh3D.MaterialOverlay = Shader;
        }
    }

    private void HideHighlighter()
    {
        if (_mesh2D is not null)
        {
            _mesh2D.Material = null;
        }
        else if (_mesh3D is not null)
        {
            _mesh3D.MaterialOverlay = null;
        }
    }

    private void OnFocus(Interactor prop)
    {
        if (HighlightOn == EHighlightOn.Focus)
        {
            ShowHighlighter();
        }
    }

    private void OnFocusLost(Interactor prop)
    {
        if (HighlightOn == EHighlightOn.Focus)
        {
            HideHighlighter();
        }
    }

    private void OnClosest(Interactor prop)
    {
        if (HighlightOn == EHighlightOn.Closest)
        {
            ShowHighlighter();
        }
    }

    private void OnNotClosest(Interactor prop)
    {
        if (HighlightOn == EHighlightOn.Closest)
        {
            HideHighlighter();
        }
    }
}
