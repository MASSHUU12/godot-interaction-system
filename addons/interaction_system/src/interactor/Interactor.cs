using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem;

public partial class Interactor : Node
{
	[Signal]
	public delegate void InteractedWithInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void LongInteractedWithInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void ClosestToInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void NotClosestToInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void FocusedOnInteractableEventHandler(Interactor interactable);
	[Signal]
	public delegate void UnfocusedInteractableEventHandler(Interactor interactable);

	[Export(PropertyHint.Range, "0.05,5,0.1")]
	public float LongInteractionTime { get; set; } = 0.3f;

	public bool IsFocused { get; private set; } = false;
	public Interactable? Focusing { get; private set; }

	public bool IsClosest { get; private set; } = false;
	public Interactable? ClosestInteractable { get; private set; }

	protected Timer? LongInteractionTimer { get; private set; }
	protected IRayCast? _adapter;

	public override void _Ready()
	{
		base._Ready();

		if (Engine.IsEditorHint()) return;

		LongInteractionTimer = new()
		{
			OneShot = true,
			WaitTime = LongInteractionTime
		};
		AddChild(LongInteractionTimer);
	}

	public override void _ExitTree()
	{
		base._ExitTree();

		LongInteractionTimer!.QueueFree();
	}

	public void Interact(Interactable interactable)
	{
		interactable.EmitSignal(nameof(interactable.Interacted), this);
		EmitSignal(SignalName.InteractedWithInteractable, interactable);
	}

	public void LongInteract(Interactable interactable)
	{
		interactable.EmitSignal(nameof(interactable.LongInteracted), this);
		EmitSignal(SignalName.LongInteractedWithInteractable, interactable);
	}

	public void Focus(Interactable interactable)
	{
		IsFocused = true;
		Focusing = interactable;

		interactable.EmitSignal(nameof(interactable.Focused), this);
		EmitSignal(SignalName.FocusedOnInteractable, interactable);
	}

	public void Unfocus(Interactable interactable)
	{
		IsFocused = false;
		Focusing = null;

		interactable.EmitSignal(nameof(interactable.Unfocused), this);
		EmitSignal(SignalName.UnfocusedInteractable, interactable);
	}

	public void Closest(Interactable interactable)
	{
		IsClosest = true;
		ClosestInteractable = interactable;

		interactable.EmitSignal(nameof(interactable.Closest), this);
		EmitSignal(SignalName.ClosestToInteractable, interactable);
	}

	public void NotClosest(Interactable interactable)
	{
		IsClosest = false;
		ClosestInteractable = null;

		interactable.EmitSignal(nameof(interactable.NotClosest), this);
		EmitSignal(SignalName.NotClosestToInteractable, interactable);
	}

	protected Interactable? GetInteractableFromPath(NodePath path)
	{
		return GetNodeOrNull(path) is Interactable interactable
			? interactable
			: null;
	}

	protected Interactable? GetRayCastedInteractable()
	{
		Node? collider = _adapter?.GetCollider();
		NodePath? path = null;

		if (collider is Area2D area2D)
		{
			path = area2D.GetMeta("interactable").As<NodePath>();
		}
		else if (collider is Area3D area3D)
		{
			path = area3D.GetMeta("interactable").As<NodePath>();
		}

		return path is not null ? GetInteractableFromPath(path) : null;
	}
}
