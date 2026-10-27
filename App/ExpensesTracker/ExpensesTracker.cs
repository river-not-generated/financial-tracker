using Godot;
using System;

public partial class ExpensesTracker : Control
{
	public Button depositButton;
	public Button withdrawButton;
	public SpinBox moneyBox;
	public LineEdit descBox;
	public RichTextLabel currentMoney;
	public string inputParent = "ExpensesInput";
	public string totalParent = "TotalMoney";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Data.Instance.Print();
		
		depositButton = GetNode<Button>("DepositButton");
		withdrawButton = GetNode<Button>("WithdrawButton");
		moneyBox = GetNode<SpinBox>($"{inputParent}/MoneyInput");
		descBox = GetNode<LineEdit>($"{inputParent}/DescriptionInput");
		currentMoney = GetNode<RichTextLabel>($"{totalParent}/TotalMoney");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private int _id = 0;
	public override void _Process(double delta)
	{
		currentMoney.Text = $"Total Money: ${Data.Instance.GetMoney()}";
	}

	public void _OnDepositPressed()
	{
		if (moneyBox.Value > 0)
		{
			GD.Print($"+${moneyBox.Value} - {(string.IsNullOrWhiteSpace(descBox.Text) ? "No description" : descBox.Text)}");
			Data.Instance.SetMoney(Data.Instance.GetMoney() + moneyBox.Value);

			descBox.Text = string.Empty;
			moneyBox.Value = 0;
		}
		Data.Instance.Print();

	}

	public void _OnWithdrawPressed()
	{
		if (moneyBox.Value > 0)
		{
			GD.Print($"-${moneyBox.Value} - {(string.IsNullOrWhiteSpace(descBox.Text) ? "No description" : descBox.Text)}");
			Data.Instance.SetMoney(Data.Instance.GetMoney() - moneyBox.Value);

			descBox.Text = string.Empty;
			moneyBox.Value = 0;
		}
		Data.Instance.Print();
	}
}
