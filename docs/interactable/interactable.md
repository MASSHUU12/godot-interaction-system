<div align="center">
	<h3>Interactable class</h3>
	<p />
	<p>Basic class used to create interactive objects that interact with <a href="../interactor/interactor.md">Interactor</a>.</p>
</div>

## Signals

| Name        | Description                                                            |
| ----------- | ---------------------------------------------------------------------- |
| focused     | Emitted when an Interactor starts looking at object.                   |
| unfocused   | Emitted when an Interactor stops looking at object.                    |
| interacted  | Emitted when an Interactor interacts with an object.                   |
| closest     | Emitted when an object is the closest to the Interactor.               |
| not_closest | Emitted when an object is no longer the closest one to the Interactor. |

## Usage

> Note: Interactive objects should be on a separate `Collision Layer` and `Collision Mask` than other objects in the game.

To create an interactive object, create a new scene with `Interactable` as the main node.

Assign a new script to it and link the `signals` you are interested in to it.

The interactive object is ready, the rest is up to you.
