using System;
using System.Collections.Generic;
using System.IO;
using IOMethNS;
using System.Linq;

namespace PDBProject
{
	//construct a new App object , which contains a CompleteMenu object
	public static class PDBApp
    {
		public const string appName = "PDB";
		public static void ConstructPDBApp()
		{
			App PDBApp = new App(0, appName);
			PDBApp.Application.CrtApp = PDBApp;
			PDBApp.Application.UpdateFrame(AppSwitch);
		}
		public static void AppSwitch(int ItemLink)
		{
			switch (ItemLink)
			{
				case -1:
					DatabaseApp.ConstructDatabaseApp();
					break;
				case 0:
					ConstructPDBApp();
					break;
				case 1:
					WidgetTest();
					break;


				default:
					break;
			}
		}
		public static void WidgetTest()
		{
			string userInput = Console.ReadLine();
			//string userInput = IOMethodsCLS.GetUserInput();
			//Console.Write(">>"+userInput);
		}
		
    }
	public static class TestPDBApp
	{
		
	}
}

