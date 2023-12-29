using System.Collections.Generic;
using Godot;

namespace InteractionSystem.Interactor
{
	[Tool]
	public partial class Interactor3D : Node3D, IInteractor
	{
		[Signal]
		public delegate void InteractedWithInteractableEventHandler(Interactable.Interactable3D interactable);
		[Signal]
		public delegate void ClosestToInteractableEventHandler(Interactable.Interactable3D interactable);
		[Signal]
		public delegate void NotClosestToInteractableEventHandler(Interactable.Interactable3D interactable);
		[Signal]
		public delegate void FocusedOnInteractableEventHandler(Interactable.Interactable3D interactable);
		[Signal]
		public delegate void UnfocusedInteractableEventHandler(Interactable.Interactable3D interactable);

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

		public void Interact(Interactable.IInteractable interactable)
		{
			Interactor.Interact((Interactable.Interactable3D)interactable, this);
		}

		public void Focus(Interactable.IInteractable interactable)
		{
			Interactor.Focus((Interactable.Interactable3D)interactable, this);
		}

		public void Unfocus(Interactable.IInteractable interactable)
		{
			Interactor.Unfocus((Interactable.Interactable3D)interactable, this);
		}

		public void Closest(Interactable.IInteractable interactable)
		{
			Interactor.Closest((Interactable.Interactable3D)interactable, this);
		}

		public void NotClosest(Interactable.IInteractable interactable)
		{
			Interactor.NotClosest((Interactable.Interactable3D)interactable, this);
		}

		public Interactable.IInteractable GetClosestInteractable()
		{
			var list = Area.GetOverlappingAreas();
			float distance;
			float closestDistance = float.MaxValue;
			Interactable.IInteractable closestInteractable = null;

			foreach (var body in list)
			{
				if (body is not Interactable.IInteractable interactable) continue;

				distance = body.GlobalPosition.DistanceTo(GlobalPosition);
				if (distance < closestDistance)
				{
					closestDistance = distance;
					closestInteractable = interactable;
				}
			}

			return closestInteractable;
		}

		public Interactable.IInteractable GetRayCastedInteractable()
		{
			return Interactor.GetRayCastedInteractable(RayCast);
		}
	}

}
