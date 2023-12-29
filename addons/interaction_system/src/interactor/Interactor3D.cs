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

		public void Interact(IInteractable interactable)
		{
			Interact((Interactable3D)interactable, this);
		}

		public void Focus(IInteractable interactable)
		{
			Focus((Interactable3D)interactable, this);
		}

		public void Unfocus(IInteractable interactable)
		{
			Unfocus((Interactable3D)interactable, this);
		}

		public void Closest(IInteractable interactable)
		{
			Closest((Interactable3D)interactable, this);
		}

		public void NotClosest(IInteractable interactable)
		{
			NotClosest((Interactable3D)interactable, this);
		}

		public IInteractable GetClosestInteractable()
		{
			var list = Area.GetOverlappingAreas();
			float distance;
			float closestDistance = float.MaxValue;
			IInteractable closestInteractable = null;

			foreach (var body in list)
			{
				if (body is not IInteractable interactable) continue;

				distance = body.GlobalPosition.DistanceTo(Area.GlobalPosition);
				if (distance < closestDistance)
				{
					closestDistance = distance;
					closestInteractable = interactable;
				}
			}

			return closestInteractable;
		}

		public IInteractable GetRayCastedInteractable()
		{
			return GetRayCastedInteractable(RayCast);
		}
	}
}
