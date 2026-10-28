using Godot;
using Godot.Collections;

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
		{"financial history", new Array()}
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
		// Grabs the "financial history" from userData.
		// Casts "financial history" into a Godot.Collections.Array.
		// Retrieves the item at the requested index.
		// Casts the item into a Transaction.
		return (Transaction)((Array)userData["financial history"])[index];
	}

	public void AddTransaction(Transaction transaction)
	{
		// Grabs the "financial history" from userData.
		// Casts "financial history" into a Godot.Collections.Array.
		// Calls "Add()" on the "financial history" array.
		((Array)userData["financial history"]).Add(transaction);
	}

	public void RemoveTransaction(int index)
	{
		// View AddTransaction comments
		((Array)userData["financial history"]).RemoveAt(index);
	}

	public int GetTotalTransactions()
	{
		// View AddTransaction comments
		return ((Array)userData["financial history"]).Count;

	}
	#endregion transactions
	#endregion data


	#region Saving & Loading
	public void Save(string username, string password)
	{
		// Duplicates the dictionary.
		// Grabs the current "financial history" and puts into a temporary array.
		// Creates the new "financial history" array.
		Dictionary dict = userData.Duplicate();
		Array temp = (Array)userData["financial history"];
		Array financialHistory = [];

		// Iterates through temp.
			// Converts the transactions into dictionaries.
		// Puts the converted "financial history" into the dictionary.
		foreach (Transaction item in temp)
			financialHistory.Add((item).ToDict());
		dict["financial history"] = financialHistory;

		// Opens the file.
		// Stores the stringified version of the dictionary.
		// Closes the file.
		FileAccess file = FileAccess.OpenEncryptedWithPass($"user://{username}", FileAccess.ModeFlags.Write, password);
		file.StoreLine(Json.Stringify(dict));
		file.Close();
	}

	public bool Load(string username, string password)
	{
		// Loads the file.
		// Gets the contents of the file.
		// Parses the file contents.
		FileAccess file = FileAccess.OpenEncryptedWithPass($"user://{username}", FileAccess.ModeFlags.Read, password);
		string fileContents = file.GetLine();
		Variant parse = Json.ParseString(fileContents);

		// Checks if the parse failed.
			// If so, push a warning.
			// then return false.
		if (parse.VariantType == Variant.Type.Nil)
		{
			GD.PushWarning($"{username} is not saved or the password was incorrect!");
			return false;
		}

		// Casts the parsed info into the userData dictionary. 
		// Grabs the current "financial history" and puts into a temporary array.
		// Creates the new "financial history" array.
		userData = (Dictionary)parse;
		Array temp = (Array)userData["financial history"];
		Array financialHistory = [];

		// Iterates through temp.
			// Converts the dictionaries into transactions and adds them to the array.
		// Puts the converted "financial history" into userData.
		foreach (Dictionary item in temp)
			financialHistory.Add(Transaction.FromDict(item));
		userData["financial history"] = financialHistory;

		// Close the file.
		// ...
		// Return true.
		file.Close();
		GD.Print($"Succesfully loaded {username}'s data!");
		return true;
	}
	#endregion
}
