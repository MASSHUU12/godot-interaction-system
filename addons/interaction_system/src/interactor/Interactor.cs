using Godot;

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

    public bool IsFocused { get; private set; }
    public Interactable? Focusing { get; private set; }
    protected Interactable? CachedRayCasted { get; set; }

    public bool IsClosest { get; private set; }
    public Interactable? ClosestInteractable { get; private set; }
    protected Interactable? CachedClosest { get; set; }

    protected Timer? LongInteractionTimer { get; private set; }

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            return;
        }

        base._Ready();

        LongInteractionTimer = new()
        {
            OneShot = true,
            WaitTime = LongInteractionTime
        };
        AddChild(LongInteractionTimer);
    }

    public override void _ExitTree()
    {
        if (Engine.IsEditorHint())
        {
            return;
        }

        base._ExitTree();

        LongInteractionTimer?.QueueFree();
    }

    public void Interact(Interactable interactable)
    {
        _ = interactable.EmitSignal(nameof(interactable.Interacted), this);
        _ = EmitSignal(SignalName.InteractedWithInteractable, interactable);
    }

    public void LongInteract(Interactable interactable)
    {
        _ = interactable.EmitSignal(nameof(interactable.LongInteracted), this);
        _ = EmitSignal(SignalName.LongInteractedWithInteractable, interactable);
    }

    public void Focus(Interactable interactable)
    {
        IsFocused = true;
        Focusing = interactable;

        _ = interactable.EmitSignal(nameof(interactable.Focused), this);
        _ = EmitSignal(SignalName.FocusedOnInteractable, interactable);
    }

    public void Unfocus(Interactable interactable)
    {
        IsFocused = false;
        Focusing = null;

        _ = interactable.EmitSignal(nameof(interactable.Unfocused), this);
        _ = EmitSignal(SignalName.UnfocusedInteractable, interactable);
    }

    public void Closest(Interactable interactable)
    {
        IsClosest = true;
        ClosestInteractable = interactable;

        _ = interactable.EmitSignal(nameof(interactable.Closest), this);
        _ = EmitSignal(SignalName.ClosestToInteractable, interactable);
    }

    public void NotClosest(Interactable interactable)
    {
        IsClosest = false;
        ClosestInteractable = null;

        _ = interactable.EmitSignal(nameof(interactable.NotClosest), this);
        _ = EmitSignal(SignalName.NotClosestToInteractable, interactable);
    }

    protected Interactable? GetInteractableFromPath(NodePath path)
    {
        return GetNodeOrNull(path) is Interactable interactable
            ? interactable
            : null;
    }
}
