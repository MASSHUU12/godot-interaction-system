@tool
extends Interactor2D

class_name CharacterBody2DInteractor

## The name of the input action to be used to interact with [Interactable2D]. [br]
## Check [color=#76B6E0]
## [url=https://docs.godotengine.org/en/stable/tutorials/inputs/input_examples.html#inputmap]docs[/url]
## [/color] how to create one.
@export var action_name: String = "":
	set(p_action_name):
		if p_action_name != "":
			action_name = p_action_name
			update_configuration_warnings()

@export_group("Ray Cast 2D")
## Blocks the ability of [RayCast2D] to send an [signal Interactable2D.interacted] [Signal].
@export var disable_interaction_for_ray_cast: bool = false

@export_group("Area 2D")
## Allows [signal Interactable2D.interacted] [Signal] to be emitted through [Area3D].
@export var use_area_2d_to_interact: bool = false

## Allows to adjust the moment when the [signal Interactable2D.interacted] [Signal] is emitted. [br][br]
## [b]Collision[/b]: The interaction signal is emitted when [Interactable2D] starts to collide with [Area2D]. [br][br]
## [b]Input Action[/b]: The interaction signal is emitted when [Interactable2D] collides with [Area2D]
## and the user presses the button responsible for the interaction.
@export_enum("Collision", "Input Action") var interaction_on: int = 0

var cached_closest: Interactable2D
var cached_raycasted: Interactable2D


func _get_configuration_warnings() -> PackedStringArray:
	var warnings = []

	warnings.append_array(super())

	if action_name == "":
		warnings.append("Action Name must not be empty, provide the name of the interaction that will be used.")

	return warnings


func _physics_process(_delta: float) -> void:
	# Run only in game
	if not Engine.is_editor_hint():
		check_ray_cast()
		check_area()


## Checks if [RayCast2D] collide with [Interactable2D].
func check_ray_cast() -> void:
	if ray_cast == null:
		return

	var new_raycasted: Interactable2D = get_raycasted_interactable()

	if new_raycasted == cached_raycasted:
		return

	if is_instance_valid(cached_raycasted):
		unfocus(cached_raycasted)
	if new_raycasted:
		focus(new_raycasted)

	cached_raycasted = new_raycasted


## Checks if [Area2D] collide with [Interactable2D].
func check_area() -> void:
	if area == null:
		return

	var new_closest: Interactable2D = get_closest_interactable()

	if new_closest == cached_closest:
		return;

	if is_instance_valid(cached_closest):
		not_closest(cached_closest)
	if new_closest:
		closest(new_closest)

		if use_area_2d_to_interact and interaction_on == 0:
			interact(new_closest)

	cached_closest = new_closest


func _input(event: InputEvent) -> void:
	if event.is_action_pressed(action_name):
		if cached_raycasted and not disable_interaction_for_ray_cast:
			interact(cached_raycasted)

		if cached_closest and use_area_2d_to_interact and interaction_on == 1:
			interact(cached_closest)
