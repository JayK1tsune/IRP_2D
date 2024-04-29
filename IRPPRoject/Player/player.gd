extends CharacterBody2D
@onready var animated_sprite_2d = $AnimatedSprite2D

var GRAVITY = ProjectSettings.get_setting("physics/2d/default_gravity")
@export var speed : int = 300
@export var max_horizontal_speed : int = 300
@export var slow_down_speed : int = 1000
@export var jump : int = -400.0
@export var jump_horizontal_speed : int = 1000
@export var max_jump_horizontal_speed : int = 300
var was_moving_up = false

enum State{Idle, Run, Jump, Falling, Landing}
#making Current_state a type state
var current_state : State

func _ready():
	current_state = State.Idle

func _physics_process(delta : float):
	player_failing(delta)
	player_idle(delta)
	player_run(delta)
	player_jump(delta)
	player_falling(delta)
	player_Landed(delta)
	move_and_slide()
	
	player_animations()
	#print("State: ", State.keys()[current_state])
	

	
func player_failing(delta : float):
	if !is_on_floor():
		velocity.y += GRAVITY * delta
		
func player_idle(delta : float):
	if is_on_floor():
		current_state = State.Idle
		
func player_run(delta : float):
	if !is_on_floor():
		return
	var direction = input_movement()
	
	if direction:
		velocity.x += direction * speed * delta
		velocity.x = clamp(velocity.x, -max_horizontal_speed, max_horizontal_speed)
	else:
		velocity.x = move_toward(velocity.x, 0, slow_down_speed * delta)
	if direction != 0:
		current_state = State.Run
		animated_sprite_2d.flip_h = false if direction > 0 else true


func player_jump(delta : float):
	if Input.is_action_just_pressed("jump"):
		velocity.y = jump
		current_state = State.Jump
	if !is_on_floor() and current_state == State.Jump:
		var direction = input_movement()
		velocity.x += direction * jump_horizontal_speed * delta
		velocity.x = clamp(velocity.x, -max_jump_horizontal_speed, max_jump_horizontal_speed)
		
func player_falling(delta : float):
	if velocity.y > 0 and not was_moving_up:
		current_state = State.Falling
	elif velocity.y > 0:
		was_moving_up = true

func player_animations():
	if current_state == State.Idle:
		animated_sprite_2d.play("Idle")
	elif current_state == State.Run:
		animated_sprite_2d.play("Run")
	elif  current_state == State.Jump:
		animated_sprite_2d.play("Jump")
	elif  current_state == State.Falling:
		animated_sprite_2d.play("Falling")
	elif  current_state == State.Landing:
		animated_sprite_2d.play("Landing")

	
func player_Landed(delta : float):
	if is_on_floor() and current_state == State.Falling:
		current_state = State.Landing

func input_movement():
	var direction : float = Input.get_axis("move_left","move_right")
	
	return direction
 



