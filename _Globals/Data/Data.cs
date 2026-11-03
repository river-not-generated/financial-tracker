using Godot;
using Godot.Collections;
using System.Transactions;
using GDArray = Godot.Collections.Array;

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
		{"money",			  0.0},
		{"earnings",		  0.0},
		{"spending",		  0.0},
		{"financial history", new GDArray()},
		{"goals",			  new GDArray()}
	};
	public void Print()
	{
		GD.Print(userData);
	}


	#region Money
	public double GetMoney()
	{ return (double)userData["money"]; }

	public void SetMoney(double money)
	{ userData["money"] = money; }

	public double GetEarnings()
	{ return (double)userData["earnings"]; }

	public void SetEarnings(double money)
	{ userData["earnings"] = money; }

	public double GetSpending()
	{ return (double)userData["spending"]; }

	public void SetSpending(double money)
	{ userData["spending"] = money; }
	#endregion money


	#region Transactions
	public Transaction GetTransaction(int index)
	{
		// Grabs the "financial history" from userData.
		// Casts "financial history" into a Godot.Collections.Array.
		// Retrieves the item at the requested index.
		// Casts the item into a Transaction.
		return (Transaction)((GDArray)userData["financial history"])[index];
	}

	public void AddTransaction(Transaction transaction)
	{
		// Grabs the "financial history" from userData.
		// Casts "financial history" into a Godot.Collections.Array.
		// Calls "Add()" on the "financial history" array.
		((GDArray)userData["financial history"]).Add(transaction);
		Save();
	}

	public void RemoveTransaction(int index)
	{
		// View AddTransaction comments
		((GDArray)userData["financial history"]).RemoveAt(index);
		Save();
	}

	public int GetTotalTransactions()
	{
		// View AddTransaction comments
		return ((GDArray)userData["financial history"]).Count;

	}
	#endregion transactions


	#region Goals
	public Goal GetGoal(int index)
	{
		return (Goal)((GDArray)userData["goals"])[index];
	}

	public void AddGoal(Goal goal)
	{
		((GDArray)userData["goals"]).Add(goal);
		Save();
	}

	public void RemoveGoal(int index)
	{
		// View AddTransaction comments
		((GDArray)userData["goals"]).RemoveAt(index);
		Save();
	}

	public int GetTotalGoals()
	{
		return ((GDArray)userData["goals"]).Count;
	}
	#endregion goals

	#endregion data


	#region Saving & Loading
	private string currentUsername = "";
	private string currentPassword = "";
	public bool Save(string username, string password)
	{
		if (username == null || string.IsNullOrEmpty(username))
		{
			GD.Print("Username is null or empty!");
			return false;
		}
		if (password == null || string.IsNullOrEmpty(password))
		{
			GD.Print("Password is null or empty!");
			return false;
		}

		// Duplicates the dictionary.
		Dictionary dict = userData.Duplicate();

		// Creates the new "financial history" array.
		// Grabs the current "financial history" and puts into a temporary array.
		// Iterates through temp.
			// Converts the transactions into dictionaries.
		// Puts the converted "financial history" into the dictionary.
		GDArray financialHistory = [];
		GDArray temp = (GDArray)userData["financial history"];
		foreach (Transaction item in temp)
			financialHistory.Add((item).ToDict());
		dict["financial history"] = financialHistory;

		GDArray goals = [];
		temp = (GDArray)userData["goals"];
		foreach (Goal item in temp)
			goals.Add((item).ToDict());
		dict["goals"] = goals;

		// Opens the file.
		// Stores the stringified version of the dictionary.
		// Closes the file.
		// Returns true.
		FileAccess file = FileAccess.OpenEncryptedWithPass($"user://{username}", FileAccess.ModeFlags.Write, password);
		file.StoreLine(Json.Stringify(dict));
		file.Close();

		currentUsername = username;
		currentPassword = password;

		GD.Print($"Succesfully saved {username}'s data!");

		return true;
	}

	public bool Save()
	{
		return Save(currentUsername, currentPassword);
	}
	public bool Load(string username, string password)
	{
		if (!DoesUserExist(username))
		{
			GD.PushWarning($"{username} does not exist!");
			return false;
		}

		// Loads the file.
		// Gets the contents of the file.
		// Parses the file contents.
		FileAccess file = FileAccess.OpenEncryptedWithPass($"user://{username}", FileAccess.ModeFlags.Read, password);
		if (file == null)
		{
			GD.PushWarning($"{username} exists, but the password was incorrect!");
			return false;
		}
		string fileContents = file.GetLine();
		Variant parse = Json.ParseString(fileContents);

		// Checks if the parse failed.
			// If so, push a warning.
			// then return false.
		if (parse.VariantType == Variant.Type.Nil)
		{
			GD.PushWarning($"dude idek what happened");
			return false;
		}

		// Casts the parsed info into the userData dictionary. 
		userData = (Dictionary)parse;

		// Grabs the current "financial history" and puts into a temporary array.
		// Creates the new "financial history" array
		// Iterates through temp.
			// Converts the dictionaries into transactions and adds them to the array.
		// Puts the converted "financial history" into userData.
		GDArray temp = (GDArray)userData["financial history"];
		GDArray financialHistory = [];
		foreach (Dictionary item in temp)
			financialHistory.Add(Transaction.FromDict(item));
		userData["financial history"] = financialHistory;

		// Same as above, but for goals
		temp = (GDArray)userData["goals"];
		GDArray goals = [];
		foreach (Dictionary item in temp)
			goals.Add(Goal.FromDict(item));
		userData["goals"] = goals;

		// Current username is set to loaded username
		// Current password is set to loaded password
		currentUsername = username;
		currentPassword = password;

		// Close the file.
		// ...
		// Return true.
		file.Close();
		GD.Print($"Succesfully loaded {username}'s data!");
		return true;
	}

	public bool DoesUserExist(string username)
	{
		string[] directory = DirAccess.GetFilesAt($"user://");
		foreach (string directoryEntry in directory)
			if (directoryEntry == username)
				return true;
		return false;
	}

	public override void _Notification(int what)
	{
		if (what == NotificationWMCloseRequest)
			Save();
		base._Notification(what);
	}
	#endregion
}
