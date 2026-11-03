using Godot;
using System;

public partial class FinancialGoals : Control
{
	public TextEdit descBox;
	public Button goalButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		descBox = GetNode<TextEdit>("DescBox");
		goalButton = GetNode<Button>("Button");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void _OnAddGoalPressed()
	{
		string text = descBox.Text;
		if (!string.IsNullOrWhiteSpace(text))
		{
			Data.Instance.AddGoal(new Goal(text));
			descBox.Text = string.Empty;
			Data.Instance.Print();
		}
	}
	
}
