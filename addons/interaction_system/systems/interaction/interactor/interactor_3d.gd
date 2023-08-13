@tool
extends Node3D

## Class, used to interact with [Interactable3D].
class_name Interactor3D

## See [method Interactor3D.interact].
signal interacted_with_interactable(interactable: Interactable3D)
## See [method Interactor3D.focus].
signal focused_on_interactable(interactable: Interactable3D)
## See [method Interactor3D.unfocus].
signal unfocused_interactable(interactable: Interactable3D)
## See [method Interactor3D.closest].
signal closest_interactable(interactable: Interactable3D)
## See [method Interactor3D.not_closest].
signal not_closest_interactable(interactable: Interactable3D)

## [RayCast3D] node used to interact with [Interactable3D].
## [br][br]
## Emits [Signal]s: [br]
## [signal Interactable3D.interacted][br]
## [signal Interactable3D.focused][br]
## [signal Interactable3D.unfocused]
@export var ray_cast: RayCast3D = null:
	set(p_ray_cast):
		if p_ray_cast != ray_cast:
			ray_cast = p_ray_cast
			update_configuration_warnings()

## [Area3D] node used to interact with [Interactable3D].
## [br][br]
## Emits [Signal]s: [br]
## [signal Interactable3D.closest][br]
## [signal Interactable3D.not_closest]
@export var area: Area3D = null:
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


## Returns the closes overlapping [Interactable3D] or null if there is no one.
func get_closest_interactable() -> Interactable3D:
	var list: Array[Area3D] = area.get_overlapping_areas()
	var distance: float
	var closest_distance: float = INF
	var closest_interactable: Interactable3D = null

	for interactable in list:
		distance = interactable.global_position.distance_to(global_position)

		# Sets the first Interactable3D in the list as closest.
		if distance < closest_distance:
			closest_interactable = interactable as Interactable3D
			closest_distance = distance

	return closest_interactable


## Returns the overlapping [Interactable3D] or null if there is no one.
func get_raycasted_interactable() -> Interactable3D:
	var collider: Area3D  = ray_cast.get_collider()
	return collider as Interactable3D if collider else null


## Emits [signal Interactable3D.interacted] and [signal Interactor3D.interacted_with_interactable]
## when an [Interactor3D] interacts with an [Interactable3D].
func interact(interactable: Interactable3D) -> void:
	interactable.interacted.emit(self)
	interacted_with_interactable.emit(interactable)


## Emits [signal Interactable3D.focused] and [signal Interactor3D.focused_on_interactable]
## when an [Interactor3D] starts looking at [Interactable3D].
func focus(interactable: Interactable3D) -> void:
	interactable.focused.emit(self)
	focused_on_interactable.emit(interactable)


## Emits [signal Interactable3D.unfocused] and [signal Interactor3D.unfocused_interactable]
## when an [Interactor3D] stops looking at [Interactable3D].
func unfocus(interactable: Interactable3D) -> void:
	interactable.unfocused.emit(self)
	unfocused_interactable.emit(interactable)


## Emits [signal Interactable3D.closest] and [signal Interactable3D.closest_interactable]
## when an [Interactable3D] is the closest to the [Interactor3D].
func closest(interactable: Interactable3D) -> void:
	interactable.closest.emit(self)
	closest_interactable.emit(interactable)


## Emits [signal Interactable3D.not_closest] and [signal Interactable3D.not_closest_interactable]
## when an [Interactable3D] is no longer the closest one to the [Interactor3D].
func not_closest(interactable: Interactable3D) -> void:
	interactable.not_closest.emit(self)
	not_closest_interactable.emit(interactable)
