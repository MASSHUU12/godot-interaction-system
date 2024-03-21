extends Area3D

@export var interacted_bg_color: Color
@export var interacted_bg_color_2: Color

@onready var interactable: Node = %Interactable3D
@onready var mesh_instance: MeshInstance3D = %MeshInstance3D

var default_bg_color: Color
var default_bg_color2: Color

func _ready() -> void:
	var material := mesh_instance.mesh.surface_get_material(0) as ShaderMaterial
	default_bg_color = material.get_shader_parameter("background_color")
	default_bg_color2 = material.get_shader_parameter("background_color_two")

	interactable.connect("Interacted", on_interacted)
	interactable.connect("LongInteracted", on_long_interacted)

func on_interacted(_interactor: Node) -> void:
	var material := mesh_instance.mesh.surface_get_material(0) as ShaderMaterial
	var current_bg: Color = material.get_shader_parameter("background_color")
	var current_bg2: Color = material.get_shader_parameter("background_color_two")

	material.set_shader_parameter("background_color", default_bg_color if current_bg == interacted_bg_color else interacted_bg_color)
	material.set_shader_parameter("background_color_two", default_bg_color2 if current_bg2 == interacted_bg_color_2 else interacted_bg_color_2)

func on_long_interacted(_interactor: Node) -> void:
	mesh_instance.rotate_z(PI / 4)
