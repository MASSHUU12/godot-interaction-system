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
            if (value != ((Area2DAdapter?)Area)?.Area && value is not null)
            {
                Area = new Area2DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
    }
}
