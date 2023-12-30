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

		public static void Interact(Interactable.Interactable interactable, Interactor interactor)
		{
			interactable.EmitSignal(nameof(interactable.Interacted), interactor);
			interactor.EmitSignal(nameof(interactor.InteractedWithInteractable), interactable);
		}

		public static void Focus(Interactable.Interactable interactable, Interactor interactor)
		{
			interactable.EmitSignal(nameof(interactable.Focused), interactor);
			interactor.EmitSignal(nameof(interactor.FocusedOnInteractable), interactable);
		}

		public static void Unfocus(Interactable.Interactable interactable, Interactor interactor)
		{
			interactable.EmitSignal(nameof(interactable.Unfocused), interactor);
			interactor.EmitSignal(nameof(interactor.UnfocusedInteractable), interactable);
		}

		public static void Closest(Interactable.Interactable interactable, Interactor interactor)
		{
			interactable.EmitSignal(nameof(interactable.Closest), interactor);
			interactor.EmitSignal(nameof(interactor.ClosestToInteractable), interactable);
		}

		public static void NotClosest(Interactable.Interactable interactable, Interactor interactor)
		{
			interactable.EmitSignal(nameof(interactable.NotClosest), interactor);
			interactor.EmitSignal(nameof(interactor.NotClosestToInteractable), interactable);
		}

		protected Interactable.Interactable GetInteractableFromPath(NodePath path)
		{
			var node = GetNodeOrNull(path);
			if (node is not Interactable.Interactable interactable) return null;

			return interactable;
		}
	}
}
