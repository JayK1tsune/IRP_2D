extends Area2D


var damage_amount : int = 1

func _on_area_entered(area):
	print ("area")


func _on_body_entered(body):
	print ("body boo")


func get_dmg_amount() -> int:
	return damage_amount
