using Godot;
using System;

public partial class Cdoor : Node2D
{
    [Export]
    public Node2D linkDoors;

    private Vector2 linkedDoorPosition;
    private Vector2 playerPositionBeforeTeleport;

    public override void _Ready()
    {
        if (linkDoors != null)
        {
            linkedDoorPosition = linkDoors.GlobalPosition;
        }
    }

    private void _on_area_2d_body_entered(Node body)
    {
        if (body.IsInGroup("Player"))
        {
            Node2D player = (Node2D)body;
            playerPositionBeforeTeleport = player.GlobalPosition;
            player.GlobalPosition = linkedDoorPosition;
        }
    }


}
