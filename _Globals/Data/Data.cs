using Godot;
using Godot.Collections;
using System;

public partial class Data : Node
{
    public static Data Instance { get; private set; }
    private Dictionary userData = new Dictionary
	{
		{"username", ""},
		{"password", ""},
		{"money",   0.0},
	};

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
}
