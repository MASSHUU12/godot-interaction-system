using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem.Classes;

public class Vector3Adapter : IVector
{
    public Vector3 Vector { get; set; }

    public Vector3Adapter(Vector3 vector)
    {
        Vector = vector;
    }

    public float DistanceTo(IVector vector)
    {
        return Vector.DistanceTo(((Vector3Adapter)vector).Vector);
    }
}
