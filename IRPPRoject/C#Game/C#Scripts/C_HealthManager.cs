using Godot;
using System;

public partial class C_HealthManager : Node
{
	//expse the max health to the editor
	[Export]
    public int maxHealth = 3;
	[Export]
    public int currentHealth;

    // Signal declaration
    [Signal]
    public delegate void HealthChangedEventHandler(int currentHealth);

	//create a instance of the health manager
	public static C_HealthManager instance;
    // Called when the node enters the scene tree for the first time
    public override void _Ready()
    {
		instance = this;
        currentHealth = maxHealth;
    }

    // Method to decrease health
    public void DecreaseHealth(int healthAmount)
    {
        currentHealth -= healthAmount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        GD.Print("Decreased Health Entered");
        EmitSignal(nameof(HealthChanged), currentHealth);
    }

    // Method to increase health
    public void IncreaseHealth(int healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        GD.Print("Increase Health Entered");
        EmitSignal(nameof(HealthChanged), currentHealth);
    }

}
