using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem.Classes;

public class Vector2Adapter : IVector
{
    public Vector2 Vector { get; set; }

    public Vector2Adapter(Vector2 vector)
    {
        Vector = vector;
    }

    public float DistanceTo(IVector vector)
    {
        return Vector.DistanceTo(((Vector2Adapter)vector).Vector);
    }
}
