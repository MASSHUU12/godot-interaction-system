@tool
extends Node3D

class_name Interactable

@export var area_3d: Area3D = null:
	set(p_area_3d):
		if p_area_3d != area_3d:
			area_3d = p_area_3d
			update_configuration_warnings()


func _get_configuration_warnings() -> PackedStringArray:
	var warnings = []

	if area_3d == null:
		warnings.append("This node does not have the ability to interact with the world, add Area3D to the appropriate field.")

	return warnings


# Emitted when an Interactor starts looking at object
signal focused(interactor: Interactor)
# Emitted when an Interactor stops looking at object
signal unfocused(interactor: Interactor)
# Emitted when an Interactor interacts with an object
signal interacted(interactor: Interactor)
# Emitted when an object is the closest to the Interactor
signal closest(interactor: Interactor)
# Emitted when an object is no longer the closest one to the Interactor
signal not_closest(interactor: Interactor)
