extends Node

@export var node_finate_state_machine : NodeFiniteStateMachine


func _on_attack_area_body_entered(body : Node2D):
	if body.is_in_group("Player"):
		node_finate_state_machine.transition_to("attack")
		print("Player Entered")


func _on_attack_area_body_exited(body):
	if body.is_in_group("Player"):
		print("Player left")
		node_finate_state_machine.transition_to("idle")
