#if TOOLS
using Godot;
using InteractionSystem.Classes;

namespace InteractionSystem;

[Tool]
public partial class Interactor2D : InteractorSpatial
{
    [Export]
    public RayCast2D? RayCast2D
    {
        get => ((RayCast2DAdapter?)RayCast)?.RayCast;
        set
        {
            if (value != ((RayCast2DAdapter?)RayCast)?.RayCast)
            {
                RayCast = value is null ? null : new RayCast2DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
    }

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
