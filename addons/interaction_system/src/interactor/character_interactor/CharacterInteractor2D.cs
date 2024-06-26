using System.Linq;
using Godot;
using InteractionSystem.Enums;

namespace InteractionSystem;

[Tool]
public partial class CharacterInteractor2D : Interactor2D
{
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

	[ExportSubgroup("RayCast")]
	[Export] public bool DisableInteractionViaRayCast { get; set; } = false;

	[ExportSubgroup("Area")]
	[Export] public bool UseAreaToInteract { get; set; } = false;
	/// <summary>
	/// Determines the type of interaction that triggers the Interactor. <br/>
	///
	/// <list type="bullet">
	///     <listheader>
	///         <term>Collision</term>
	///         <description>
	///         The interaction signal is emitted when Interactable starts to collide with Area.
	///         </description>
	///     </listheader>
	///     <item>
	///         <term>Input Action</term>
	///         <description>
	///         The interaction signal is emitted when Interactable collides with Area
	///         and the user presses the button responsible for the interaction.
	///         </description>
	///     </item>
	/// </list>
	/// </summary>
	[Export] public EAreaInteractionType InteractionOn { get; set; } = EAreaInteractionType.Collision;

	private string _actionName = string.Empty;
	private Interactable2D? _cachedClosest = null;
	private Interactable2D? _cachedRayCasted = null;

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

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed(_actionName))
		{
			if (IsInstanceValid(_cachedRayCasted) && !DisableInteractionViaRayCast)
			{
				Interact(_cachedRayCasted!);
			}

			if (IsInstanceValid(_cachedClosest) && UseAreaToInteract
				&& InteractionOn == EAreaInteractionType.InputAction)
			{
				Interact(_cachedClosest!);
			}
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (!Engine.IsEditorHint())
		{
			CheckRayCast();
			CheckArea();
		}
	}

	private void CheckRayCast()
	{
		if (_rayCast == null) return;

		var newRayCasted = (Interactable2D?)GetRayCastedInteractable();

		if (newRayCasted == _cachedRayCasted) return;

		if (IsInstanceValid(_cachedRayCasted)) Unfocus(_cachedRayCasted!);
		if (IsInstanceValid(newRayCasted)) Focus(newRayCasted!);

		_cachedRayCasted = newRayCasted;
	}

	private void CheckArea()
	{
		if (_area == null) return;

		var newClosest = GetClosestInteractable();

		if (newClosest == _cachedClosest) return;

		if (IsInstanceValid(_cachedClosest)) NotClosest(_cachedClosest!);
		if (IsInstanceValid(newClosest)) Closest(newClosest!);

		_cachedClosest = newClosest;
	}
}
