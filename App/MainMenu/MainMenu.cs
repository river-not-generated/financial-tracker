using Godot;
using System;

public partial class MainMenu : Control
{
	public Button button;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Example of input and printing
		if (Input.IsActionJustPressed("q"))
		{
			GD.Print("q!!!");
			Data.Instance.AddTransaction(new Transaction(Time.GetDatetimeStringFromSystem(false), 12.02, "Transaction description."));
			Data.Instance.Print();
			Data.Instance.RemoveTransaction(0);
			Data.Instance.Print();
		}
	}

	public void _OnButtonPressed()
	{
		Scenes.Instance.Swap("Financial Goals");
	}
}
