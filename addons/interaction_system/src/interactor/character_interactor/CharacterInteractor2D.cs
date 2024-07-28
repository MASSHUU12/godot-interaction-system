#if TOOLS
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

    [Export] public bool DisableInteractionViaRayCast { get; set; }

    [ExportSubgroup("Area")]
    [Export] public bool UseAreaToInteract { get; set; }
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

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed(_actionName))
        {
            if (IsInstanceValid(CachedRayCasted) && !DisableInteractionViaRayCast)
            {
                Interact(CachedRayCasted!);
            }

            if (IsInstanceValid(CachedClosest) && UseAreaToInteract
                && InteractionOn == EAreaInteractionType.InputAction)
            {
                Interact(CachedClosest!);
            }
        }
    }
}
#endif
