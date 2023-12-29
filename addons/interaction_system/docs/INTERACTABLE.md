<div align="center">
	<h3>Interactable</h3>
	<p />
	<p>A base used to create interactive objects.</p>
</div>

A basic class used to create `interactive` objects that `Interactor` can interact with.

It accepts `Area2D/3D` in the form of an exported variable.
`Area2D/3D` **must** be its child.

## Signals

| Signal         | Parameter                                                         |
| -------------- | ----------------------------------------------------------------- |
| **Interacted** | Interactor that interacted with the object                        |
| **Closest**    | Interactor, to which the object is the nearest Interactable       |
| **NotClosest** | Interactor, to which the object is no longer nearest Interactable |
| **FocusedOn**  | Interactor that is looking at the object                          |
| **Unfocused**  | Interactor that is no longer looking at the object                |
