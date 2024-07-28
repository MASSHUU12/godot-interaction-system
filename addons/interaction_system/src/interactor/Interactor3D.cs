#if TOOLS
using Godot;
using InteractionSystem.Classes;

namespace InteractionSystem;

[Tool]
public partial class Interactor3D : InteractorSpatial
{
    [Export]
    public RayCast3D? RayCast3D
    {
        get => ((RayCast3DAdapter?)RayCast)?.RayCast;
        set
        {
            if (value != ((RayCast3DAdapter?)RayCast)?.RayCast)
            {
                RayCast = value is null ? null : new RayCast3DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
    }

    [Export]
    public Area3D? Area3D
    {
        get => ((Area3DAdapter?)Area)?.Area;
        set
        {
            if (value != ((Area3DAdapter?)Area)?.Area)
            {
                Area = value is null ? null : new Area3DAdapter(ref value);
                UpdateConfigurationWarnings();
            }
        }
    }
}
#endif
