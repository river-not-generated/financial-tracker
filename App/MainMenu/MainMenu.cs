using Godot;
using System;

public partial class MainMenu : Control
{
	public Button button;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Example of getting a button and moving it 50 pixels to the right.
		button = GetNode<Button>("Button");
		GetNode<Button>("Button").Position += new Vector2(50, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Example of input and printing
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
