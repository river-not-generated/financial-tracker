using Godot;
using Godot.Collections;
using Microsoft.VisualBasic;
using System.Collections.Generic;
//using System;

public partial class Data : Node
{
    public static Data Instance { get; private set; }
    private Dictionary userData = new Dictionary
	{
		{"username",		  ""},
		{"password",		  ""},
		{"money",			  0.0},
		{"financial history", new Array<Transaction>()}
	};

	// Maybe make this a struct and convert userData to a C# list? Dunno if Godot can save that as a JSON file, though...
	public partial class Transaction : Resource
	{
		string date;
		double money;
		string description;
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
		return (Transaction)((Array)userData["financial history"])[index];
	}
}
