using System.Collections.Generic;
using Godot;

[Tool]
public partial class InteractableProp3D : Interactable3D
{
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
	[Export] public bool HighlighterEnabled { get; set; } = false;
	[Export] public EHighlightMoment HighlightMoment { get; set; } = EHighlightMoment.Always;

	public enum EHighlightMoment
	{
		Always,
		Closest
	}

	private MeshInstance3D _mesh;
	private MeshInstance3D _outlineMesh;

	public override void _Ready()
	{
		base._Ready();

		Interacted += OnInteractedProp;
		Closest += OnClosestProp;
		NotClosest += OnNotClosestProp;
		Focused += OnFocusedProp;
		Unfocused += OnUnfocusedProp;

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

		warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

		return warnings.ToArray();
	}

	private void OnInteractedProp(Interactor3D interactor)
	{
	}

	private void OnClosestProp(Interactor3D interactor)
	{
	}

	private void OnNotClosestProp(Interactor3D interactor)
	{
	}

	private void OnFocusedProp(Interactor3D interactor)
	{
		ShowOutline();
	}

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
}
