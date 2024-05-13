extends Node


func _notification(what):
	if what == MainLoop.NOTIFICATION_APPLICATION_FOCUS_OUT :
		Manager.hasSaved = 0
		
