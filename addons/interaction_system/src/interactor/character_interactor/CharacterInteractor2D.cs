using System.Linq;
using Godot;
using InteractionSystem.Interactable;

namespace InteractionSystem.Interactor
{
	[Tool]
	public partial class CharacterInteractor2D : Interactor2D
	{
		/// <summary>
		/// The name of the action associated with this Interactor. <br/>
		/// <seealso href="https://docs.godotengine.org/en/stable/tutorials/inputs/input_examples.html#inputmap">
		/// Godot input map documentation
		/// </seealso>
		/// </summary>
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

		/// <summary>
		/// Gets or sets a value indicating whether interaction with objects
		/// should be disabled via RayCast.
		/// </summary>
		[ExportSubgroup("RayCast")]
		[Export] public bool DisableInteractionViaRayCast { get; set; } = false;

		/// <summary>
		/// Gets or sets a value indicating whether to use the area to interact.
		/// </summary>
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
		[Export] public AreaInteractionType InteractionOn { get; set; } = AreaInteractionType.Collision;

		public enum AreaInteractionType
		{
			Collision,
			InputAction
		}

		private string _actionName = null;
		private Interactable2D _cachedClosest = null;
		private Interactable2D _cachedRayCasted = null;

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
					Interact(_cachedRayCasted);
				}

				if (IsInstanceValid(_cachedClosest) && UseAreaToInteract
					&& InteractionOn == AreaInteractionType.InputAction)
				{
					Interact(_cachedClosest);
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

		/// <summary>
		/// Checks for a RayCast hit and focuses on the Interactable object if found.
		/// </summary>
		private void CheckRayCast()
		{
			if (_rayCast == null) return;

			var newRayCasted = (Interactable2D)GetRayCastedInteractable();

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
			if (_area == null) return;

			var newClosest = GetClosestInteractable();

			if (newClosest == _cachedClosest) return;

			if (IsInstanceValid(_cachedClosest)) NotClosest(_cachedClosest);
			if (IsInstanceValid(newClosest)) Closest(newClosest);

			_cachedClosest = newClosest;
		}

		public Interactable.Interactable GetRayCastedInteractable()
		{
			var collider = (Area2D)RayCast?.GetCollider();
			if (collider?.GetParent() is not Interactable.Interactable interactable) return null;

			return interactable;
		}
	}
}
