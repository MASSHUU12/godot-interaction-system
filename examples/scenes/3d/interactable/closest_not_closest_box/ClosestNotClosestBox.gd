extends Interactable3D

@onready var text: Label3D = $Text
@onready var mesh_instance_3d: MeshInstance3D = $MeshInstance3D
@onready var material: Resource = preload("res://examples/assets/materials/InteractableMaterial.tres").duplicate()


func _ready() -> void:
	mesh_instance_3d.material_override = material


func _on_closest(_interactor: Interactor3D) -> void:
	text.text = "Closest"
	material.albedo_color = Color("red")


func _on_not_closest(_interactor: Interactor3D) -> void:
	text.text = "Not closest"
	material.albedo_color = Color("white")


func _on_interacted(_interactor: Interactor3D) -> void:
	text.text = "Interacted"
	mesh_instance_3d.rotate_z(45)
