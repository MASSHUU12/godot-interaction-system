using Godot;

public partial interface IInteractor
{
	[Signal]
	public delegate void InteractedWithInteractableEventHandler(IInteractable interactable);
	[Signal]
	public delegate void ClosestToInteractableEventHandler(IInteractable interactable);
	[Signal]
	public delegate void NotClosestToInteractableEventHandler(IInteractable interactable);
	[Signal]
	public delegate void FocusedOnInteractableEventHandler(IInteractable interactable);
	[Signal]
	public delegate void UnfocusedInteractableEventHandler(IInteractable interactable);

	protected virtual void Interact(IInteractable interactable) { }
	protected virtual void Focus(IInteractable interactable) { }
	protected virtual void Unfocus(IInteractable interactable) { }
	protected virtual void Closest(IInteractable interactable) { }
	protected virtual void NotClosest(IInteractable interactable) { }

	protected virtual IInteractable GetClosestInteractable() { return null; }
	protected virtual IInteractable GetRaycastedInteractable() { return null; }
}
