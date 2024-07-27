using System.Collections.Generic;
using Godot;

namespace InteractionSystem.Interfaces;

public interface IArea
{
    public IVector GlobalPosition { get; set; }

    public IEnumerable<IArea> GetOverlappingAreas();
    public Variant GetMeta(string name);
    public void SetMeta(string name, Variant value);
}
