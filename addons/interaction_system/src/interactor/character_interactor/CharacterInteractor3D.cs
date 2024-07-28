#if TOOLS
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
    private bool _longInteractionFinished;

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            return;
        }

        base._Ready();

        LongInteractionTimer!.Timeout += () =>
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
            const string warning = "This node does not have an action associated with it. " +
                "Please add an action name to this node.";
            _ = warnings.Append(warning).ToArray();
        }

        return warnings;
    }

    public override void _Input(InputEvent @event)
    {
        if (Engine.IsEditorHint())
        {
            return;
        }

        if (@event.IsActionPressed(_actionName))
        {
            if (LongInteractionTimer!.TimeLeft == 0)
            {
                LongInteractionTimer.Start();
                _longInteractionFinished = false;
            }
        }
        else if (@event.IsActionReleased(_actionName))
        {
            if (_longInteractionFinished)
            {
                return;
            }

            LongInteractionTimer!.Stop();
            CallInteraction(false);
        }
    }

    private void CallInteraction(bool @long = true)
    {
        if (IsInstanceValid(CachedRayCasted) && !DisableInteractionViaRayCast)
        {
            if (@long)
            {
                LongInteract(CachedRayCasted!);
            }
            else
            {
                Interact(CachedRayCasted!);
            }
        }

        if (IsInstanceValid(CachedClosest)
            && UseAreaToInteract
            && InteractionOn == EAreaInteractionType.InputAction
        )
        {
            if (@long)
            {
                LongInteract(CachedClosest!);
            }
            else
            {
                Interact(CachedClosest!);
            }
        }
    }
}
#endif
