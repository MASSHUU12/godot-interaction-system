@tool
extends Area3D

class_name Interactable3D

## Emitted when an [Interactor3D] starts looking at object.
signal focused(interactor: Interactor3D)
## Emitted when an [Interactor3D] stops looking at object.
signal unfocused(interactor: Interactor3D)
## Emitted when an [Interactor3D] interacts with an object.
signal interacted(interactor: Interactor3D)
## Emitted when an [Interactable] is the closest to the [Interactor3D].
signal closest(interactor: Interactor3D)
## Emitted when an [Interactable] is no longer the closest one to the [Interactor3D].
signal not_closest(interactor: Interactor3D)
