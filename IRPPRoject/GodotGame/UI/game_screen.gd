extends CanvasLayer
@onready var collectible_label = $MarginContainer/VBoxContainer/HBoxContainer/CollectibleLabel
const C_LEVEL_1 = preload("res://C#Game/Levels/C#Level_1.tscn")
const GDgameScreen = preload("res://GodotGame/Levels/Level_1.tscn")
var CInstance = null
var isCSceneInstatiated = false
var isGDLevelLoaded = false
var isSaved = false
@onready var player = %Player
var collectibleLabel


# Called when the node enters the scene tree for the first time.
func _ready():
	#ar cgameScreen = get_node("res://C#Game/UI/C#game_screen.tscn")
	#cgameScreen.connect("scoreupdate",_on_level_changed)
	CollectiableManager.on_collectible_award_received.connect(on_collectible_award_received)


func on_collectible_award_received(total_award : int):
	collectible_label.text = str(total_award) 


func _on_pause_texture_button_pressed():
	Manager.pause_game()


func _on_check_button_pressed():
	$Control/CheckButton.text = "Godot"


func _on_check_button_toggled(toggled_on):
	if player != null:
		var player_posistion = player.global_position
		SaveAndLoad.save_game(player_posistion)
		#Manager.hasSaved + 1
	get_tree().change_scene_to_packed(C_LEVEL_1)
	
func _on_level_changed(totalAward: String) -> void:
	collectibleLabel.text = totalAward




