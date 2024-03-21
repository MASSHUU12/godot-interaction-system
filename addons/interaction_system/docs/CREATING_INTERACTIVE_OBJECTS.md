<div align="center">
	<h3>Creating interactive objects (C#/GDScript)</h3>
	<p />
</div>

> [!NOTE]
> It is worth moving collisions regarding interactions to a separate layer/mask.

Interactive objects for operation must include `Interactable2D/3D` and `Area2D/3D`.

A reference to `Area2D/3D` must be passed to `Interactable2D/3D`. Then just plug in the script and listen for the appropriate signals.
