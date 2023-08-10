@tool
extends Area3D

## A basic class used to create interactive objects that interact with [Interactor].
class_name Interactable


## Emitted when an [Interactor] starts looking at object.
signal focused(interactor: Interactor)
## Emitted when an [Interactor] stops looking at object.
signal unfocused(interactor: Interactor)
## Emitted when an [Interactor] interacts with an object.
signal interacted(interactor: Interactor)
## Emitted when an [Interactable] is the closest to the [Interactor].
signal closest(interactor: Interactor)
## Emitted when an [Interactable] is no longer the closest one to the [Interactor].
signal not_closest(interactor: Interactor)