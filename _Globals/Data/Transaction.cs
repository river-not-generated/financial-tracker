using Godot;
using System;

public partial class Transaction : Resource
{
	public Transaction(double money, string description)
	{
		this.date = Time.GetDatetimeStringFromSystem(false);
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
