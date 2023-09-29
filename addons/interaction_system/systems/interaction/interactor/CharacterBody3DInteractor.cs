using System.Linq;
using Godot;

[Tool]
public partial class CharacterBody3DInteractor : Interactor3D
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
	private Interactable3D _cachedClosest = null;
	private Interactable3D _cachedRayCasted = null;

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

	}

	/// <summary>
	/// Checks for a RayCast hit and focuses on the Interactable object if found.
	/// </summary>
	private void CheckRayCast()
	{
		if (_rayCast == null) return;

		var newRayCasted = (Interactable3D)GetRayCastedInteractable();

		if (newRayCasted == _cachedRayCasted) return;

		if (IsInstanceValid(_cachedRayCasted)) Unfocus(_cachedRayCasted);
		if (IsInstanceValid(newRayCasted)) Focus(newRayCasted);

		_cachedRayCasted = newRayCasted;
	}
}
