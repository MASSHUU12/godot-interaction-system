using Godot;
using InteractionSystem.Interactable;

namespace InteractionSystem.Interactor
{
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

		protected void Interact(IInteractable interactable);
		protected void Focus(IInteractable interactable);
		protected void Unfocus(IInteractable interactable);
		protected void Closest(IInteractable interactable);
		protected void NotClosest(IInteractable interactable);

		protected IInteractable GetClosestInteractable();
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
			return (IInteractable)(rayCast3D?.GetCollider() ?? rayCast2D?.GetCollider()) ?? null;
		}
	}
}
