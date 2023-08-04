<div align="center">
	<h3>Character Body 3D Interactor Node</h3>
	<p />
	<p>A specialized class tailored for CharacterBody3D, it simplifies the process of creating a player character.</p>
</div>

## Exported variables

| Name        | Type   | Description                                                   |
| ----------- | ------ | ------------------------------------------------------------- |
| action_name | String | The name of the input action you want to use for interaction. |

## Usage

> Note: This class is an extension of `Interactor`, and therefore also includes the initialization requirements of the parent class (such as exported variables).

This class is used to create `CharacterBody3D` that can interact with `Interactable`, exactly it is used to create the player.

To use it, create a new script whose main node is `CharacterBody3D`. As its child, add `CharacterBody3DInteractor`.

Then in `Inspector`, enter `Action Name` to interact with objects, also remember to add `Ray Cast 3D` or `Area 3D` as required by `Interactor`.

And that's it, the player character is ready to interact with objects.
