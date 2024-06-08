using Godot;
using InteractionSystem.Interfaces;

namespace InteractionSystem.Classes;

public class RayCast2DAdapter : IRayCast
{
	private readonly RayCast2D _rayCast2D;

	public RayCast2DAdapter(RayCast2D rayCast2D)
	{
		_rayCast2D = rayCast2D;
	}

	public Node? GetCollider()
	{
		return (Node?)_rayCast2D.GetCollider();
	}
}
