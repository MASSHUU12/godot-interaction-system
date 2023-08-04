extends Interactor

@export var action_name: String = "":
	set(p_action_name):
		if p_action_name != "":
			action_name = p_action_name
			update_configuration_warnings()

var cached_closest: Interactable
var cached_raycasted: Interactable


func _get_configuration_warnings() -> PackedStringArray:
	var warnings = []

	warnings.append_array(super._get_configuration_warnings())

	if action_name == "":
		warnings.append("Action Name must not be empty, provide the name of the interaction that will be used.")

	return warnings


func _physics_process(_delta: float) -> void:
	check_ray_cast()
	check_area_3d()


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
