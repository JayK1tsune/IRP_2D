using Godot;
using System;

public partial class CPauseMenu : CanvasLayer
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_continue_pressed()
	{
		C_Manager.Instance.ContinueGame();
		GD.Print("Continue");
		QueueFree();

	}

	public void _on_main_menu_pressed()
	{
		C_Manager.Instance.MainMenu();
		GD.Print("Main Menu");
		QueueFree();
	}
}
