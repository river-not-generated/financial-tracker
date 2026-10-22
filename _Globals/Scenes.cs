using Godot;
using Godot.Collections;
using System;

public partial class Scenes : Node
{
	public static Scenes Instance { get; private set; }

    public override void _Ready() { Instance = this; }

	// To get a scene's UID, right-click on the .tscn file and press "Copy UID".
	public Dictionary SceneDict = new Dictionary
	{
		{ "Main Menu",		   GD.Load("uid://c2rt2lth6yjsi") },
		{ "Financial Tracker", GD.Load("uid://7gyag1fhmybi") },
		//{ "Scene Name",      GD.Load("SCENE_UID") },
		//{ "Scene Name",      GD.Load("SCENE_UID") },
		//{ "Scene Name",      GD.Load("SCENE_UID") },
	};
	
	public void Swap(string name)
	{
		GetTree().ChangeSceneToPacked((PackedScene)SceneDict[name]);
	}
}
