using Godot;
using Godot.Collections;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
//using System;

public partial class Data : Node
{
	public static Data Instance { get; private set; }
	private Dictionary userData = new Dictionary
	{
		{"username",		  ""},
		{"password",		  ""},
		{"money",			  0.0},
		{"financial history", new Godot.Collections.Array()}
	};

	public void Print()
	{
		GD.Print(userData);
	}

	public override void _Ready()
	{
		Instance = this;
	}

	
	// Money
	public double GetMoney()
	{
		return (double)userData["money"];
	}

	public void SetMoney(double money)
	{
		userData["money"] = money;
	}


	// Transactions
	public Transaction GetTransaction(int index)
	{
		return (Transaction)((Godot.Collections.Array)userData["financial history"])[index];
	}

	public void AddTransaction(Transaction transaction)
	{
		((Godot.Collections.Array)userData["financial history"]).Add(transaction);
	}

	public void RemoveTransaction(int index)
	{
		((Godot.Collections.Array)userData["financial history"]).RemoveAt(index);
	}

	public int GetTotalTransactions()
	{
		return ((Godot.Collections.Array)userData["financial history"]).Count;

	}
}
