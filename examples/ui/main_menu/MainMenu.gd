extends Node2D


func _on_exit_pressed() -> void:
	get_tree().quit()


func _on_example_1_pressed() -> void:
	get_tree().change_scene_to_file("res://examples/scenes/example1/Example1.tscn")


func _on_example_2_pressed() -> void:
	get_tree().change_scene_to_file("res://examples/scenes/example2/Example2.tscn")
