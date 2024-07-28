using System.Collections.Generic;
using System.Linq;
using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem.Classes;

public class Area2DAdapter : IArea
{
    public IVector GlobalPosition
    {
        get => new Vector2Adapter(Area.GlobalPosition);
        set => Area.GlobalPosition = ((Vector2Adapter)value).Vector;
    }

    public Area2D Area { get; init; }

    public Area2DAdapter(ref Area2D area)
    {
        Area = area;
    }

    public IEnumerable<IArea> GetOverlappingAreas()
    {
        return Area
            .GetOverlappingAreas()
            .Select(area => new Area2DAdapter(ref area));
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
