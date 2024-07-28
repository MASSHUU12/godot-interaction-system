using System.Collections.Generic;
using System.Linq;
using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem.Classes;

public class Area3DAdapter : IArea
{
    public IVector GlobalPosition
    {
        get => new Vector3Adapter(Area.GlobalPosition);
        set => Area.GlobalPosition = ((Vector3Adapter)value).Vector;
    }

    public Area3D Area { get; init; }

    public Area3DAdapter(ref Area3D area)
    {
        Area = area;
    }

    public IEnumerable<IArea> GetOverlappingAreas()
    {
        return Area
            .GetOverlappingAreas()
            .Select(area => new Area3DAdapter(ref area));
    }

    public Variant GetMeta(string name)
    {
        return Area.GetMeta(name);
    }

    public void SetMeta(string name, Variant value)
    {
        Area.SetMeta(name, value);
    }
}
