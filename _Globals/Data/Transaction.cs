using Godot;
using Godot.Collections;
using System;

public partial class Transaction : Resource
{
	public Transaction(double money, string description)
	{
		Dictionary time = Time.GetDateDictFromSystem();
		this.date = $"{time["month"]}/{time["day"]}/{time["year"]}";
		this.money = money;
		this.description = description;
	}
	public Transaction(string date, double money, string description)
	{
		this.date = date;
		this.money = money;
		this.description = description;
	}

	public string date;
	public double money;
	public string description;

	public override string ToString()
	{
		return $"${money} on {date}  -  {description}";
	}
}
