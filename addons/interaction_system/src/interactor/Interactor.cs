using Godot;

namespace InteractionSystem.Interactor
{
	public partial class Interactor : Node
	{
		[Signal]
		public delegate void InteractedWithInteractableEventHandler(Interactor interactable);
		[Signal]
		public delegate void ClosestToInteractableEventHandler(Interactor interactable);
		[Signal]
		public delegate void NotClosestToInteractableEventHandler(Interactor interactable);
		[Signal]
		public delegate void FocusedOnInteractableEventHandler(Interactor interactable);
		[Signal]
		public delegate void UnfocusedInteractableEventHandler(Interactor interactable);

		public bool IsFocused { get; private set; } = false;
		public Interactable.Interactable Focusing { get; private set; } = null;

		public bool IsClosest { get; private set; } = false;
		public Interactable.Interactable ClosestInteractable { get; private set; } = null;

		public void Interact(Interactable.Interactable interactable)
		{
			interactable.EmitSignal(nameof(interactable.Interacted), this);
			EmitSignal(SignalName.InteractedWithInteractable, interactable);
		}

		public void Focus(Interactable.Interactable interactable)
		{
			IsFocused = true;
			Focusing = interactable;

			interactable.EmitSignal(nameof(interactable.Focused), this);
			EmitSignal(SignalName.FocusedOnInteractable, interactable);
		}

		public void Unfocus(Interactable.Interactable interactable)
		{
			IsFocused = false;
			Focusing = null;

			interactable.EmitSignal(nameof(interactable.Unfocused), this);
			EmitSignal(SignalName.UnfocusedInteractable, interactable);
		}

		public void Closest(Interactable.Interactable interactable)
		{
			IsClosest = true;
			ClosestInteractable = interactable;

			interactable.EmitSignal(nameof(interactable.Closest), this);
			EmitSignal(SignalName.ClosestToInteractable, interactable);
		}

		public void NotClosest(Interactable.Interactable interactable)
		{
			IsClosest = false;
			ClosestInteractable = null;

			interactable.EmitSignal(nameof(interactable.NotClosest), this);
			EmitSignal(SignalName.NotClosestToInteractable, interactable);
		}

		protected Interactable.Interactable GetInteractableFromPath(NodePath path)
		{
			var node = GetNodeOrNull(path);
			if (node is not Interactable.Interactable interactable) return null;

			return interactable;
		}
	}
}
