extends "res://addons/godot_interaction/systems/interaction/interactable_prop/interactable_prop.gd"


func _interacted(_interactor: Interactor) -> void:
	rotate_y(45)
