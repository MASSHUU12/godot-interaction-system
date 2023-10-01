extends Control

@onready var character_interactor_3d: Node3D = $"../CharacterInteractor3D"


func _ready() -> void:
	character_interactor_3d.connect("UnfocusedInteractable", _on_character_interactor_3d_unfocused_interactable)
	character_interactor_3d.connect("ClosestToInteractable", _on_character_interactor_3d_closest_to_interactable)
	character_interactor_3d.connect("FocusedOnInteractable", _on_character_interactor_3d_focused_on_interactable)
	character_interactor_3d.connect("NotClosestToInteractable", _on_character_interactor_3d_not_closest_to_interactable)
	character_interactor_3d.connect("InteractedWithInteractable", _on_character_interactor_3d_interacted_with_interactable)


func _on_character_interactor_3d_closest_to_interactable(_interactable: Node3D) -> void:
	print("closest")


func _on_character_interactor_3d_focused_on_interactable(_interactable: Node3D) -> void:
	print("focused")


func _on_character_interactor_3d_interacted_with_interactable(_interactable: Node3D) -> void:
	print("interacted")


func _on_character_interactor_3d_not_closest_to_interactable(_interactable: Node3D) -> void:
	print("not closest")


func _on_character_interactor_3d_unfocused_interactable(_interactable: Node3D) -> void:
	print("unfocused")
