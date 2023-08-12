extends Interactable2D

@onready var text: Label = $Text


func _on_interacted(_interactor: Interactor2D) -> void:
	text.text = "Interacted"


func _on_focused(_interactor: Interactor2D) -> void:
	text.text = "Focused"


func _on_unfocused(_interactor: Interactor2D) -> void:
	text.text = "Unfocused"
