using System.Collections.Generic;
using System.Linq;
using Godot;

[Tool]
public partial class Interactor2D : Node2D, IInteractor
{
	[Signal]
	public delegate void InteractedWithInteractableEventHandler(Interactable2D interactable);
	[Signal]
	public delegate void ClosestToInteractableEventHandler(Interactable2D interactable);
	[Signal]
	public delegate void NotClosestToInteractableEventHandler(Interactable2D interactable);
	[Signal]
	public delegate void FocusedOnInteractableEventHandler(Interactable2D interactable);
	[Signal]
	public delegate void UnfocusedInteractableEventHandler(Interactable2D interactable);

	[Export]
	public RayCast2D RayCast
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

	protected Area2D _area = null;
	protected RayCast2D _rayCast = null;

	public override string[] _GetConfigurationWarnings()
	{
		List<string> warnings = new();

		if (_rayCast == null && _area == null)
		{
			var warning = "This node does not have the ability to interact with the world. " +
				"Please add a RayCast2D or Area2D to this node.";
			warnings.Add(warning);
		}

		warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

		return warnings.ToArray();
	}

	public void Interact(IInteractable interactable)
	{
		var i = interactable as Interactable2D;

		i.EmitSignal(nameof(i.Interacted), this);
		EmitSignal(SignalName.InteractedWithInteractable, interactable as Interactable2D);
	}

	public void Focus(IInteractable interactable)
	{
		var i = interactable as Interactable2D;

		i.EmitSignal(nameof(i.Focused), this);
		EmitSignal(SignalName.FocusedOnInteractable, interactable as Interactable2D);
	}

	public void Unfocus(IInteractable interactable)
	{
		var i = interactable as Interactable2D;

		i.EmitSignal(nameof(i.Unfocused), this);
		EmitSignal(SignalName.UnfocusedInteractable, interactable as Interactable2D);
	}

	public void Closest(IInteractable interactable)
	{
		var i = interactable as Interactable2D;

		i.EmitSignal(nameof(i.Closest), this);
		EmitSignal(SignalName.ClosestToInteractable, interactable as Interactable2D);
	}

	public void NotClosest(IInteractable interactable)
	{
		var i = interactable as Interactable2D;

		i.EmitSignal(nameof(i.NotClosest), this);
		EmitSignal(SignalName.NotClosestToInteractable, interactable as Interactable2D);
	}

	public IInteractable GetClosestInteractable()
	{
		var list = Area.GetOverlappingBodies();
		float distance;
		float closestDistance = float.MaxValue;
		Interactable2D closestInteractable = null;

		foreach (var body in list)
		{
			if (body is not Interactable2D interactable) continue;

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
