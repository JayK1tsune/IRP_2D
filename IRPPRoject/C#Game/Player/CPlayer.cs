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
		player_Gravity((float)delta);
		player_run((float)delta);
		player_fall();
		current_player_state();

		if (Input.IsActionJustPressed("jump")) {
			player_jump();
		}
		
        MoveAndSlide();
		
		//print out the player's state
		GD.Print(current_state);
    }

	public void player_Gravity(float delta)
	{
		Vector2 velocity = Velocity;
        if (!IsOnFloor()) {
			velocity.Y += gravity * (float)delta;
		}
		Velocity = velocity;
	}

	public void player_run(float delta)
	{
		Vector2 velocity = Velocity;
		velocity.X = 0;
		if (Input.IsActionPressed("move_right")) {
			velocity.X += Speed;
			if (IsOnFloor()){
				current_state = PlayerState.Walk;
			}
			//get the sprite and flip it
			var ap = GetNode("AnimatedSprite2D") as AnimatedSprite2D;
			ap.FlipH = false;
		}
		else if (Input.IsActionPressed("move_left")) {
			velocity.X -= Speed;
			//check to see if the player is not in the air
			if (IsOnFloor()){
				current_state = PlayerState.Walk;
			}
			//get the sprite and flip it
			var ap = GetNode("AnimatedSprite2D") as AnimatedSprite2D;
			ap.FlipH = true;
		}
		else
		{
			player_idle();
		}
		Velocity = velocity;

	}

	public void player_idle()
	{
		if(IsOnFloor())
		{
			current_state = PlayerState.Idle;
		}
	}

	public void current_player_state()
	{
		var ap = GetNode("AnimatedSprite2D") as AnimatedSprite2D;
		if (current_state == PlayerState.Idle) {
			ap.Play("Idle");
		}
		if (current_state == PlayerState.Walk) {
			ap.Play("Running");
		}
		if (current_state == PlayerState.Jump) {
			ap.Play("Jump");
		}
		if (current_state == PlayerState.Fall) {
			ap.Play("Falling");
		}
	}

	public void player_jump()
	{
		if (IsOnFloor()) {
			Velocity = new Vector2(Velocity.X, -jump_vertical_speed);
			current_state = PlayerState.Jump;
		}
	}

	public void player_fall()
	{
		Vector2 velocity = Velocity;
		//check to see if the player is not on the floor and is falling 
		if (!IsOnFloor() && Velocity.Y > 0) {
			current_state = PlayerState.Fall;
		}
		Velocity = velocity;
	}


	



}


