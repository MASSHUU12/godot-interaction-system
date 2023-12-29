using Godot;

namespace InteractionSystem.Interactable
{
	public partial class Interactable3D : Area3D, IInteractable
	{
		[Signal] public delegate void InteractedEventHandler(Interactor.Interactor3D interactor);
		[Signal] public delegate void ClosestEventHandler(Interactor.Interactor3D interactor);
		[Signal] public delegate void NotClosestEventHandler(Interactor.Interactor3D interactor);
		[Signal] public delegate void FocusedEventHandler(Interactor.Interactor3D interactor);
		[Signal] public delegate void UnfocusedEventHandler(Interactor.Interactor3D interactor);
	}
}
