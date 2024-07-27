using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem.Classes;

public class RayCast2DAdapter : IRayCast
{
    public RayCast2D RayCast { get; init; }

    public RayCast2DAdapter(ref RayCast2D rayCast2D)
    {
        RayCast = rayCast2D;
    }

    public Node? GetCollider()
    {
        return (Node?)RayCast.GetCollider();
    }
}
