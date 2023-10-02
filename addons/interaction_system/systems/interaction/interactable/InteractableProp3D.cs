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

	private MeshInstance3D _outlineMesh;

	public override void _Ready()
	{
		base._Ready();

		Interacted += OnInteractedProp;
		Closest += OnClosestProp;
		NotClosest += OnNotClosestProp;
		Focused += OnFocusedProp;
		Unfocused += OnUnfocusedProp;
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
		OnInteracted(interactor);
	}

	private void OnClosestProp(Interactor3D interactor)
	{
		OnClosest(interactor);
	}

	private void OnNotClosestProp(Interactor3D interactor)
	{
		OnNotClosest(interactor);
	}

	private void OnFocusedProp(Interactor3D interactor)
	{
		// Show the outline mesh when the object is focused.
		if (OutlineEnabled) _outlineMesh.Show();

		OnFocused(interactor);
	}

	private void OnUnfocusedProp(Interactor3D interactor)
	{
		// Hide the outline mesh when the object is unfocused.
		if (OutlineEnabled) _outlineMesh.Hide();

		OnUnfocused(interactor);
	}

	public virtual void OnInteracted(Interactor3D interactor) { }
	public virtual void OnClosest(Interactor3D interactor) { }
	public virtual void OnNotClosest(Interactor3D interactor) { }
	public virtual void OnFocused(Interactor3D interactor) { }
	public virtual void OnUnfocused(Interactor3D interactor) { }
}