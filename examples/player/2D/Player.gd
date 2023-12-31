extends CharacterBody2D

@onready var ray_cast_2d: RayCast2D = $RayCast2D

const SPEED = 300.0
const JUMP_VELOCITY = -400.0

# Get the gravity from the project settings to be synced with RigidBody nodes.
var gravity: int = ProjectSettings.get_setting("physics/2d/default_gravity")


func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity.y += gravity * delta

	# Handle Jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = JUMP_VELOCITY

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction := Input.get_axis("player_move_left", "player_move_right")
	if direction:
		velocity.x = direction * SPEED
		ray_cast_2d.rotation_degrees = 180 if direction == -1 else 0
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	move_and_slide()
