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
			Data.Instance.Print();
		}
		else if (Input.IsActionJustReleased("e"))
		{
			GD.Print("e!!!");
		}
	}

	public void _OnButtonPressed()
	{
		Scenes.Instance.Swap("Financial Goals");
	}

	public void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
