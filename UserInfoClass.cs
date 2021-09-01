using System;
using System.Collections.Generic;

namespace PDBProject
{
	
	public class UserInfo
    {
		private int UserID;
		private bool adminRights;
		List<string> Messages;
		
		
		public UserInfo()
		{
			
		}
		
		public int FrameItemNr
		{
			get{return this.UserID;}
			//set{this.UserID = value;}
		}
		

    }
	class TestUserInfo
	{
		
	}
}

