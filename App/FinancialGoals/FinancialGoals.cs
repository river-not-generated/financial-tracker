using Godot;
using System;

public partial class FinancialGoals : Control
{
	public TextEdit descBox;
	public Button goalButton;
	public VBoxContainer goalContainer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		descBox = GetNode<TextEdit>("DescBox");
		goalButton = GetNode<Button>("Button");
		goalContainer = GetNode<VBoxContainer>("GoalsContainer");

		LoadGoals();
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
			LoadGoals();
		}
	}

	private void LoadGoals()
	{
		for (int i = 0; i < goalContainer.GetChildCount(); i++)
		{
			goalContainer.GetChild(0).QueueFree();
		}

		for (int i = Data.Instance.GetTotalGoals() - 1; i >= 0; i--)
		{
			Goal g = Data.Instance.GetGoal(i);
			if (g != null)
			{
				Panel panel = GD.Load<PackedScene>("uid://c856b8ngxv6g3").Instantiate<Panel>();
				goalContainer.AddChild(panel);
				panel.SetSize(new Vector2(520.0f, 60.0f));
				panel.Call("set_goal_text", g.description);
			}
		}
	}
	
}
