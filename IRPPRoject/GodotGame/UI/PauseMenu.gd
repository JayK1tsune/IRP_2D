extends CanvasLayer


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_continue_pressed():
	Manager.continue_game()
	queue_free()

func _on_main_menu_pressed():
	Manager.main_menu()
	queue_free()

	
	
