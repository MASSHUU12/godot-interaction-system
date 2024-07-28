#if TOOLS
using Godot;
using InteractionSystem.Classes;

namespace InteractionSystem;

[Tool]
public partial class Interactable2D : Interactable
{
    [Export]
    public Area2D? Area2D
    {
        get => ((Area2DAdapter?)Area)?.Area;
        set
        {
            if (value != ((Area2DAdapter?)Area)?.Area)
            {
                Area = value is null ? null : new Area2DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
    }
}
#endif
