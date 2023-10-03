extends Control

@onready var grid_container: GridContainer = $CenterContainer/PanelContainer/MarginContainer/VBoxContainer/GridContainer

const EXAMPLES_PATH := "res://scenes/examples/"


func _ready() -> void:
	Input.mouse_mode = Input.MOUSE_MODE_VISIBLE

	for child in grid_container.get_children():
		grid_container.remove_child(child)

	for file in DirAccess.get_files_at(EXAMPLES_PATH):
		var btn: Button = Button.new()
		btn.text = file.dedent().replace(".tscn", "").replace(".remap", "").capitalize()
		btn.pressed.connect(change_scene_to.bind(file.replace(".remap", "")))

		grid_container.add_child(btn)


func change_scene_to(file_name: String) -> void:
	get_tree().change_scene_to_file(EXAMPLES_PATH + file_name)
