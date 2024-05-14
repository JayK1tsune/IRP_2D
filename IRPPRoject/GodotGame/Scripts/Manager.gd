extends Node
const LEVEL_1 = preload("res://GodotGame/Levels/Level_1.tscn")
const PAUSE_MENU = preload("res://GodotGame/UI/PauseMenu.tscn")
const MAIN_MENU = preload("res://GodotGame/UI/Main_Menu.tscn")
var player


# Called when the node enters the scene tree for the first time.
func _ready():
	RenderingServer.set_default_clear_color(Color(0.44,0.22,0.53,1.00))
	var file = FileAccess.open("res://savegame.data",FileAccess.READ)
	player = get_tree().get_root().find_child("Player")
	if player != null:
			player.global_position = file.get_var()
			file.close()




func start_game():
	if get_tree().paused:
		continue_game()
		return
	
	transition_to_screne(LEVEL_1.resource_path)
	
func exit_game():
	get_tree().quit()	

func pause_game():
	get_tree().paused = true
	
	var pause_screen_screen_instance = PAUSE_MENU.instantiate()
	get_tree().get_root().add_child(pause_screen_screen_instance)

func continue_game():
	get_tree().paused = false

func main_menu():
	var main_menu_screen_instance = MAIN_MENU.instantiate()
	get_tree().get_root().add_child(main_menu_screen_instance)

func transition_to_screne(scene_path):
	await get_tree().create_timer(0.5).timeout
	get_tree().change_scene_to_file(scene_path)
