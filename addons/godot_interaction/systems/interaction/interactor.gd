@tool
extends Node3D

class_name Interactor

var controller: Node3D

@export var ray_cast_3d: RayCast3D = null:
	set(p_ray_cast_3d):
		if p_ray_cast_3d != ray_cast_3d:
			ray_cast_3d = p_ray_cast_3d
			update_configuration_warnings()

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


func get_raycasted_interactable() -> Interactable:
	var collider: Area3D  = ray_cast_3d.get_collider()
	return collider as Interactable if collider else null
