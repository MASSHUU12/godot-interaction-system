@tool
extends Node2D

## Class, used to interact with [Interactable2D].
class_name Interactor2D

## [RayCast2D] node used to interact with [Interactable2D].
## [br][br]
## Emits [Signal]s: [br]
## [signal Interactable2D.interacted][br]
## [signal Interactable2D.focused][br]
## [signal Interactable2D.unfocused]
@export var ray_cast: RayCast2D = null:
	set(p_ray_cast):
		if p_ray_cast != ray_cast:
			ray_cast = p_ray_cast
			update_configuration_warnings()

## [Area2D] node used to interact with [Interactable2D].
## [br][br]
## Emits [Signal]s: [br]
## [signal Interactable2D.closest][br]
## [signal Interactable2D.not_closest]
@export var area: Area2D = null:
	set(p_area):
		if p_area != area:
			area = p_area
			update_configuration_warnings()


func _get_configuration_warnings() -> PackedStringArray:
	var warnings = []

	if ray_cast == null and area == null:
		warnings.append(
			"This node does not have the ability to interact with the world, \
			add RayCast3D and/or Area3D to the appropriate fields."
		)

	return warnings


## Returns the closes overlapping [Interactable2D] or null if there is no one.
func get_closest_interactable() -> Interactable2D:
	var list: Array[Area2D] = area.get_overlapping_areas()
	var distance: float
	var closest_distance: float = INF
	var closest_interactable: Interactable2D = null

	for interactable in list:
		distance = interactable.global_position.distance_to(self.global_position)

		# Sets the first interactable in the list as closest
		if distance < closest_distance:
			closest_interactable = interactable as Interactable2D
			closest_distance = distance

	return closest_interactable


## Returns the overlapping [Interactable2D] or null if there is no one.
func get_raycasted_interactable() -> Interactable2D:
	var collider: Area2D  = ray_cast.get_collider()
	return collider as Interactable2D if collider else null


## Emits [signal Interactable2D.interacted] when an [Interactor] interacts with an [Interactable2D].
func interact(interactable: Interactable2D) -> void:
	interactable.interacted.emit(self)


## Emits [signal Interactable2D.focused] when an [Interactor] starts looking at [Interactable2D].
func focus(interactable: Interactable2D) -> void:
	interactable.focused.emit(self)


## Emits [signal Interactable2D.unfocused] when an [Interactor] stops looking at [Interactable2D].
func unfocus(interactable: Interactable2D) -> void:
	interactable.unfocused.emit(self)


## Emits [signal Interactable2D.closest] when an [Interactable2D] is the closest to the [Interactor].
func closest(interactable: Interactable2D) -> void:
	interactable.closest.emit(self)


## Emits [signal Interactable2D.not_closest] when an [Interactable2D] is no longer the closest one to the [Interactor].
func not_closest(interactable: Interactable2D) -> void:
	interactable.not_closest.emit(self)
