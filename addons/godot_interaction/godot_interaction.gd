@tool
extends EditorPlugin


func _enter_tree() -> void:
	add_custom_type("Interactor", "Node3D", preload("./systems/interaction/interactor.gd"), preload("res://icon.png"))
	add_custom_type("CharacterBody3DInteractor", "Interactor", preload("./systems/interaction/character_body_3d_interactor/character_body_3d_interactor.gd"), preload("res://icon.png"))
	add_custom_type("Interactable", "Area3D", preload("./systems/interaction/interactable.gd"), preload("res://icon.png"))
	add_custom_type("InteractableProp", "InteractableProp", preload("res://addons/godot_interaction/systems/interaction/interactable_prop/interactable_prop.gd"), preload("res://icon.png"))


func _exit_tree() -> void:
	remove_custom_type("Interactor")
	remove_custom_type("CharacterBody3DInteractor")
	remove_custom_type("Interactable")
	remove_custom_type("InteractableProp")
