using System.Collections.Generic;
using Godot;

[Tool]
public partial class InteractableProp3D : Interactable3D
{
	/// <summary>
	/// Gets or sets a value indicating whether the outline effect is enabled
	/// for this interactable prop.
	/// </summary>
	[ExportSubgroup("Outline")]
	[Export] public bool OutlineEnabled { get; set; } = true;
	/// <summary>
	/// The mesh used to display an outline around the interactable object.
	/// </summary>
	[Export]
	public MeshInstance3D OutlineMesh
	{
		get => _outlineMesh;
		set
		{
			if (value != _outlineMesh)
			{
				_outlineMesh = value;
				UpdateConfigurationWarnings();
			}
		}
	}

	[ExportSubgroup("Highlighter")]
	/// <summary>
	/// The 3D mesh instance of the interactable prop.
	/// Used to display highlighter.
	/// </summary>
	[Export]
	public MeshInstance3D Mesh
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
	/// <summary>
	/// Gets or sets a value indicating whether the highlighter is enabled
	/// for this interactable prop in the 3D world.
	/// </summary>
	[Export] public bool HighlighterEnabled { get; set; } = false;
	/// <summary>
	/// Determines when the interactable prop should be highlighted.
	/// </summary>
	[Export] public EHighlightMoment HighlightMoment { get; set; } = EHighlightMoment.Always;

	public enum EHighlightMoment
	{
		Always,
		Closest
	}

	private MeshInstance3D _mesh;
	private MeshInstance3D _outlineMesh;
	private ShaderMaterial _highlighterMaterial;

	public override void _Ready()
	{
		base._Ready();

		_highlighterMaterial = (ShaderMaterial)GD.Load<ShaderMaterial>(
			"res://addons/interaction_system/assets/shaders/item_highlighter.tres"
		).Duplicate();

		Closest += OnClosestProp;
		NotClosest += OnNotClosestProp;
		Focused += OnFocusedProp;
		Unfocused += OnUnfocusedProp;

		if (HighlightMoment == EHighlightMoment.Always) ShowHighlighter();

		HideOutline();
	}

	public override string[] _GetConfigurationWarnings()
	{
		List<string> warnings = new();

		if (_outlineMesh == null)
		{
			var warning = "This node does not have the ability to display an outline. " +
				"Please add a MeshInstance3D to this node.";
			warnings.Add(warning);
		}

		if (_mesh == null)
		{
			var warning = "This node does not have a mesh. " +
				"Please add a MeshInstance3D to this node.";
			warnings.Add(warning);
		}

		warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

		return warnings.ToArray();
	}

	/// <summary>
	/// Called when an interactor is closest to this interactable prop.
	/// If HighlightMoment is set to EHighlightMoment.Closest, the highlighter will be shown.
	/// </summary>
	/// <param name="interactor">The interactor that is closest to this interactable prop.</param>
	private void OnClosestProp(Interactor3D interactor)
	{
		if (HighlightMoment == EHighlightMoment.Closest) ShowHighlighter();
	}

	/// <summary>
	/// Called when this interactable is no longer the closest one to the given interactor.
	/// If the highlight moment is set to "Closest", the highlighter will be hidden.
	/// </summary>
	/// <param name="interactor">The interactor that is no longer interacting with this interactable.</param>
	private void OnNotClosestProp(Interactor3D interactor)
	{
		if (HighlightMoment == EHighlightMoment.Closest) HideHighlighter();
	}

	/// <summary>
	/// Called when an Interactor3D focuses on this InteractableProp3D.
	/// Shows the outline of the prop.
	/// </summary>
	/// <param name="interactor">The Interactor3D that is focusing on this InteractableProp3D.</param>
	private void OnFocusedProp(Interactor3D interactor)
	{
		ShowOutline();
	}

	/// <summary>
	/// Called when an interactor stops focusing on this interactable prop.
	/// Hides the outline of the prop.
	/// </summary>
	/// <param name="interactor">The interactor that stopped focusing on the prop.</param>
	private void OnUnfocusedProp(Interactor3D interactor)
	{
		HideOutline();
	}

	/// <summary>
	/// Shows the outline mesh if outline is enabled.
	/// </summary>
	private void ShowOutline()
	{
		if (OutlineEnabled) _outlineMesh.Show();
	}

	/// <summary>
	/// Hides the outline mesh if outline is enabled.
	/// </summary>
	private void HideOutline()
	{
		if (OutlineEnabled) _outlineMesh.Hide();
	}

	/// <summary>
	/// Shows the highlighter for the interactable prop if it is enabled.
	/// </summary>
	private void ShowHighlighter()
	{
		if (HighlighterEnabled) _mesh.MaterialOverlay = _highlighterMaterial;
	}

	/// <summary>
	/// Hides the highlighter by removing the material override from the mesh.
	/// </summary>
	private void HideHighlighter()
	{
		if (HighlighterEnabled) _mesh.MaterialOverlay = null;
	}
}
