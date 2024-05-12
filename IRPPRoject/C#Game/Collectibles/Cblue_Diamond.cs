using Godot;
using System;

public partial class Cblue_Diamond : Node2D
{
[Export]
	public int awardAmount = 1;

	private Label label;
	private AnimatedSprite2D image;

	public override void _Ready()
	{
		label = GetNode<Label>("Label");
		image = GetNode<AnimatedSprite2D>("Image");
		label.Hide();
	}

	private async void _on_area_2d_body_entered(Node body)
	{
		if (body.IsInGroup("Player"))
		{
			GD.Print(awardAmount);

			image.Hide();
			label.Text = awardAmount.ToString();
			C_CollectiblesManager.Instance.GivePickupAward(awardAmount);

			label.Show();

			var tween = GetTree().CreateTween();
			tween.TweenProperty(label, "position", new Vector2(label.Position.X, label.Position.Y - 10), 0.5f).FromCurrent();
			await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
			QueueFree();
		}
	}

}
