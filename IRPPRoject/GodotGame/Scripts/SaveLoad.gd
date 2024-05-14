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

static func C_save_game(player_posistion: Vector2):
	var file = FileAccess.open("res://savegame.data",FileAccess.WRITE)
	file.store_var(player_posistion)
	file.close()
	print("C_Saved")

static func C_start_game():
	var player_posistion: Vector2 = Vector2(53,-39)
	return player_posistion