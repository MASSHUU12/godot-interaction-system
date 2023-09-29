using System.Collections.Generic;
using Godot;
using Godot.Collections;

[Tool]
public partial class Interactor3D : Node3D, IInteractor
{
	[Signal]
	public delegate void InteractedWithInteractableEventHandler(Interactable3D interactable);
	[Signal]
	public delegate void ClosestToInteractableEventHandler(Interactable3D interactable);
	[Signal]
	public delegate void NotClosestToInteractableEventHandler(Interactable3D interactable);
	[Signal]
	public delegate void FocusedOnInteractableEventHandler(Interactable3D interactable);
	[Signal]
	public delegate void UnfocusedInteractableEventHandler(Interactable3D interactable);

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

	protected Area3D _area = null;
	protected RayCast3D _rayCast = null;

	public override string[] _GetConfigurationWarnings()
	{
		List<string> warnings = new();

		if (_rayCast == null && _area == null)
		{
			var warning = "This node does not have the ability to interact with the world. " +
				"Please add a RayCast3D or Area3D to this node.";
			warnings.Add(warning);
		}

		warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

		return warnings.ToArray();
	}

	public void Interact(IInteractable interactable)
	{
		EmitSignal(nameof(InteractedWithInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.InteractedWithInteractable, interactable as Interactable3D);
	}

	public void Focus(IInteractable interactable)
	{
		EmitSignal(nameof(FocusedOnInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.FocusedOnInteractable, interactable as Interactable3D);
	}

	public void Unfocus(IInteractable interactable)
	{
		EmitSignal(nameof(UnfocusedInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.UnfocusedInteractable, interactable as Interactable3D);
	}

	public void Closest(IInteractable interactable)
	{
		EmitSignal(nameof(ClosestToInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.ClosestToInteractable, interactable as Interactable3D);
	}

	public void NotClosest(IInteractable interactable)
	{
		EmitSignal(nameof(NotClosestToInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.NotClosestToInteractable, interactable as Interactable3D);
	}

	public IInteractable GetClosestInteractable()
	{
		var list = Area.GetOverlappingBodies();
		float distance;
		float closestDistance = float.MaxValue;
		Interactable3D closestInteractable = null;

		foreach (var body in list)
		{
			if (body is not Interactable3D interactable) continue;

			distance = body.GlobalPosition.DistanceTo(GlobalPosition);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestInteractable = interactable;
			}
		}

		return closestInteractable;
	}

	public IInteractable GetRayCastedInteractable()
	{
		var collider = RayCast.GetCollider();
		return collider != null ? collider as IInteractable : null;
	}
}
