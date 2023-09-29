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
		get { return RayCast; }
		set
		{
			if (value == RayCast) return;

			UpdateConfigurationWarnings();
		}
	}

	[Export]
	public Area3D Area
	{
		get { return Area; }
		set
		{
			if (value == Area) return;

			UpdateConfigurationWarnings();
		}
	}

	public override string[] _GetConfigurationWarnings()
	{
		string[] warnings = base._GetConfigurationWarnings();

		if (RayCast == null && Area == null)
		{
			var warning = "This node does not have the ability to interact with the world. " +
				"Please add a RayCast3D or Area3D to this node.";
			_ = warnings.Append(warning).ToArray();
		}

		return warnings;
	}

	protected void Interact(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}

	void IInteractor.Interact(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}

	void IInteractor.Focus(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}

	void IInteractor.Unfocus(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}

	void IInteractor.Closest(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}

	void IInteractor.NotClosest(IInteractable interactable)
	{
		throw new System.NotImplementedException();
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
		throw new System.NotImplementedException();
	}
}
