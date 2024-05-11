extends Node2D

@export var link_doors : Node2D
var linked_door_position : Vector2
var player_position_before_teleport : Vector2
# Called when the node enters the scene tree for the first time.

func _ready():
	if link_doors != null:
		linked_door_position = link_doors.global_position

	
	
func _process(delta):
	pass


func _on_area_2d_body_entered(body):
	if body.is_in_group("Player"):
		var player = body as Node2D
		player_position_before_teleport = player.global_position
		await get_tree().create_timer(0.5).timeout
		teleport_to_door(player)
		
		#player.queue_free()

	
	print("Player is inside door")

func teleport_to_door(player : Node2D):
	if link_doors != null:
		player.global_position = linked_door_position
