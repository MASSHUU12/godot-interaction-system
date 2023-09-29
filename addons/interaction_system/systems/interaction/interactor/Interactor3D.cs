using System.Linq;
using Godot;

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
		string[] warnings = base._GetConfigurationWarnings();

		if (_rayCast == null && _area == null)
		{
			var warning = "This node does not have the ability to interact with the world. " +
				"Please add a RayCast3D or Area3D to this node.";
			_ = warnings.Append(warning).ToArray();
		}

		return warnings;
	}

	void IInteractor.Interact(IInteractable interactable)
	{
		EmitSignal(nameof(InteractedWithInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.InteractedWithInteractable, interactable as Interactable3D);
	}

	void IInteractor.Focus(IInteractable interactable)
	{
		EmitSignal(nameof(FocusedOnInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.FocusedOnInteractable, interactable as Interactable3D);
	}

	void IInteractor.Unfocus(IInteractable interactable)
	{
		EmitSignal(nameof(UnfocusedInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.UnfocusedInteractable, interactable as Interactable3D);
	}

	void IInteractor.Closest(IInteractable interactable)
	{
		EmitSignal(nameof(ClosestToInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.ClosestToInteractable, interactable as Interactable3D);
	}

	void IInteractor.NotClosest(IInteractable interactable)
	{
		EmitSignal(nameof(NotClosestToInteractableEventHandler), interactable as Interactable3D);
		EmitSignal(SignalName.NotClosestToInteractable, interactable as Interactable3D);
	}

	IInteractable IInteractor.GetClosestInteractable()
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

	IInteractable IInteractor.GetRaycastedInteractable()
	{
		var collider = RayCast.GetCollider();
		return collider != null ? collider as IInteractable : null;
	}
}
