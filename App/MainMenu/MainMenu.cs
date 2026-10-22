using Godot;
using System;

public partial class MainMenu : Control
{
	public Button button;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		button = GetNode<Button>("Button");
		GD.Print(button);
		GetNode<Button>("Button").Position += new Vector2(50, 0);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private int _id = 0;
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("q"))
		{
			GD.Print("q!!!");
		}
	}

	public void _OnButtonPressed()
	{
		Scenes.Instance.Swap("Financial Tracker");
	}
}
