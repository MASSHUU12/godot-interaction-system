using System.Collections.Generic;
using Godot;

namespace InteractionSystem.Interactor
{
	[Tool]
	public partial class Interactor2D : Node2D, IInteractor
	{
		[Signal]
		public delegate void InteractedWithInteractableEventHandler(Interactable.Interactable2D interactable);
		[Signal]
		public delegate void ClosestToInteractableEventHandler(Interactable.Interactable2D interactable);
		[Signal]
		public delegate void NotClosestToInteractableEventHandler(Interactable.Interactable2D interactable);
		[Signal]
		public delegate void FocusedOnInteractableEventHandler(Interactable.Interactable2D interactable);
		[Signal]
		public delegate void UnfocusedInteractableEventHandler(Interactable.Interactable2D interactable);

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

		public void Interact(Interactable.IInteractable interactable)
		{
			Interactor.Interact((Interactable.Interactable2D)interactable, this);
		}

		public void Focus(Interactable.IInteractable interactable)
		{
			Interactor.Focus((Interactable.Interactable2D)interactable, this);
		}

		public void Unfocus(Interactable.IInteractable interactable)
		{
			Interactor.Unfocus((Interactable.Interactable2D)interactable, this);
		}

		public void Closest(Interactable.IInteractable interactable)
		{
			Interactor.Closest((Interactable.Interactable2D)interactable, this);
		}

		public void NotClosest(Interactable.IInteractable interactable)
		{
			Interactor.NotClosest((Interactable.Interactable2D)interactable, this);
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
			return Interactor.GetRayCastedInteractable(rayCast2D: RayCast);
		}
	}

}
