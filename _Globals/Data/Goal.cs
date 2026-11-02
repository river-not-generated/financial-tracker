using Godot;
using Godot.Collections;
using System;

public partial class Goal : Node
{
	public Goal(string description)
	{
		Dictionary time = Time.GetDateDictFromSystem();
		this.date = $"{time["month"]}/{time["day"]}/{time["year"]}";
		this.description = description;
	}
	public Goal(string date, string description)
	{
		this.date = date;
		this.description = description;
	}

	public string date;
	public string description;

	public Dictionary ToDict()
	{
		return new Dictionary()
		{
			{ "date",        date },
			{ "description", description }
		};
	}
	public static Goal FromDict(Dictionary dict)
	{
		return new Goal(
			(string)dict["date"],
			(string)dict["description"]
		);
	}
	public override string ToString()
	{
		return $"{date}  -  {description}";
	}
}
