using Godot;

namespace InteractionSystem.Interactable;

public partial class Interactable : Node
{
	[Signal] public delegate void InteractedEventHandler(Interactor.Interactor interactor);
	[Signal] public delegate void LongInteractedEventHandler(Interactor.Interactor interactor);
	[Signal] public delegate void ClosestEventHandler(Interactor.Interactor interactor);
	[Signal] public delegate void NotClosestEventHandler(Interactor.Interactor interactor);
	[Signal] public delegate void FocusedEventHandler(Interactor.Interactor interactor);
	[Signal] public delegate void UnfocusedEventHandler(Interactor.Interactor interactor);
}
