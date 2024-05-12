class_name SaveAndLoad

extends Node2D


static func save_game(player_posistion: Vector2):
	var file = FileAccess.open("res://savegame.data",FileAccess.WRITE)
	file.store_var(player_posistion)
	file.close()
	print("Saved")
	
static func load_game():
	var file = FileAccess.open("res://savegame.data",FileAccess.READ)
	var player_posistion: Vector2 = file.get_var()
	file.close()
	return player_posistion
