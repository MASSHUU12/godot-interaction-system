using System.Collections.Generic;
using Godot;
using InteractionSystem.Interactable;

namespace InteractionSystem.Interactor
{
	[Tool]
	public partial class Interactor3D : Interactor
	{
		[Export]
		public RayCast3D RayCast
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
		public Area3D Area
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

		protected Area3D _area = null;
		protected RayCast3D _rayCast = null;

		public override string[] _GetConfigurationWarnings()
		{
			List<string> warnings = new();

			if (_rayCast == null && _area == null)
			{
				var warning = "This node does not have the ability to interact with the world. " +
					"Please add a RayCast3D or Area3D to this node.";
				warnings.Add(warning);
			}

			warnings.AddRange(base._GetConfigurationWarnings() ?? System.Array.Empty<string>());

			return warnings.ToArray();
		}

		public void Interact(Interactable3D interactable)
		{
			Interact(interactable, this);
		}

		public void Focus(Interactable3D interactable)
		{
			Focus(interactable, this);
		}

		public void Unfocus(Interactable3D interactable)
		{
			Unfocus(interactable, this);
		}

		public void Closest(Interactable3D interactable)
		{
			Closest(interactable, this);
		}

		public void NotClosest(Interactable3D interactable)
		{
			NotClosest(interactable, this);
		}

		public Interactable.Interactable GetRayCastedInteractable()
		{
			var collider = (Area3D)RayCast?.GetCollider();
			if (collider?.GetParent() is not Interactable.Interactable interactable) return null;

			return interactable;
		}

		public Interactable3D GetClosestInteractable()
		{
			var list = Area.GetOverlappingAreas();
			float distance;
			float closestDistance = float.MaxValue;
			Interactable3D closestInteractable = null;

			foreach (Area3D body in list)
			{
				var meta = body.GetMeta("interactable", new Node()).As<Interactable3D>();

				if (meta is not Interactable3D interactable) continue;

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
