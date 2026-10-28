using Godot;
using Godot.Collections;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class Data : Node
{
	public override void _Ready()
	{
		Instance = this;
	}


	#region Data
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


	#region Money
	public double GetMoney()
	{
		return (double)userData["money"];
	}

	public void SetMoney(double money)
	{
		userData["money"] = money;
	}
	#endregion money


	#region Transactions
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
	#endregion transactions
	#endregion data


	#region Saving
	public void Save(string username, string password)
	{
		Dictionary dict = userData.Duplicate();
		Array temp = (Array)userData["financial history"];
		Array financialHistory = [];

		foreach (Transaction item in temp)
		{
			financialHistory.Add(((Transaction)item).ToDict());
		}
		dict["financial history"] = financialHistory;

		FileAccess file = FileAccess.OpenEncryptedWithPass($"user://{username}", FileAccess.ModeFlags.Write, password);
		file.StoreLine(Json.Stringify(dict));
		file.Close();
	}

	public bool Load(string username, string password)
	{
		FileAccess file = FileAccess.OpenEncryptedWithPass($"user://{username}", FileAccess.ModeFlags.Read, password);

		string fileContents = file.GetLine();
		Variant parse = Json.ParseString(fileContents);
		if (parse.VariantType == Variant.Type.Nil)
		{
			GD.Print($"{username} is not saved or the password was incorrect!");
			return false;
		}

		Dictionary dict = (Dictionary)parse;
		Array temp = (Array)dict["financial history"];
		Array financialHistory = [];
		foreach (Dictionary item in temp)
		{
			financialHistory.Add(Transaction.FromDict(item));
		}
		dict["financial history"] = financialHistory;

		userData = dict;

		file.Close();
		GD.Print($"Succesfully loaded {username}'s data!");
		return true;
	}
	#endregion
}
