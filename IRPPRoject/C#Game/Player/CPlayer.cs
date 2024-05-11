using Godot;
using System;
using System.Diagnostics;

public partial class CPlayer : CharacterBody2D
{
    [Export] 
	public float Speed = 300.0f;
    [Export] 
	public int max_horizontal_speed = 1000;
    [Export] 
	public int jump_vertical_speed = 1000;
    public enum PlayerState
    {
        Idle,
        Walk,
        Jump,
        Fall,
    }
    public PlayerState current_state;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Ready()
    {
        current_state = PlayerState.Idle;
    }
    public override void _PhysicsProcess(double delta)
    {
		Vector2 velocity = Velocity;
        if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
		}
		
		Velocity = velocity;

        MoveAndSlide();
    }


}


