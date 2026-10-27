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

	// Maybe make this a struct and convert userData to a C# list? Dunno if Godot can save that as a JSON file, though...
	public partial class Transaction : Resource
	{
		public Transaction(string date, double money, string description)
		{
			this.date = date;
			this.money = money; 
			this.description = description;
		}

		public string date;
		public double money;
		public string description;
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
