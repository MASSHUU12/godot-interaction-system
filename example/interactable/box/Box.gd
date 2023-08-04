extends Interactable

@onready var mesh_instance_3d: MeshInstance3D = $MeshInstance3D
@onready var status: Label3D = $Status


func _on_focused(_interactor: Interactor) -> void:
	mesh_instance_3d.mesh.material.albedo_color = Color("red")
	status.text = "Focused"


func _on_unfocused(_interactor: Interactor) -> void:
	mesh_instance_3d.mesh.material.albedo_color = Color("white")
	status.text = "Unfocused"


func _on_interacted(_interactor: Interactor) -> void:
	mesh_instance_3d.rotate_x(45)
	status.text = "Interacted"
