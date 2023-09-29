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

	private Area2D _area = null;
	private RayCast2D _rayCast = null;

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

	void IInteractor.Closest(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}

	void IInteractor.Focus(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}

	IInteractable IInteractor.GetClosestInteractable()
	{
		throw new System.NotImplementedException();
	}

	IInteractable IInteractor.GetRaycastedInteractable()
	{
		throw new System.NotImplementedException();
	}

	void IInteractor.Interact(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}

	void IInteractor.NotClosest(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}

	void IInteractor.Unfocus(IInteractable interactable)
	{
		throw new System.NotImplementedException();
	}
}
