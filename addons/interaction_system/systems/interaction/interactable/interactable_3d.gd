@tool
extends Area3D

## Class used to create interactive objects in 3D space.
class_name Interactable3D

## Emitted when an [Interactor3D] starts looking at object.
signal focused(interactor: Interactor3D)
## Emitted when an [Interactor3D] stops looking at object.
signal unfocused(interactor: Interactor3D)
## Emitted when an [Interactor3D] interacts with an object.
signal interacted(interactor: Interactor3D)
## Emitted when an [Interactable3D] is the closest to the [Interactor3D].
signal closest(interactor: Interactor3D)
## Emitted when an [Interactable3D] is no longer the closest one to the [Interactor3D].
signal not_closest(interactor: Interactor3D)
