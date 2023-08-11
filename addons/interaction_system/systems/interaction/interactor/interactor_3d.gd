@tool
extends Interactor

## [Interactor] adjusted for 3D.
class_name Interactor3D

## [RayCast3D] node used to interact with [Interactable].
## [br][br]
## Emits [Signal]s: [br]
## [signal Interactable.interacted][br]
## [signal Interactable.focused][br]
## [signal Interactable.unfocused]
@export var ray_cast: RayCast3D = null:
	set(p_ray_cast):
		if p_ray_cast != ray_cast:
			ray_cast = p_ray_cast
			update_configuration_warnings()

## [Area3D] node used to interact with [Interactable].
## [br][br]
## Emits [Signal]s: [br]
## [signal Interactable.closest][br]
## [signal Interactable.not_closest]
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


## Returns the closes overlapping [Interactable] or null if there is no one.
func get_closest_interactable() -> Interactable:
	var list: Array[Area3D] = area.get_overlapping_areas()
	var distance: float
	var closest_distance: float = INF
	var closest_interactable: Interactable = null

	for interactable in list:
		distance = interactable.global_position.distance_to(self.global_position)

		# Sets the first interactable in the list as closest
		if distance < closest_distance:
			closest_interactable = interactable as Interactable
			closest_distance = distance

	return closest_interactable


## Returns the overlapping [Interactable] or null if there is no one.
func get_raycasted_interactable() -> Interactable:
	var collider: Area3D  = ray_cast.get_collider()
	return collider as Interactable if collider else null