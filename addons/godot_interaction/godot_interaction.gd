@tool
extends EditorPlugin


func _enter_tree() -> void:
	add_custom_type("Interactor", "Node3D", preload("./systems/interaction/interactor.gd"), preload("res://icon.svg"))


func _exit_tree() -> void:
	remove_custom_type("Interactor")
