@tool
extends EditorPlugin


func _enter_tree() -> void:
	add_custom_type("Interactor3D", "Node3D", preload("./systems/interaction/interactor/interactor_3d.gd"), preload("res://icon.png"))
	add_custom_type("Interactor2D", "Node2D", preload("./systems/interaction/interactor/interactor_2d.gd"), preload("res://icon.png"))
	add_custom_type("CharacterBody3DInteractor", "Interactor3D", preload("./systems/interaction/interactor/character_body_3d_interactor.gd"), preload("res://icon.png"))
	add_custom_type("CharacterBody2DInteractor", "Interactor2D", preload("./systems/interaction/interactor/character_body_2d_interactor.gd"), preload("res://icon.png"))

	add_custom_type("Interactable3D", "Area3D", preload("./systems/interaction/interactable/interactable_3d.gd"), preload("res://icon.png"))
	add_custom_type("Interactable2D", "Area2D", preload("./systems/interaction/interactable/interactable_2d.gd"), preload("res://icon.png"))
	add_custom_type("InteractableProp", "InteractableProp", preload("./systems/interaction/interactable/interactable_prop.gd"), preload("res://icon.png"))


func _exit_tree() -> void:
	remove_custom_type("Interactor2D")
	remove_custom_type("Interactor3D")
	remove_custom_type("CharacterBody2DInteractor")
	remove_custom_type("CharacterBody3DInteractor")

	remove_custom_type("Interactable2D")
	remove_custom_type("Interactable3D")
	remove_custom_type("InteractableProp")
