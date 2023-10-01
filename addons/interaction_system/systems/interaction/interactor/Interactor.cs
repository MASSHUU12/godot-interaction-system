using System;
using Godot;

public partial interface IInteractor
{
	/// <summary>
	/// Delegate for the InteractedWithInteractable event.
	/// </summary>
	/// <param name="interactable">The interactable object that was interacted with.</param>
	[Signal]
	public delegate void InteractedWithInteractableEventHandler(IInteractable interactable);
	/// <summary>
	/// A delegate representing the event that is triggered when
	/// an interactor is closest to an interactable object.
	/// </summary>
	/// <param name="interactable">The interactable object that the interactor is closest to.</param>
	[Signal]
	public delegate void ClosestToInteractableEventHandler(IInteractable interactable);
	/// <summary>
	/// A delegate representing the event that is triggered
	/// when the interactor is not the closest to an interactable object.
	/// </summary>
	/// <param name="interactable">The interactable object that the interactor is not the closest to.</param>
	[Signal]
	public delegate void NotClosestToInteractableEventHandler(IInteractable interactable);
	/// <summary>
	/// Delegate for the FocusedOnInteractable event.
	/// </summary>
	/// <param name="interactable">The interactable object that the interactor is focused on.</param>
	[Signal]
	public delegate void FocusedOnInteractableEventHandler(IInteractable interactable);
	/// <summary>
	/// A delegate representing the event that is triggered
	/// when an interactable object is no longer in focus by the interactor.
	/// </summary>
	/// <param name="interactable">The interactable object that is no longer in focus.</param>
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
	/// <summary>
	/// Returns the interactable object that is currently being raycasted by the interactor.
	/// </summary>
	/// <returns>The interactable object that is currently being raycasted by the interactor,
	/// or null if no interactable object is found.</returns>
	protected IInteractable GetRayCastedInteractable();
}

static partial class Interactor
{
	public static void Interact(Interactable3D interactable, Interactor3D interactor)
	{
		interactable.EmitSignal(nameof(interactable.Interacted), interactor);
		interactor.EmitSignal(nameof(interactor.InteractedWithInteractable), interactable);
	}

	public static void Interact(Interactable2D interactable, Interactor2D interactor)
	{
		interactable.EmitSignal(nameof(interactable.Interacted), interactor);
		interactor.EmitSignal(nameof(interactor.InteractedWithInteractable), interactable);
	}

	public static void Focus(Interactable3D interactable, Interactor3D interactor)
	{
		interactable.EmitSignal(nameof(interactable.Focused), interactor);
		interactor.EmitSignal(nameof(interactor.FocusedOnInteractable), interactable);
	}

	public static void Focus(Interactable2D interactable, Interactor2D interactor)
	{
		interactable.EmitSignal(nameof(interactable.Focused), interactor);
		interactor.EmitSignal(nameof(interactor.FocusedOnInteractable), interactable);
	}

	public static void Unfocus(Interactable3D interactable, Interactor3D interactor)
	{
		interactable.EmitSignal(nameof(interactable.Unfocused), interactor);
		interactor.EmitSignal(nameof(interactor.UnfocusedInteractable), interactable);
	}

	public static void Unfocus(Interactable2D interactable, Interactor2D interactor)
	{
		interactable.EmitSignal(nameof(interactable.Unfocused), interactor);
		interactor.EmitSignal(nameof(interactor.UnfocusedInteractable), interactable);
	}

	public static void Closest(Interactable3D interactable, Interactor3D interactor)
	{
		interactable.EmitSignal(nameof(interactable.Closest), interactor);
		interactor.EmitSignal(nameof(interactor.ClosestToInteractable), interactable);
	}

	public static void Closest(Interactable2D interactable, Interactor2D interactor)
	{
		interactable.EmitSignal(nameof(interactable.Closest), interactor);
		interactor.EmitSignal(nameof(interactor.ClosestToInteractable), interactable);
	}

	public static void NotClosest(Interactable3D interactable, Interactor3D interactor)
	{
		interactable.EmitSignal(nameof(interactable.NotClosest), interactor);
		interactor.EmitSignal(nameof(interactor.NotClosestToInteractable), interactable);
	}

	public static void NotClosest(Interactable2D interactable, Interactor2D interactor)
	{
		interactable.EmitSignal(nameof(interactable.NotClosest), interactor);
		interactor.EmitSignal(nameof(interactor.NotClosestToInteractable), interactable);
	}

	public static IInteractable GetRayCastedInteractable(
		RayCast3D rayCast3D = null, RayCast2D rayCast2D = null
	)
	{
		return (IInteractable)(rayCast3D.GetCollider() ?? rayCast2D.GetCollider()) ?? null;
	}
}
