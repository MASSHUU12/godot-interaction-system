using Godot;

namespace InteractionSystem.Interactable
{
	public partial class Interactable2D : Area2D, IInteractable
	{
		[Signal] public delegate void InteractedEventHandler(Interactor.Interactor2D interactor);
		[Signal] public delegate void ClosestEventHandler(Interactor.Interactor2D interactor);
		[Signal] public delegate void NotClosestEventHandler(Interactor.Interactor2D interactor);
		[Signal] public delegate void FocusedEventHandler(Interactor.Interactor2D interactor);
		[Signal] public delegate void UnfocusedEventHandler(Interactor.Interactor2D interactor);
	}

}
