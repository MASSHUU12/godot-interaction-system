@tool
extends Interactable

class_name InteractableProp

@export var use_highlighter: bool = false

@onready var outline_shader: ShaderMaterial = preload("res://addons/godot_interaction/assets/shaders/outline.tres").duplicate()
@onready var higlighter_shader: ShaderMaterial = preload("res://addons/godot_interaction/assets/shaders/item_highlighter.tres")

var outline_width

@export var mesh_instance_3d: MeshInstance3D = null:
	set(p_mesh_instance_3d):
		if p_mesh_instance_3d != mesh_instance_3d:
			mesh_instance_3d = p_mesh_instance_3d
			update_configuration_warnings()


func _get_configuration_warnings() -> PackedStringArray:
	var warnings = []

	if mesh_instance_3d == null:
		warnings.append("This node does not have the ability to display shaders, add MeshInstance3D to the appropriate field.")
	elif mesh_instance_3d.mesh == null:
		warnings.append("MeshInstance3D does not have the mesh, please add one.")
	elif mesh_instance_3d.mesh.material == null:
		warnings.append("MeshInstance3D does not have the material, please add one.")

	return warnings


func _ready() -> void:
	outline_width = outline_shader.get_shader_parameter("outline_width")

	if use_highlighter:
		outline_shader.next_pass = higlighter_shader
		unfocus()

	self.interacted.connect(_on_interactable_prop_interacted)
	self.closest.connect(_on_interactable_prop_closest)
	self.not_closest.connect(_on_interactable_prop_not_closest)
	self.focused.connect(_on_interactable_prop_focused)
	self.unfocused.connect(_on_interactable_prop_unfocused)


func unfocus() -> void:
	outline_shader.set_shader_parameter("outline_width", 0.0)
	set_next_pass()


func set_next_pass() -> void:
	if mesh_instance_3d.get_active_material(0):
		mesh_instance_3d.mesh.material.next_pass = outline_shader


func _on_interactable_prop_interacted(interactor: Interactor) -> void:
	_interacted(interactor)


func _on_interactable_prop_closest(interactor: Interactor) -> void:
	_closest(interactor)


func _on_interactable_prop_not_closest(interactor: Interactor) -> void:
	_not_closest(interactor)


func _on_interactable_prop_focused(interactor: Interactor) -> void:
	outline_shader.set_shader_parameter("outline_width", outline_width)
	set_next_pass()
	_focused(interactor)


func _on_interactable_prop_unfocused(interactor: Interactor) -> void:
	unfocus()
	_unfocused(interactor)


func _interacted(_interactor: Interactor) -> void:
	pass


func _closest(_interactor: Interactor) -> void:
	pass


func _not_closest(_interactor: Interactor) -> void:
	pass


func _focused(_interactor: Interactor) -> void:
	pass


func _unfocused(_interactor: Interactor) -> void:
	pass
