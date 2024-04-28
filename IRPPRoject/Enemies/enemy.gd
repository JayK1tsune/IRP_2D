extends CharacterBody2D

@onready var animated_sprite_2d = $AnimatedSprite2D
@export var patrol_points : Node
@export var SPEED = 800.0
@onready var timer = $Timer
@export var waiting_time: int = 3
const JUMP_VELOCITY = -400.0

#Animations states
enum State { Idle, Walking}
var current_state : State
var direction : Vector2 = Vector2.LEFT
var number_of_points : int
var point_positions : Array[Vector2]
var current_point : Vector2
var current_point_position : int
var can_walk : bool
# Get the gravity from the project settings to be synced with RigidBody nodes.
var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

func _ready():
	if patrol_points != null:
		number_of_points = patrol_points.get_child_count()
		for point in  patrol_points.get_children():
			point_positions.append(point.global_position)
		current_point = point_positions[current_point_position]
	else:
		print("No Patrol Points Found")
		
	timer.wait_time = waiting_time
	current_state = State.Idle
	
func _physics_process(delta):
	current_state = State.Idle
	enemy_gravity(delta)
	enemy_idle(delta)
	enemy_walk(delta)
	move_and_slide()
	
	enemy_animations()
	print("State: ", State.keys()[current_state])

func enemy_gravity(delta : float):
	velocity.y += gravity * delta

func enemy_idle(delta : float):
	if !can_walk:
		velocity.x = move_toward(velocity.x, 0, SPEED * delta)
		current_state = State.Idle
		
	
func enemy_walk(delta : float):
	if !can_walk:
		return
	
	if abs(position.x - current_point.x) > 0.5:
		velocity.x = direction.x * SPEED * delta
		current_state = State.Walking
		
	else:
		current_point_position += 1
		
		if current_point_position >= number_of_points:
			current_point_position = 0
		
		current_point = point_positions[current_point_position]
		
		if current_point.x > position.x:
			direction = Vector2.RIGHT
		else:
			direction = Vector2.LEFT
		
		can_walk = false
		timer.start()
		await timer.timeout
			
		
	animated_sprite_2d.flip_h = direction.x < 0 
	
func enemy_animations():
	if current_state == State.Idle && !can_walk:
		animated_sprite_2d.play("Idle")
	elif current_state == State.Walking && can_walk:
		animated_sprite_2d.play("Walking")


func _on_timer_timeout():
	can_walk = true
