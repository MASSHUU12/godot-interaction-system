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
	/// <summary>
	/// Unfocuses the specified interactable.
	/// </summary>
	/// <param name="interactable">The interactable to unfocus.</param>
	protected void Unfocus(IInteractable interactable);
	/// <summary>
	/// Finds the closest interactable object to the interactor and interacts with it.
	/// </summary>
	/// <param name="interactable">The closest interactable object to the interactor.</param>
	protected void Closest(IInteractable interactable);
	/// <summary>
	/// Called when the interactor is not the closest to an interactable object.
	/// </summary>
	/// <param name="interactable">The interactable object that is not the closest to the interactor.</param>
	protected void NotClosest(IInteractable interactable);

	/// <summary>
	/// Returns the closest interactable object within the interactor's range.
	/// </summary>
	/// <returns>The closest interactable object within range, or null if none are found.</returns>
	protected IInteractable GetClosestInteractable();
	protected IInteractable GetRaycastedInteractable();
}
