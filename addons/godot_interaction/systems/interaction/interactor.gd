@tool
extends Node3D

## Basic class, used to interact with [Interactable].
class_name Interactor

## [RayCast3D] node used to interact with [Interactable].
## [br][br]
## Emits [Signal]s: [br]
## [signal Interactable.interacted][br]
## [signal Interactable.focused][br]
## [signal Interactable.unfocused]
@export var ray_cast_3d: RayCast3D = null:
	set(p_ray_cast_3d):
		if p_ray_cast_3d != ray_cast_3d:
			ray_cast_3d = p_ray_cast_3d
			update_configuration_warnings()

## [Area3D] node used to interact with [Interactable].
## [br][br]
## Emits [Signal]s: [br]
## [signal Interactable.closest][br]
## [signal Interactable.not_closest]
@export var area_3d: Area3D = null:
	set(p_area_3d):
		if p_area_3d != area_3d:
			area_3d = p_area_3d
			update_configuration_warnings()


func _get_configuration_warnings() -> PackedStringArray:
	var warnings = []

	if ray_cast_3d == null and area_3d == null:
		warnings.append("This node does not have the ability to interact with the world, add RayCast3D or Area3D (can be both) to the appropriate fields.")

	return warnings


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


## Returns the closes overlapping [Interactable] or null if there is no one.
func get_closest_interactable() -> Interactable:
	var list: Array[Area3D] = area_3d.get_overlapping_areas()
	var distance: float
	var closest_distance: float = INF
	var closest_interactable: Interactable = null

	for interactable in list:
		distance = interactable.global_position.distance_to(global_position)

		# Sets the first interactable in the list as closest
		if distance < closest_distance:
			closest_interactable = interactable as Interactable
			closest_distance = distance

	return closest_interactable


## Returns the overlapping [Interactable] or null if there is no one.
func get_raycasted_interactable() -> Interactable:
	var collider: Area3D  = ray_cast_3d.get_collider()
	return collider as Interactable if collider else null
