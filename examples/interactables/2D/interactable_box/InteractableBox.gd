extends Node2D


@onready var label: Label = $Label
@onready var interactable_2d: Node = $Interactable2D


func _ready() -> void:
	interactable_2d.connect("Interacted", _on_interactable_2d_interacted)
	interactable_2d.connect("Focused", _on_interactable_2d_focused)
	interactable_2d.connect("Unfocused", _on_interactable_2d_unfocused)
	interactable_2d.connect("Closest", _on_interactable_2d_closest)
	interactable_2d.connect("NotClosest", _on_interactable_2d_not_closest)


func _on_interactable_2d_interacted(_interactor: Node) -> void:
	label.text = "Interacted with the box!"


func _on_interactable_2d_closest(_interactor: Node) -> void:
	label.text = "Closest to the box!"


func _on_interactable_2d_not_closest(_interactor: Node) -> void:
	label.text = "Not closest to the box!"


func _on_interactable_2d_focused(_interactor: Node) -> void:
	label.text = "Focused on the box!"


func _on_interactable_2d_unfocused(_interactor: Node) -> void:
	label.text = "Unfocused from the box!"
