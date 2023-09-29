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
