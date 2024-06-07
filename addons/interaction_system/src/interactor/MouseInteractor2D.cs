using System.Linq;
using Godot;

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
	private Interactable2D? _cachedHovered = null;

	public override string[] _GetConfigurationWarnings()
	{
		string[] warnings = base._GetConfigurationWarnings();

		if (string.IsNullOrEmpty(_actionName))
		{
			var warning = "This node does not have an action associated with it. " +
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
		var viewport = GetViewport();
		var mousePosition = viewport.GetMousePosition();
		var viewToWorld = viewport.GetCanvasTransform().AffineInverse();
		var worldPosition = viewToWorld * mousePosition;

		return worldPosition;
	}

	private Interactable2D? RayCastFromMousePosition()
	{
		var spaceState = GetTree().Root.World2D.DirectSpaceState;
		var query = new PhysicsPointQueryParameters2D
		{
			Position = GetGlobalMousePosition(),
			CollideWithAreas = true,
			CollideWithBodies = true,
			CollisionMask = CollisionMask,
		};
		var result = spaceState.IntersectPoint(query);

		if (result.Count == 0) return null;

		foreach (var hit in result)
		{
			var collider = (Node2D)hit["collider"];
			var meta = collider.GetMeta("interactable", new NodePath()).As<NodePath>();
			var interactable = GetInteractableFromPath(meta);

			if (interactable is Interactable2D interactable2D)
				return interactable2D;
		}

		return null;
	}

	private void CheckHover()
	{
		var newHovered = RayCastFromMousePosition();

		if (newHovered == _cachedHovered) return;

		if (IsInstanceValid(_cachedHovered)) Unfocus(_cachedHovered!);
		if (IsInstanceValid(newHovered)) Focus(newHovered!);

		_cachedHovered = newHovered!;
	}
}
