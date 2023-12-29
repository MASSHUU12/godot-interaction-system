using Godot;

namespace InteractionSystem.Interactable
{
	public partial class Interactable2D : Area2D, IInteractable
	{
		[Signal] public delegate void InteractedEventHandler(Interactor2D interactor);
		[Signal] public delegate void ClosestEventHandler(Interactor2D interactor);
		[Signal] public delegate void NotClosestEventHandler(Interactor2D interactor);
		[Signal] public delegate void FocusedEventHandler(Interactor2D interactor);
		[Signal] public delegate void UnfocusedEventHandler(Interactor2D interactor);
	}

}
