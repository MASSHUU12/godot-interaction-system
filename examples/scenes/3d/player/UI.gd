extends Control

@onready var timer: Timer = $Timer
@onready var focus: Label = $VBoxContainer/Focus
@onready var closest: Label = $VBoxContainer/Closest
@onready var interact: Label = $VBoxContainer/Interact


func _on_character_body_3d_interactor_focused_on_interactable(interactable: Interactable3D) -> void:
	change_focus_text(interactable)


func _on_character_body_3d_interactor_unfocused_interactable(_interactable: Interactable3D) -> void:
	change_focus_text(null)


func _on_character_body_3d_interactor_closest_interactable(interactable: Interactable3D) -> void:
	change_closest_text(interactable)


func _on_character_body_3d_interactor_not_closest_interactable(_interactable: Interactable3D) -> void:
	change_closest_text(null)


func _on_character_body_3d_interactor_interacted_with_interactable(interactable: Interactable3D) -> void:
	timer.stop()
	change_interact_text(interactable)
	timer.start()


func _on_timer_timeout() -> void:
	change_interact_text(null)


func change_focus_text(what: Interactable3D) -> void:
	focus.text = "Focused on %s." % what


func change_closest_text(what: Interactable3D) -> void:
	closest.text = "Closest to %s." % what


func change_interact_text(what: Interactable3D) -> void:
	interact.text = "Interacted with %s." % what
