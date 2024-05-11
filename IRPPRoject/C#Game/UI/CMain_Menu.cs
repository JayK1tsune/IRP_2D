using Godot;
using System;

public partial class CMain_Menu : CanvasLayer
{
	public void _on_play_pressed(){
		C_Manager.Instance.StartGame();
		GD.Print("Play");
		QueueFree();
	}
	public void _on_exit_pressed(){
		C_Manager.Instance.ExitGame();
		GD.Print("Exit");
		QueueFree();
	}
	
}
