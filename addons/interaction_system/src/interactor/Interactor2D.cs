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

		protected Area2D _area = null;
		protected RayCast2D _rayCast = null;

		public override string[] _GetConfigurationWarnings()
		{
			List<string> warnings = new();

			if (_rayCast == null && _area == null)
			{
				var warning = "This node does not have the ability to interact with the world. " +
					"Please add a RayCast2D or Area2D to this node.";
				warnings.Add(warning);
			}

			warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

			return warnings.ToArray();
		}

		public void Interact(Interactable2D interactable)
		{
			Interact(interactable, this);
		}

		public void Focus(Interactable2D interactable)
		{
			Focus(interactable, this);
		}

		public void Unfocus(Interactable2D interactable)
		{
			Unfocus(interactable, this);
		}

		public void Closest(Interactable2D interactable)
		{
			Closest(interactable, this);
		}

		public void NotClosest(Interactable2D interactable)
		{
			NotClosest(interactable, this);
		}

		public Interactable.Interactable GetRayCastedInteractable()
		{
			var collider = (Area2D)RayCast?.GetCollider();
			if (collider?.GetParent() is not Interactable.Interactable interactable) return null;

			return interactable;
		}

		public Interactable2D GetClosestInteractable()
		{
			var list = Area.GetOverlappingAreas();
			float distance;
			float closestDistance = float.MaxValue;
			Interactable2D closestInteractable = null;

			foreach (var body in list)
			{
				var meta = body.GetMeta("interactable", new Node()).As<Interactable2D>();

				if (meta is not Interactable2D interactable) continue;

				distance = body.GlobalPosition.DistanceTo(Area.GlobalPosition);
				if (distance < closestDistance)
				{
					closestDistance = distance;
					closestInteractable = interactable;
				}
			}

			return closestInteractable;
		}
	}
}
