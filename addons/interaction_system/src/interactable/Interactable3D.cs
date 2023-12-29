using Godot;

namespace InteractionSystem.Interactable
{
	public partial class Interactable3D : Area3D, IInteractable
	{
		[Signal] public delegate void InteractedEventHandler(Interactor3D interactor);
		[Signal] public delegate void ClosestEventHandler(Interactor3D interactor);
		[Signal] public delegate void NotClosestEventHandler(Interactor3D interactor);
		[Signal] public delegate void FocusedEventHandler(Interactor3D interactor);
		[Signal] public delegate void UnfocusedEventHandler(Interactor3D interactor);
	}
}
