using Godot;
using System;

public partial class TransactionHistory : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// For each of the transactions in the transaction log,
		// show the transaction details, starting with the most recent and ending with the least recent
		VBoxContainer transactionContainer = GetNode<VBoxContainer>("Transactions/TransactionsVBox");

		Data.Instance.AddTransaction(new Transaction(30.03, "test"));
		Data.Instance.AddTransaction(new Transaction(30.03, "test"));
		Data.Instance.AddTransaction(new Transaction(30.03, "test"));
		Data.Instance.AddTransaction(new Transaction(30.03, "test"));
		Data.Instance.AddTransaction(new Transaction(30.03, "test"));
		Data.Instance.AddTransaction(new Transaction(30.03, "test"));
		Data.Instance.AddTransaction(new Transaction(30.03, "test"));

		for (int i = Data.Instance.GetTotalTransactions() - 1; i >= 0; i--)
		{
			Transaction trans = Data.Instance.GetTransaction(i);
			Panel panel = GD.Load<PackedScene>("uid://d1mxx6encsk7h").Instantiate<Panel>();
			transactionContainer.AddChild(panel);
			panel.SetSize(new Vector2(520.0f, 60.0f));
			panel.Call("SetValues", trans.money, trans.description, trans.date);
		}
		transactionContainer.AddChild(new Panel());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
