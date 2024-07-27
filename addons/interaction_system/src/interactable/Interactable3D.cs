using Godot;
using InteractionSystem.Classes;

namespace InteractionSystem;

[Tool]
public partial class Interactable3D : Interactable
{
    [Export]
    public Area3D? Area3D
    {
        get => ((Area3DAdapter?)Area)?.Area;
        set
        {
            if (value != ((Area3DAdapter?)Area)?.Area && value is not null)
            {
                Area = new Area3DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
    }
}
