using Godot;

namespace InteractionSystem.Interactable
{
	public partial interface IInteractable
	{
		[Signal] public delegate void InteractedEventHandler(Interactor.IInteractor interactor);
		[Signal] public delegate void ClosestEventHandler(Interactor.IInteractor interactor);
		[Signal] public delegate void NotClosestEventHandler(Interactor.IInteractor interactor);
		[Signal] public delegate void FocusedEventHandler(Interactor.IInteractor interactor);
		[Signal] public delegate void UnfocusedEventHandler(Interactor.IInteractor interactor);
	}
}
