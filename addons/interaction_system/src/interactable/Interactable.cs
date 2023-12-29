using Godot;

namespace InteractionSystem.Interactable
{
	public partial interface IInteractable
	{
		[Signal] public delegate void InteractedEventHandler(IInteractor interactor);
		[Signal] public delegate void ClosestEventHandler(IInteractor interactor);
		[Signal] public delegate void NotClosestEventHandler(IInteractor interactor);
		[Signal] public delegate void FocusedEventHandler(IInteractor interactor);
		[Signal] public delegate void UnfocusedEventHandler(IInteractor interactor);
	}
}
