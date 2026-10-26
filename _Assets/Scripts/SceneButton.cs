using Godot;
using System;

public partial class SceneButton : Button
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public string SceneGoTo = "Main Menu";

	public override void _Ready()
	{
		Pressed += OnButtonPressed;
	}

	public void OnButtonPressed()
	{
		Scenes.Instance.Swap(SceneGoTo);
	}
}
