using System.Collections.Generic;
using Godot;

namespace InteractionSystem;

[Tool]
public partial class Interactable2D : Interactable
{
	[Export]
	public Area2D Area
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

	protected Area2D _area;

	public override void _Ready()
	{
		if (Engine.IsEditorHint()) return;

		Area.SetMeta("interactable", GetPath());
	}

	public override string[] _GetConfigurationWarnings()
	{
		List<string> warnings = new();

		if (_area == null)
		{
			var warning = "This node does not have the ability to be interacted with. " +
				"Please add an Area2D to this node.";
			warnings.Add(warning);
		}

		warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

		return warnings.ToArray();
	}
}
