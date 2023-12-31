using System.Collections.Generic;
using Godot;
using InteractionSystem.Interactable;

namespace InteractionSystem.Interactor
{
	[Tool]
	public partial class Interactor2D : Interactor
	{
		[Export]
		public RayCast2D RayCast
		{
			get => _rayCast;
			set
			{
				if (value != _rayCast)
				{
					_rayCast = value;
					UpdateConfigurationWarnings();
				}
			}
		}

		[Export]
		public Area2D Area
		{
			get => _area;
			set
			{
				if (value != _area)
				{
					_area = value;
					UpdateConfigurationWarnings();
				}
			}
		}

		protected Area2D _area;
		protected RayCast2D _rayCast;

		public override string[] _GetConfigurationWarnings()
		{
			List<string> warnings = new();

			if (_rayCast is null && _area is null)
			{
				var warning = "This node does not have the ability to interact with the world. " +
					"Please add a RayCast2D or Area2D to this node.";
				warnings.Add(warning);
			}

			warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

			return warnings.ToArray();
		}

		public Interactable.Interactable GetRayCastedInteractable()
		{
			var collider = (Area2D)RayCast?.GetCollider();
			var path = collider?.GetMeta("interactable", new NodePath()).As<NodePath>();

			return GetInteractableFromPath(path);
		}

		public Interactable2D GetClosestInteractable()
		{
			var list = Area.GetOverlappingAreas();
			float distance;
			float closestDistance = float.MaxValue;
			Interactable2D closestInteractable = null;

			foreach (var body in list)
			{
				var meta = body.GetMeta("interactable", new Node()).As<NodePath>();
				var interactable = GetInteractableFromPath(meta);

				if (interactable is not Interactable2D) continue;

				distance = body.GlobalPosition.DistanceTo(Area.GlobalPosition);
				if (distance < closestDistance)
				{
					closestDistance = distance;
					closestInteractable = (Interactable2D)interactable;
				}
			}

			return closestInteractable;
		}
	}
}
