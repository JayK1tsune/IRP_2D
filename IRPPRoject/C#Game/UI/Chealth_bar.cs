using Godot;
using System;

public partial class Chealth_bar : Node2D
{
    [Export]
    public Texture2D heart1;

    [Export]
    public Texture2D heart0;

    private Sprite2D heart_1;
    private Sprite2D heart_2;
    private Sprite2D heart_3;

public override void _Ready()
{
	heart_1 = GetNode<Sprite2D>("Heart3");
	heart_2 = GetNode<Sprite2D>("Heart2");
	heart_3 = GetNode<Sprite2D>("Heart1");

	C_HealthManager.instance.HealthChanged += OnPlayerHealthChanged;
}

    public void OnPlayerHealthChanged(int playerCurrentHealth)
    {
        if (playerCurrentHealth == 3)
        {
            heart_3.Texture = heart1;
        }
        else if (playerCurrentHealth < 3)
        {
            heart_3.Texture = heart0;
        }

        if (playerCurrentHealth == 2)
        {
            heart_2.Texture = heart1;
        }
        else if (playerCurrentHealth < 2)
        {
            heart_2.Texture = heart0;
        }

        if (playerCurrentHealth == 1)
        {
            heart_1.Texture = heart1;
        }
        else if (playerCurrentHealth < 1)
        {
            heart_1.Texture = heart0;
        }
    }
}
