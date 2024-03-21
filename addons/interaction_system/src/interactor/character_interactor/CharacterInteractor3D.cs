using System.Linq;
using Godot;
using InteractionSystem.Enums;

namespace InteractionSystem;

[Tool]
public partial class CharacterInteractor3D : Interactor3D
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

	private string _actionName = null;
	private Interactable3D _cachedClosest = null;
	private Interactable3D _cachedRayCasted = null;
	private bool _longInteractionFinished = false;

	public override void _Ready()
	{
		base._Ready();

		LongInteractionTimer.Timeout += () =>
		{
			CallInteraction();
			_longInteractionFinished = true;
		};
	}

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
			if (LongInteractionTimer.TimeLeft == 0)
			{
				LongInteractionTimer.Start();
				_longInteractionFinished = false;
			}
		}
		else if (@event.IsActionReleased(_actionName))
		{
			if (_longInteractionFinished) return;

			LongInteractionTimer.Stop();
			CallInteraction(false);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Engine.IsEditorHint()) return;

		CheckRayCast();
		CheckArea();
	}

	private void CallInteraction(bool @long = true)
	{
		if (IsInstanceValid(_cachedRayCasted) && !DisableInteractionViaRayCast)
		{
			if (@long) LongInteract(_cachedRayCasted);
			else Interact(_cachedRayCasted);
		}

		if (IsInstanceValid(_cachedClosest) && UseAreaToInteract &&
			InteractionOn == EAreaInteractionType.InputAction
		)
		{
			if (@long) LongInteract(_cachedClosest);
			else Interact(_cachedClosest);
		}
	}

	/// <summary>
	/// Checks for a RayCast hit and focuses on the Interactable object if found.
	/// </summary>
	private void CheckRayCast()
	{
		if (_rayCast is null) return;

		var newRayCasted = (Interactable3D)GetRayCastedInteractable();

		if (newRayCasted == _cachedRayCasted) return;

		if (IsInstanceValid(_cachedRayCasted)) Unfocus(_cachedRayCasted);
		if (IsInstanceValid(newRayCasted)) Focus(newRayCasted);

		_cachedRayCasted = newRayCasted;
	}

	/// <summary>
	/// Checks if the interactor is within range of any interactable objects in the assigned area.
	/// If a new closest interactable object is found, calls the Closest method.
	/// If the previously closest interactable object is no longer the closest,
	/// calls the NotClosest method.
	/// </summary>
	private void CheckArea()
	{
		if (Area is null) return;

		var newClosest = GetClosestInteractable();

		if (newClosest == _cachedClosest) return;

		if (IsInstanceValid(_cachedClosest)) NotClosest(_cachedClosest);
		if (IsInstanceValid(newClosest)) Closest(newClosest);

		_cachedClosest = newClosest;
	}
}
