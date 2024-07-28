#if TOOLS
using System.Linq;
using Godot;
using Godot.Collections;

namespace InteractionSystem;

[Tool]
public partial class MouseInteractor2D : Interactor
{
    [Export]
    public uint CollisionMask { get; set; } = 2;

    [Export]
    public string ActionName
    {
        get => _actionName;
        set
        {
            if (value != _actionName)
            {
                _actionName = value;
                UpdateConfigurationWarnings();
            }
        }
    }

    private string _actionName = string.Empty;
    private Interactable2D? _cachedHovered;

    public override string[] _GetConfigurationWarnings()
    {
        string[] warnings = base._GetConfigurationWarnings();

        if (string.IsNullOrEmpty(_actionName))
        {
            const string warning = "This node does not have an action associated with it. " +
                "Please add an action name to this node.";
            _ = warnings.Append(warning).ToArray();
        }

        return warnings;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (!Engine.IsEditorHint())
        {
            CheckHover();
        }
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event.IsActionPressed(_actionName) && IsInstanceValid(_cachedHovered))
        {
            Interact(_cachedHovered!);
        }
    }

    private Vector2 GetGlobalMousePosition()
    {
        Viewport viewport = GetViewport();
        Vector2 mousePosition = viewport.GetMousePosition();
#if GODOT4_3_OR_GREATER
        Transform2D viewToWorld = viewport.GetCanvasTransform().AffineInverse();
#else
        Transform2D viewToWorld = viewport.Call("get_canvas_transform").AsTransform2D().AffineInverse();
#endif

        return viewToWorld * mousePosition;
    }

    private Interactable2D? RayCastFromMousePosition()
    {
        PhysicsDirectSpaceState2D spaceState = GetTree().Root.World2D.DirectSpaceState;
        PhysicsPointQueryParameters2D query = new()
        {
            Position = GetGlobalMousePosition(),
            CollideWithAreas = true,
            CollideWithBodies = true,
            CollisionMask = CollisionMask,
        };
        Array<Dictionary> result = spaceState.IntersectPoint(query);

        if (result.Count == 0)
        {
            return null;
        }

        foreach (Dictionary hit in result)
        {
            Node2D collider = (Node2D)hit["collider"];
            NodePath meta = collider.GetMeta("interactable").As<NodePath>();
            Interactable? interactable = GetInteractableFromPath(meta);

            if (interactable is Interactable2D interactable2D)
            {
                return interactable2D;
            }
        }

        return null;
    }

    private void CheckHover()
    {
        Interactable2D? newHovered = RayCastFromMousePosition();

        if (newHovered == _cachedHovered)
        {
            return;
        }

        if (IsInstanceValid(_cachedHovered))
        {
            Unfocus(_cachedHovered!);
        }

        if (IsInstanceValid(newHovered))
        {
            Focus(newHovered!);
        }

        _cachedHovered = newHovered!;
    }
}
#endif
