extends Control

@onready var timer: Timer = $Timer
@onready var character_interactor_3d: Node3D = $"../CharacterInteractor3D"

@onready var interaction_label: Label = $MarginContainer/PanelContainer/MarginContainer/VBoxContainer/InteractionLabel
@onready var focus_label: Label = $MarginContainer/PanelContainer/MarginContainer/VBoxContainer/FocusLabel
@onready var closest_label: Label = $MarginContainer/PanelContainer/MarginContainer/VBoxContainer/ClosestLabel


func _ready() -> void:
	timer.connect("timeout", _on_timer_timeout)
	character_interactor_3d.connect("UnfocusedInteractable", _on_character_interactor_3d_unfocused_interactable)
	character_interactor_3d.connect("ClosestToInteractable", _on_character_interactor_3d_closest_to_interactable)
	character_interactor_3d.connect("FocusedOnInteractable", _on_character_interactor_3d_focused_on_interactable)
	character_interactor_3d.connect("NotClosestToInteractable", _on_character_interactor_3d_not_closest_to_interactable)
	character_interactor_3d.connect("InteractedWithInteractable", _on_character_interactor_3d_interacted_with_interactable)


func _on_character_interactor_3d_interacted_with_interactable(interactable: Node3D) -> void:
	interaction_label.text = "Interacting with: " + str(interactable)
	timer.start()


func _on_character_interactor_3d_focused_on_interactable(interactable: Node3D) -> void:
	focus_label.text = "Focusing on: " + str(interactable)


func _on_character_interactor_3d_unfocused_interactable(_interactable: Node3D) -> void:
	focus_label.text = "Focusing on: none"


func _on_character_interactor_3d_closest_to_interactable(interactable: Node3D) -> void:
	closest_label.text = "Closest to: " + str(interactable)


func _on_character_interactor_3d_not_closest_to_interactable(_interactable: Node3D) -> void:
	closest_label.text = "Closest to: none"


func _on_timer_timeout() -> void:
	interaction_label.text = "Interacting with: none"
