@tool
extends Interactable3D

class_name InteractableProp

## [MeshInstance3D] used to display highlighter and outline.
@export var mesh_instance_3d: MeshInstance3D = null:
	set(p_mesh_instance_3d):
		if p_mesh_instance_3d != mesh_instance_3d:
			mesh_instance_3d = p_mesh_instance_3d
			update_configuration_warnings()

@export_group("Outline")
## Indicates whether the outline is to be used.
@export var use_outline: bool = true

@export_group("Highlighter")
## Indicates whether the highlighter is to be used.
@export var use_highlighter: bool = false
## Customize when the highlighter should work: [br][br]
## [b]Always[/b]: Highlighter will always work. [br][br]
## [b]Closest[/b]: Highlighter will only work if the object is closest to the player.
@export_enum("Always", "Closest") var highlight_when: int = 0

@onready var outline_shader: ShaderMaterial = preload("res://addons/interaction_system/assets/shaders/outline.tres").duplicate()
@onready var higlighter_shader: ShaderMaterial = preload("res://addons/interaction_system/assets/shaders/item_highlighter.tres")

var outline_width


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
	self.interacted.connect(_on_interactable_prop_interacted)
	self.closest.connect(_on_interactable_prop_closest)
	self.not_closest.connect(_on_interactable_prop_not_closest)
	self.focused.connect(_on_interactable_prop_focused)
	self.unfocused.connect(_on_interactable_prop_unfocused)

	outline_width = outline_shader.get_shader_parameter("outline_width")

	if highlight_when == 0:
		show_highlighter()
	hide_outline()


func update_shaders() -> void:
	if not mesh_instance_3d.get_active_material(0):
		return

	mesh_instance_3d.mesh.material.next_pass = outline_shader


func show_outline() -> void:
	if use_outline:
		outline_shader.set_shader_parameter("outline_width", outline_width)
		update_shaders()


func hide_outline() -> void:
	outline_shader.set_shader_parameter("outline_width", 0.0)
	update_shaders()


func show_highlighter() -> void:
	if use_highlighter and use_outline:
		outline_shader.next_pass = higlighter_shader
		update_shaders()


func hide_highlighter() -> void:
	outline_shader.next_pass = null
	update_shaders()


func _on_interactable_prop_interacted(interactor: Interactor3D) -> void:
	_interacted(interactor)


func _on_interactable_prop_closest(interactor: Interactor3D) -> void:
	if highlight_when == 1:
		show_highlighter()
	_closest(interactor)


func _on_interactable_prop_not_closest(interactor: Interactor3D) -> void:
	if highlight_when == 1:
		hide_highlighter()
	_not_closest(interactor)


func _on_interactable_prop_focused(interactor: Interactor3D) -> void:
	show_outline()
	_focused(interactor)


func _on_interactable_prop_unfocused(interactor: Interactor3D) -> void:
	hide_outline()
	_unfocused(interactor)


## [b]Overridable method.[/b] [br]
## It will run when [Interactor3D] interacts with this object.
func _interacted(_interactor: Interactor3D) -> void:
	pass


## [b]Overridable method.[/b] [br]
## It will run when this object is the closest one to the [Interactor3D].
func _closest(_interactor: Interactor3D) -> void:
	pass


## [b]Overridable method.[/b] [br]
## It will run when this object is no longer the closest one to the [Interactor3D].
func _not_closest(_interactor: Interactor3D) -> void:
	pass


## [b]Overridable method.[/b] [br]
## It will run when [Interactor3D] hovers over this object.
func _focused(_interactor: Interactor3D) -> void:
	pass


## [b]Overridable method.[/b] [br]
## It will run when [Interactor3D] stops focusing this object.
func _unfocused(_interactor: Interactor3D) -> void:
	pass
