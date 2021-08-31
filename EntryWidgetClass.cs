﻿using System;
using System.Collections.Generic;

namespace PDBProject
{
	
	//public class EntryWidget:IFrameItem
	public class EntryWidget:FrameItemDisplay
    {
		private int frameItemNr;
		private string itemType;
		private string textDisplay;
		private int row;
		private int column;
		private int[] gridPosition = new int[2];
		private bool isCrtDisplayItem = false; 
		private bool isDynamic= false;
		private bool isActionTrigger= false; 
		private int link = 0; 
		// isActionTrigger => ActionSwitch method (int Link) 
		// !isActionTrigger => FrameSwitch method (int Link) 
		private bool readyForUpdate= false;
/*
		public EntryWidget()
		{
			this.frameItemNr = 0;
			this.itemType = "Label";
			this.textDisplay = "Menu";
			this.row = 0;
			this.column = 0;
			this.gridPosition = new int[]{this.column, this.row};
			this.isCrtDisplayItem = true;
			this.isDynamic = false;
			this.isActionTrigger = false;
			this.link = 0;
			this.readyForUpdate = false;
		}
		public EntryWidget(int ItemNr, string Type, string text, int posCol, int posRow, bool dyn, bool actTrig, int lnk)
		{
			this.frameItemNr = ItemNr;
			this.itemType = Type;
			this.textDisplay = text;
			this.gridPosition = new int[]{posCol, posRow}; // x,y
			this.column = posCol;
			this.row = posRow;
			this.isCrtDisplayItem = false;
			this.readyForUpdate = false;
			this.isDynamic = dyn;
			this.isActionTrigger = actTrig;
			this.link = lnk;
		}
*/


		/*
		public int FrameItemNr
		{
			get{return this.frameItemNr;}
			set{this.frameItemNr = value;}
		}
		public string TextDisplay
		{
			get{return this.textDisplay;}
			set{this.textDisplay = value;}
		}
		public int Column  //x
		{
			get{return this.column;}
			set{this.column = value;}
		}
		public int Row  //y
		{
			get{return this.row;}
			set{this.row = value;}
		}
		public int[] GridPosition  
		{
			get{return new int[2]{this.column, this.row};}
			set{this.gridPosition = value;}
		}
		public bool IsCrtDisplayItem
		{
			get{return this.isCrtDisplayItem;}
			set{this.isCrtDisplayItem = value;}
		}
		public bool IsDynamic
		{
			get{return this.isDynamic;}
			set{this.isDynamic = value;}
		}
		public bool IsActionTrigger
		{
			get{return this.isActionTrigger;}
		}
		public int Link  
		{
			get{return this.link;}
		}
		public bool ReadyForUpdate
		{
			get{return this.readyForUpdate;}
			set{this.readyForUpdate = value;}
		}
		public Dictionary<int,IFrameItem> ReadItemsFile() // reads a file containig items data, returns a dictionary
		{
			Dictionary<int,IFrameItem> itemsDict = new Dictionary<int,IFrameItem>();
			//TBD: reads a file containig items data, returns a dictionary
			//string path = Directory.GetCurrentDirectory();

			return itemsDict;
		}
*/
		public string TextEntry()
		{
			string userInput = "";
			int x = consoleDisplay.xCalc(this.Column) + this.textDisplay.Length+5;
			int y = consoleDisplay.yCalc(this.Row);
			Console.SetCursorPosition(x,y);
			return userInput;
		}

	
		

    }
	class TestEntryWidget
	{
		
	}
}

