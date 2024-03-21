using System.Collections.Generic;
using Godot;

namespace InteractionSystem;

[Tool]
public partial class Interactor3D : Interactor
{
	[Export]
	public RayCast3D RayCast
	{
		get => _rayCast;
		set
		{
			if (value != _rayCast)
			{
				_rayCast = value;
				UpdateConfigurationWarnings();
			}
		}
	}

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
	protected RayCast3D _rayCast;

	public override string[] _GetConfigurationWarnings()
	{
		List<string> warnings = new();

		if (_rayCast is null && _area is null)
		{
			var warning = "This node does not have the ability to interact with the world. " +
				"Please add a RayCast3D or Area3D to this node.";
			warnings.Add(warning);
		}

		warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

		return warnings.ToArray();
	}

	public Interactable GetRayCastedInteractable()
	{
		var collider = (Area3D)RayCast?.GetCollider();
		var path = collider?.GetMeta("interactable", new NodePath()).As<NodePath>();

		return GetInteractableFromPath(path);
	}

	public Interactable3D GetClosestInteractable()
	{
		var list = Area.GetOverlappingAreas();
		float distance;
		float closestDistance = float.MaxValue;
		Interactable3D closestInteractable = null;

		foreach (Area3D body in list)
		{
			var meta = body.GetMeta("interactable", new Node()).As<NodePath>();
			var interactable = GetInteractableFromPath(meta);

			if (interactable is not Interactable3D) continue;

			distance = body.GlobalPosition.DistanceTo(Area.GlobalPosition);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestInteractable = (Interactable3D)interactable;
			}
		}

		return closestInteractable;
	}
}
