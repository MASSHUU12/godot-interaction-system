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

	/// <summary>
	/// Interacts with the specified interactable.
	/// </summary>
	/// <param name="interactable">The interactable to interact with.</param>
	protected void Interact(IInteractable interactable);
	/// <summary>
	/// Focuses on the specified interactable object.
	/// </summary>
	/// <param name="interactable">The interactable object to focus on.</param>
	protected void Focus(IInteractable interactable);
	protected void Unfocus(IInteractable interactable);
	protected void Closest(IInteractable interactable);
	protected void NotClosest(IInteractable interactable);

	protected IInteractable GetClosestInteractable();
	protected IInteractable GetRaycastedInteractable();
}
