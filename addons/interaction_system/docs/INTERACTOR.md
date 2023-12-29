<div align="center">
	<h3>Interactor</h3>
	<p />
	<p>A base class for creating characters that interact with interactive objects.</p>
</div>

A base class for creating characters that interact with interactive objects.

> [!NOTE]
> If you want to create a simple `player character`, it is best to use the already prepared [`CharacterInteractor2D/3D`](./CHARACTER_INTERACTOR.md) class.

Requires passing `RayCast2D/3D` (Focused/Unfocused signals) and/or `Area2D/3D` (Closest/NotClosest signals) in exported variables.

## Signals

| Signal                       | Parameter                                                |
| ---------------------------- | -------------------------------------------------------- |
| **Interacted**               | Interactable that Interactor interacted with             |
| **ClosestToInteractable**    | Interactable that is closest to the Interactor           |
| **NotClosestToInteractable** | Interactable that is no longer closest to the Interactor |
| **FocusedOnInteractable**    | Interactable that Interactor is looking at               |
| **UnfocusedInteractable**    | Interactable that is no longer looked at by Interactor   |
