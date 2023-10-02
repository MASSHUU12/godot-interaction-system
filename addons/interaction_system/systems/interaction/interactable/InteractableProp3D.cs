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

	public virtual void OnInteracted(Interactor3D interactor)
	{

	}

	public virtual void OnClosest(Interactor3D interactor)
	{

	}

	public virtual void OnNotClosest(Interactor3D interactor)
	{

	}

	public virtual void OnFocused(Interactor3D interactor)
	{

	}

	public virtual void OnUnFocused(Interactor3D interactor)
	{

	}
}
