using System.Collections.Generic;

namespace InteractionSystem.Interfaces;

public interface IArea
{
    public IVector GlobalPosition { get; set; }

    public IEnumerable<IArea> GetOverlappingAreas();
}
