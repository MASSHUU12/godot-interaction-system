@tool
extends Area3D

class_name Interactor

@onready var ray_cast_3d: RayCast3D = $RayCast3D

var controller: Node3D


func interact(interactable: Interactable) -> void:
	interactable.interacted.emit(self)

func focus(interactable: Interactable) -> void:
	interactable.focused.emit(self)


func unfocus(interactable: Interactable) -> void:
	interactable.unfocused.emit(self)


func closest(interactable: Interactable) -> void:
	interactable.closest.emit(self)


func not_closest(interactable: Interactable) -> void:
	interactable.not_closest.emit(self)


# Returns the closes overlapping Interactable or null if there is not one
func get_closest_interactable() -> Interactable:
	var list: Array[Area3D] = get_overlapping_areas()
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


func get_raycasted_interactable() -> Interactable:
	var collider: Area3D  = ray_cast_3d.get_collider()
	return collider as Interactable if collider else null
