using Godot;
using System;


public partial class C_Manager : Node
{
    private PackedScene LEVEL_1 = GD.Load<PackedScene>("res://C#Game/Levels/C#Level_1.tscn");
    private PackedScene PAUSE_MENU = GD.Load<PackedScene>("res://C#Game/UI/C#PauseMenu.tscn");
    private PackedScene MAIN_MENU = GD.Load<PackedScene>("res://C#Game/UI/C#Main_Menu.tscn");

    //create a instance of the C_Manager
    public static C_Manager Instance { get; set; }

    // Called when the node enters the scene tree for the first time.

    public override void _Ready()
    {
        Instance = this;
        RenderingServer.SetDefaultClearColor(new Color(0.44f, 0.22f, 0.53f, 1.00f));
    }

    public void StartGame()
    {
        if (GetTree().Paused)
        {
            ContinueGame();
            return;
        }

        TransitionToScene(LEVEL_1.ResourcePath);
    }

    public void ExitGame()
    {
        GetTree().Quit();
    }

    public void PauseGame()
    {
        GetTree().Paused = true;

        var pauseScreenInstance = (CanvasLayer)PAUSE_MENU.Instantiate();
        GetTree().Root.AddChild(pauseScreenInstance);
    }

    public void ContinueGame()
    {
        GetTree().Paused = false;
        
    }

    public void MainMenu()
    {
        var mainMenuInstance = (CanvasLayer)MAIN_MENU.Instantiate();
        GetTree().Root.AddChild(mainMenuInstance);
    }

    public async void TransitionToScene(string scenePath)
    {
        await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
        GetTree().ChangeSceneToFile(scenePath);
    }

}