﻿using System;
using System.Collections.Generic;

namespace PDBProject
{
	
	public class App:IApp
    {
		private int appID;
		private string appName;
		private List<App> apps = null;
		private string framesFile;
		private string itemsFile;
		private CompleteMenu application;
		//private IMenu<IFrame<IFrameItem>,IFrameItem> application;
		

		//public App(int id, string text, Func<int> MethodDelegate)
		public App(int id, string text)
		{
			this.appID = id;
			this.appName = text;
			string completeFileName = ConstructFileName(text);
			string itemsFile;
			string framesFile;
			ReadConfigFile(completeFileName, out itemsFile, out framesFile);
			this.application = new CompleteMenu(0,Actions.ParseFrameListDeleg(framesFile, itemsFile, CompleteMenu.CreateFramesList));

		}
		public static string ConstructFileName(string text)
		{
			string completeFileName = text + ".txt";
			return completeFileName;
		}
		public static void ReadConfigFile(string file, out string items, out string frames)
		{
			List<string[]> framesAndItemsConfigFiles = new List<string[]>();
			framesAndItemsConfigFiles = Actions.ReadMenuTextLines(",",file);
			items = framesAndItemsConfigFiles[0][0];
			frames = framesAndItemsConfigFiles[0][1];
		}

		public int AppID
		{
			get{return this.appID;}
		}
		public string AppName
		{
			get{return this.appName;}
		}
		public List<App>  Apps
		{
			get{return this.apps;}
			set{this.apps = value;}
		}
		
		public string FramesFile
		{
			get{return this.framesFile;}
		}
		
		public string ItemsFile
		{
			get{return this.itemsFile;}
		}
		public void ConstructMenu()
		{

		} 
		public int SetAppID()
		{
			int appIdNr = 0;
			return appIdNr;
		}
		public CompleteMenu Application
		//public IMenu<IFrame<IFrameItem>,IFrameItem> Application
		{
			get{return this.application;}
		}
    }
	class TestApp
	{
		
	}
}

