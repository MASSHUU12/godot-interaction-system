extends Interactable

@onready var mesh_instance_3d: MeshInstance3D = $MeshInstance3D


func _on_focused(_interactor: Interactor) -> void:
	mesh_instance_3d.mesh.material.albedo_color = Color("red")


func _on_unfocused(_interactor: Interactor) -> void:
	mesh_instance_3d.mesh.material.albedo_color = Color("white")


func _on_interacted(_interactor: Interactor) -> void:
	mesh_instance_3d.rotate_x(45)
