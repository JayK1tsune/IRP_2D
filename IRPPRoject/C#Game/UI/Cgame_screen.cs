using Godot;
using System;

public partial class Cgame_screen : CanvasLayer
{
	[Export]
	private Label collectibleLabel;
	[Export]
	public CheckButton checkButton;
	//preload c# game screen
	private PackedScene CgameScreen = GD.Load<PackedScene>("res://C#Game/Levels/C#Level_1.tscn");
	//preload gdscript game screen
	private PackedScene GDgameScreen = GD.Load<PackedScene>("res://GodotGame/Levels/Level_1.tscn");
	private bool isCSharpLevelLoaded  = true;
	private bool isGdScriptLevelLoaded = false;
	[Export]
	public CharacterBody2D player;

	GDScript SaveLoad = GD.Load<GDScript>("res://GodotGame/Scripts/SaveLoad.gd");
	

	public override void _Ready()
	{
		checkButton = GetNode<CheckButton>("Control/CheckButton");
		collectibleLabel = GetNode<Label>("MarginContainer/VBoxContainer/HBoxContainer/CollectibleLabel");
		C_CollectiblesManager.Instance.CollectibleAwardReceived += OnCollectibleAwardReceived;
		//get the player from the scene player is called C#Player
		//get the players position
		//Vector2 playerPosition = ((CharacterBody2D)player).Position;
		//print out the player's position
		//GD.Print(playerPosition);

	

	}

	public void OnCollectibleAwardReceived(int totalAward)
	{
		if (collectibleLabel == null)
		{
			//find the collectible label 
			collectibleLabel = GetNode<Label>("MarginContainer/VBoxContainer/HBoxContainer/CollectibleLabel");
			collectibleLabel.Text = totalAward.ToString();
		}
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
			//emit singal bedore changing the scene
			//EmitSignal("Level_Changed", collectibleLabel.Text);
			GetTree().ChangeSceneToPacked(GDgameScreen);
			//get the save and load manager and use it to save the current level
			SaveLoad.Call("C_save_game", player.Position);
			//save the current level usiong ResourceSaver class and save the current level
			//remove singal from the collectible manager
			C_CollectiblesManager.Instance.CollectibleAwardReceived -= OnCollectibleAwardReceived;
			//reset the total award amount
			C_CollectiblesManager.Instance.ResetTotalAwardAmount();
		}

	}

}
