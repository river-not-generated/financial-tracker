using Godot;
using System;

public partial class Login : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//this is called each frame btw, this is for all the called each frame heads out there
	}
	
	public void _on_button_pressed()
	{
		var usernameInput = GetNode<LineEdit>("UsernameInput");
		var passwordInput = GetNode<LineEdit>("PasswordInput");

		if (!string.IsNullOrEmpty(usernameInput.Text) && !string.IsNullOrEmpty(passwordInput.Text))
		{
			if (Data.Instance.DoesUserExist(usernameInput.Text)) //check if the username exists
			{
				if (Data.Instance.Load(usernameInput.Text, passwordInput.Text)) //check if the password matches the username
				{
					//login!!!!
					Scenes.Instance.Swap("Main Menu");
					GD.Print("YAYYYYYYYYY");
				}
				else
				{
					GD.Print("you mean nothing to everyone");
					usernameInput.Text = string.Empty;
					passwordInput.Text = string.Empty;
				}
			}
			else
			{
				//reset the input boxes
				GD.Print("you mean nothing to everyone"); 
				usernameInput.Text = string.Empty;
				passwordInput.Text = string.Empty;
			}
		}
		else
		{
			GD.Print("you fucking suck, die"); //this is just a joke, probably replace this by adding a richtext lable saying invalid username or  stuff
		}
	}
}
