extends Interactable2D

@onready var text: Label = $Text


func _on_interacted(_interactor: Interactor2D) -> void:
	text.text = "Interacted"


func _on_closest(_interactor: Interactor2D) -> void:
	text.text = "Closest"


func _on_not_closest(_interactor: Interactor2D) -> void:
	text.text = "Not closest"
