@tool
extends Node

## Basic class, used to interact with [Interactable].
class_name Interactor


## Emits [signal Interactable.interacted] when an [Interactor] interacts with an [Interactable].
func interact(interactable: Interactable) -> void:
	interactable.interacted.emit(self)


## Emits [signal Interactable.focused] when an [Interactor] starts looking at [Interactable].
func focus(interactable: Interactable) -> void:
	interactable.focused.emit(self)


## Emits [signal Interactable.unfocused] when an [Interactor] stops looking at [Interactable].
func unfocus(interactable: Interactable) -> void:
	interactable.unfocused.emit(self)


## Emits [signal Interactable.closest] when an [Interactable] is the closest to the [Interactor].
func closest(interactable: Interactable) -> void:
	interactable.closest.emit(self)


## Emits [signal Interactable.not_closest] when an [Interactable] is no longer the closest one to the [Interactor].
func not_closest(interactable: Interactable) -> void:
	interactable.not_closest.emit(self)
