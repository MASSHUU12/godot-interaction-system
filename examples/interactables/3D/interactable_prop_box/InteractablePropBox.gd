extends Node3D

@onready var label_3d: Label3D = $Label3D
@onready var interactable_prop_3d: Node = $InteractableProp3D


func _ready() -> void:
	interactable_prop_3d.connect("Interacted", _on_interactable_prop_3d_interacted)
	interactable_prop_3d.connect("Focused", _on_interactable_prop_3d_focused)
	interactable_prop_3d.connect("Unfocused", _on_interactable_prop_3d_unfocused)
	interactable_prop_3d.connect("Closest", _on_interactable_prop_3d_closest)
	interactable_prop_3d.connect("NotClosest", _on_interactable_prop_3d_not_closest)


func _on_interactable_prop_3d_interacted(_interactor: Node) -> void:
	label_3d.text = "Interacted with the box!"


func _on_interactable_prop_3d_closest(_interactor: Node) -> void:
	label_3d.text = "Closest to the box!"


func _on_interactable_prop_3d_not_closest(_interactor: Node) -> void:
	label_3d.text = "Not closest to the box!"


func _on_interactable_prop_3d_focused(_interactor: Node) -> void:
	label_3d.text = "Focused on the box!"


func _on_interactable_prop_3d_unfocused(_interactor: Node) -> void:
	label_3d.text = "Unfocused from the box!"
