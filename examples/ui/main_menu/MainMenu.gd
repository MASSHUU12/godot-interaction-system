extends Node2D


func _on_exit_pressed() -> void:
	get_tree().quit()


func _on_3d_example_1_pressed() -> void:
	get_tree().change_scene_to_file("res://examples/scenes/3d/examples/example1/Example1.tscn")


func _on_3d_example_2_pressed() -> void:
	get_tree().change_scene_to_file("res://examples/scenes/3d/examples/example2/Example2.tscn")


func _on_3d_example_3_pressed() -> void:
	get_tree().change_scene_to_file("res://examples/scenes/3d/examples/example3/Example3.tscn")


func _on_2d_example_1_pressed() -> void:
	get_tree().change_scene_to_file("res://examples/scenes/2d/example1/Example1.tscn")
