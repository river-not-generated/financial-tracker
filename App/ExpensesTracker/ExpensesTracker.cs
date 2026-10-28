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
		ParseTransaction(1);
	}

	public void _OnWithdrawPressed()
	{
		ParseTransaction(-1);
	}

	private void ParseTransaction(int mult = -1)
	{
		double money = moneyBox.Value;
		if (money > 0)
		{
			string desc = descBox.Text;
			GD.Print($"${(mult < 1 ? "-" : "+")}{money} - {(string.IsNullOrWhiteSpace(desc) ? "No description" : desc)}");
			Data.Instance.SetMoney(Data.Instance.GetMoney() + (money * mult));
			Data.Instance.AddTransaction(new Transaction((money * mult), desc));

			descBox.Text = string.Empty;
			moneyBox.Value = 0;
		}
		Data.Instance.Print();
	}
}
