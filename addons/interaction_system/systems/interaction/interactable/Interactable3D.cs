using Godot;

public partial class Interactable3D : Area3D, IInteractable
{
	[Signal] public delegate void InteractedEventHandler();
	[Signal] public delegate void ClosestEventHandler();
	[Signal] public delegate void NotClosestEventHandler();
	[Signal] public delegate void FocusedEventHandler();
	[Signal] public delegate void UnfocusedEventHandler();
}
