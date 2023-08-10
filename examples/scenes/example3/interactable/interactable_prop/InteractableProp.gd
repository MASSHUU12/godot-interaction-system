extends InteractableProp

@onready var text: Label3D = $Text


func _focused(_interactor: Interactor) -> void:
	text.text = "Focused"


func _unfocused(_interactor: Interactor) -> void:
	text.text = "Unfocused"


func _interacted(_interactor: Interactor) -> void:
	text.text = "Interacted"
	mesh_instance_3d.rotate_z(45)
