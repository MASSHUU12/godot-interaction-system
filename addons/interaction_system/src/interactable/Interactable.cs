using Godot;

namespace InteractionSystem;

public partial class Interactable : Node
{
	[Signal] public delegate void InteractedEventHandler(Interactor interactor);
	[Signal] public delegate void LongInteractedEventHandler(Interactor interactor);
	[Signal] public delegate void ClosestEventHandler(Interactor interactor);
	[Signal] public delegate void NotClosestEventHandler(Interactor interactor);
	[Signal] public delegate void FocusedEventHandler(Interactor interactor);
	[Signal] public delegate void UnfocusedEventHandler(Interactor interactor);
}
