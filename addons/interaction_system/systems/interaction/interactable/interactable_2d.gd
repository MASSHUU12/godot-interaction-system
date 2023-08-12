@tool
extends Area2D

## Class used to create interactive objects in 2D space.
class_name Interactable2D

## Emitted when an [Interactor2D] starts looking at object.
signal focused(interactor: Interactor2D)
## Emitted when an [Interactor2D] stops looking at object.
signal unfocused(interactor: Interactor2D)
## Emitted when an [Interactor2D] interacts with an object.
signal interacted(interactor: Interactor2D)
## Emitted when an [Interactable2D] is the closest to the [Interactor2D].
signal closest(interactor: Interactor2D)
## Emitted when an [Interactable2D] is no longer the closest one to the [Interactor2D].
signal not_closest(interactor: Interactor2D)
