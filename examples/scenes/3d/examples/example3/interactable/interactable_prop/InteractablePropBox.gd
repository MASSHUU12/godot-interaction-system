extends InteractableProp

@onready var text: Label3D = $Text


func _focused(_interactor: Interactor3D) -> void:
	text.text = "Focused"


func _unfocused(_interactor: Interactor3D) -> void:
	text.text = "Unfocused"


func _interacted(_interactor: Interactor3D) -> void:
	text.text = "Interacted"
	mesh_instance_3d.rotate_z(45)
