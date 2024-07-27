using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem.Classes;

public class RayCast3DAdapter : IRayCast
{
    public RayCast3D RayCast { get; init; }

    public RayCast3DAdapter(ref RayCast3D rayCast3D)
    {
        RayCast = rayCast3D;
    }

    public Node? GetCollider()
    {
        return (Node?)RayCast.GetCollider();
    }
}
