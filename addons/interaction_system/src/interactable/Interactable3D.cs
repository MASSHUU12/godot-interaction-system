using System.Collections.Generic;
using Godot;

namespace InteractionSystem;

[Tool]
public partial class Interactable3D : Interactable
{
	[Export]
	public Area3D Area
	{
		get => _area;
		set
		{
			if (value != _area)
			{
				_area = value;
				UpdateConfigurationWarnings();
			}
		}
	}

	protected Area3D _area;

	public override void _Ready()
	{
		if (Engine.IsEditorHint()) return;

		Area.SetMeta("interactable", GetPath());
	}

	public override string[] _GetConfigurationWarnings()
	{
		List<string> warnings = new();

		if (_area is null)
		{
			var warning = "This node does not have the ability to be interacted with. " +
				"Please add an Area3D to this node.";
			warnings.Add(warning);
		}

		warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

		return warnings.ToArray();
	}
}
