@tool
extends Interactor

## A specialized class tailored for [CharacterBody3D], it simplifies the process of creating a player character.
class_name CharacterBody3DInteractor

## The name of the input action to be used to interact with [Interactable]. [br]
## Check [color=#76B6E0][url=https://docs.godotengine.org/en/stable/tutorials/inputs/input_examples.html#inputmap]docs[/url][/color] how to create one.
@export var action_name: String = "":
	set(p_action_name):
		if p_action_name != "":
			action_name = p_action_name
			update_configuration_warnings()

@export var use_area_3d_to_interact: bool = false

@export var disable_interaction_via_ray_cast_3d: bool = false

var cached_closest: Interactable
var cached_raycasted: Interactable


func _get_configuration_warnings() -> PackedStringArray:
	var warnings = []

	warnings.append_array(super())

	if action_name == "":
		warnings.append("Action Name must not be empty, provide the name of the interaction that will be used.")

	return warnings


func _physics_process(_delta: float) -> void:
	check_ray_cast()
	check_area_3d()


## Checks if [RayCast3D] collide with [Interactable].
func check_ray_cast() -> void:
	if ray_cast_3d == null:
		return

	var new_raycasted: Interactable = get_raycasted_interactable()

	if new_raycasted != cached_raycasted:
		if is_instance_valid(cached_raycasted):
			unfocus(cached_raycasted)
		if new_raycasted:
			focus(new_raycasted)

		cached_raycasted = new_raycasted


## Checks if [Area3D] collide with [Interactable].
func check_area_3d() -> void:
	if area_3d == null:
		return

	var new_closest: Interactable = get_closest_interactable()

	if new_closest != cached_closest:
		if is_instance_valid(cached_closest):
			not_closest(cached_closest)
		if new_closest:
			closest(new_closest)

		cached_closest = new_closest


func _input(event: InputEvent) -> void:
	if event.is_action_pressed(action_name):
		if cached_raycasted:
			interact(cached_raycasted)
