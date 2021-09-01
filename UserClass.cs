using System;
using System.Collections.Generic;

namespace PDBProject
{
	
	public class User
    {
		private int userID;
		private bool adminRights;
		private List<string> Messages;
		private UserInfo info;
		
		public User()
		{
			// creates admin user
		}
		public User(int id)
		{
			
		}
		
		public int UserID
		{
			get{return this.userID;}
			//set{this.UserID = value;}
		}

		public void SetPassword(string password)
		{

		}
		public string GetPassword()
		{
			string password = "";
			return password;
		}
		

    }
	class TestUser
	{
		
	}
}

