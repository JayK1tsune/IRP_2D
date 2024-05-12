using Godot;
using System;

public partial class Cgame_screen : CanvasLayer
{
	private Label collectibleLabel;
	[Export]
	public CheckButton checkButton;
	//preload c# game screen
	private PackedScene CgameScreen = GD.Load<PackedScene>("res://C#Game/Levels/C#Level_1.tscn");
	//preload gdscript game screen
	private PackedScene GDgameScreen = GD.Load<PackedScene>("res://GodotGame/Levels/Level_1.tscn");
	private bool isCSharpLevelLoaded  = true;
    private bool isGdScriptLevelLoaded = false;

	public override void _Ready()
	{
		checkButton = GetNode<CheckButton>("Control/CheckButton");
		collectibleLabel = GetNode<Label>("MarginContainer/VBoxContainer/HBoxContainer/CollectibleLabel");
		C_CollectiblesManager.Instance.CollectibleAwardReceived += OnCollectibleAwardReceived;
		
	}

	public void OnCollectibleAwardReceived(int totalAward)
	{
		collectibleLabel.Text = totalAward.ToString();
	}

	private void _on_pause_texture_button_pressed()
	{
		C_Manager.Instance.PauseGame();
		GD.Print("Pause Button Pressed");
	}

	public void _on_check_button_pressed()
	{


	}

	public void _on_check_button_toggled(bool buttonPressed)
	{
		if (buttonPressed)
		{
            GetTree().ChangeSceneToPacked(GDgameScreen);

		}

	}
}
