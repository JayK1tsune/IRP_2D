using Godot;
using System;

public partial class C_CollectiblesManager : Node
{
   
	//create a instance of the collectibles manager
	public static C_CollectiblesManager Instance;
	private static int totalAwardAmount;

	// Signal declaration
	[Signal]
	public delegate void CollectibleAwardReceivedEventHandler(int totalAwardAmount);


	// Called when the node enters the scene tree for the first time
	public override void _Ready()
	{

		Instance = this;
	}

	public void GivePickupAward(int collectibleAward)
	{
		totalAwardAmount += collectibleAward;
		EmitSignal(nameof(CollectibleAwardReceived), totalAwardAmount);
	}

	public void ResetTotalAwardAmount()
	{
		totalAwardAmount = 0;
		EmitSignal(nameof(CollectibleAwardReceived), totalAwardAmount);
	}
}
