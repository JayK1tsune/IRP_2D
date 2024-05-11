extends Node

func _on_area_2d_body_entered(body):
	if body.is_in_group("Player"):
		print ("Player entrerd water")


func _on_area_2d_body_exited(body):
	if body.is_in_group("Player"):
		print ("Player has left water")


func _on_area_2d_2_body_entered(body):
	if body.is_in_group("Player"):
		print ("Player entrerd water")
