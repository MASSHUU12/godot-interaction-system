using Godot;

namespace InteractionSystem;

public partial class Interactor : Node
{
	[Signal]
	public delegate void InteractedWithInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void LongInteractedWithInteractableStartedEventHandler(Interactor interactable);
	[Signal]
	public delegate void LongInteractedWithInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void LongInteractedWithInteractableCancelledEventHandler(Interactor interactable);
	[Signal]
	public delegate void ClosestToInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void NotClosestToInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void FocusedOnInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void UnfocusedInteractableEventHandler(Interactor interactable);

	[Export(PropertyHint.Range, "10,5000,1")]
	public int LongInteractionTime { get; set; } = 300;

	public bool IsFocused { get; private set; } = false;
	public Interactable Focusing { get; private set; } = null;

	public bool IsClosest { get; private set; } = false;
	public Interactable ClosestInteractable { get; private set; } = null;

	public void Interact(Interactable interactable)
	{
		interactable.EmitSignal(nameof(interactable.Interacted), this);
		EmitSignal(SignalName.InteractedWithInteractable, interactable);
	}

	public void LongInteract(Interactable interactable)
	{
		interactable.EmitSignal(nameof(interactable.LongInteracted), this);
		EmitSignal(SignalName.InteractedWithInteractable, interactable);
	}

	public void Focus(Interactable interactable)
	{
		IsFocused = true;
		Focusing = interactable;

		interactable.EmitSignal(nameof(interactable.Focused), this);
		EmitSignal(SignalName.FocusedOnInteractable, interactable);
	}

	public void Unfocus(Interactable interactable)
	{
		IsFocused = false;
		Focusing = null;

		interactable.EmitSignal(nameof(interactable.Unfocused), this);
		EmitSignal(SignalName.UnfocusedInteractable, interactable);
	}

	public void Closest(Interactable interactable)
	{
		IsClosest = true;
		ClosestInteractable = interactable;

		interactable.EmitSignal(nameof(interactable.Closest), this);
		EmitSignal(SignalName.ClosestToInteractable, interactable);
	}

	public void NotClosest(Interactable interactable)
	{
		IsClosest = false;
		ClosestInteractable = null;

		interactable.EmitSignal(nameof(interactable.NotClosest), this);
		EmitSignal(SignalName.NotClosestToInteractable, interactable);
	}

	protected Interactable GetInteractableFromPath(NodePath path)
	{
		var node = GetNodeOrNull(path);
		if (node is not Interactable interactable) return null;

		return interactable;
	}
}
