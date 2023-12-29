<div align="center">
	<h3>Interactable Prop 3D</h3>
	<p />
	<p>Class used to create interactive objects with outline and/or highlight effect.</p>
</div>

A class, inheriting from `Interactable3D`, is used to simply create interactive objects with `outline` and/or `highlight` effects.

## Outline

Outline requires the creation of a `MeshInstance3D` to be used as the outline.

You can easily do this by selecting the `MeshInstance3D` of your object, clicking `Mesh` in the menu and selecting `Create Outline Mesh`.

## Highlight

Highlight by default uses [this shader](https://godotshaders.com/shader/collectable-item-shining-highlight/) under [MIT license](https://opensource.org/licenses/MIT).

You can change the shader in use using the exported `Highlighter Material` variable.
