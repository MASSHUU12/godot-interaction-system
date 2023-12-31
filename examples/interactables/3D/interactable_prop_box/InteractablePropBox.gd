extends Node3D

@onready var label: Label3D = $Label3D
@onready var interactable: Node = $Interactable3D


func _ready() -> void:
	interactable.connect("Interacted", on_interactable_interacted)
	interactable.connect("Focused", on_interactable_focused)
	interactable.connect("Unfocused", on_interactable_unfocused)
	interactable.connect("Closest", on_interactable_closest)
	interactable.connect("NotClosest", on_interactable_not_closest)


func on_interactable_interacted(_interactor: Node) -> void:
	label.text = "Interacted with the box!"


func on_interactable_closest(_interactor: Node) -> void:
	label.text = "Closest to the box!"


func on_interactable_not_closest(_interactor: Node) -> void:
	label.text = "Not closest to the box!"


func on_interactable_focused(_interactor: Node) -> void:
	label.text = "Focused on the box!"


func on_interactable_unfocused(_interactor: Node) -> void:
	label.text = "Unfocused from the box!"
