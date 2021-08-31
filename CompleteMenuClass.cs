﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using IOMethNS;

namespace PDBProject
{
	
	
	public class CompleteMenu:IMenu<IFrame<IFrameItem>,IFrameItem>
    {
		private List<IFrame<IFrameItem>> displayFrames;
		private List<IFrame<IFrameItem>> dynamicFrames;
		private IFrame<IFrameItem> crtDisplayFrame;
		private App crtApp = null;
		
		public CompleteMenu()
		{
			this.crtDisplayFrame = null;
			this.displayFrames = new List<IFrame<IFrameItem>>();
			this.dynamicFrames = new List<IFrame<IFrameItem>>();
		}
		public CompleteMenu(int crtFrameIndex, List<IFrame<IFrameItem>> dispFrames)
		{
			this.displayFrames = new List<IFrame<IFrameItem>>();
			foreach(IFrame<IFrameItem> item in dispFrames)
			{
				this.displayFrames.Add(item);
			}
			this.dynamicFrames = new List<IFrame<IFrameItem>>();
			foreach(IFrame<IFrameItem> item in dispFrames)
			{
				if(item.IsDynamic == true)
				{
					this.dynamicFrames.Add(item);
				}
			}
			this.crtDisplayFrame = this.displayFrames[crtFrameIndex];
		}
		public List<IFrame<IFrameItem>> DisplayFrames
		{
			get{return this.displayFrames;}
			set{this.displayFrames = value;}
		}
		public List<IFrame<IFrameItem>> DynamicFrames
		{
			get{return this.dynamicFrames;}
			set{this.dynamicFrames = value;}
		}
		public IFrame<IFrameItem> CrtDisplayFrame
		{
			get{return this.crtDisplayFrame;}
			set{this.crtDisplayFrame = value;}
		}

		public App CrtApp
		{
			get{return this.crtApp;}
			set{this.crtApp = value;}
		}

		public static List<IFrame<IFrameItem>> ReadFramesFromJsonFile()
		{
			List<IFrame<IFrameItem>> frameList = new List<IFrame<IFrameItem>>();
			return frameList;
		}

		public void ConstructFrameList(List<IFrame<IFrameItem>> dispFrames)
		{
			foreach(IFrame<IFrameItem> item in dispFrames)
			{
				this.displayFrames.Add(item);
			}
		}
		public void AddFrame(IFrame<IFrameItem> frame)
		{
			this.displayFrames.Add(frame);
			//Console.WriteLine("adding frame");
			if(frame.IsDynamic == true)
				{
					this.dynamicFrames.Add(frame);
				}
			this.crtDisplayFrame = this.displayFrames[0];
		}
		public static void ExportCompleteMenuToJsonFile(CompleteMenu menu)
		{

		}
		public void ShowItemFrame()
		{
			consoleDisplay.DisplayItemFrame(this.crtDisplayFrame.CrtDisplayItem.Column,
				this.crtDisplayFrame.CrtDisplayItem.Row,this.crtDisplayFrame.CrtDisplayItem.TextDisplay.Length,
				 "-","|");
		}
		public void DeleteItemFrame()
		{
			consoleDisplay.DisplayItemFrame(this.crtDisplayFrame.CrtDisplayItem.Column,
				this.crtDisplayFrame.CrtDisplayItem.Row,this.crtDisplayFrame.CrtDisplayItem.TextDisplay.Length,
				 " "," ");
		}
		
		public void DisplayCRTFrame()
		{
			Console.Clear();
			consoleDisplay.DisplayLabel(1,1,this.crtDisplayFrame.FrameNr.ToString());
			consoleDisplay.DisplayLabel(5,1,this.crtDisplayFrame.FrameTitle);

			ShowItemFrame();
			foreach(KeyValuePair<int,IFrameItem> pair in this.crtDisplayFrame.DisplayItemsDict)
			{
				consoleDisplay.DisplayLabel(pair.Value.Column, pair.Value.Row, pair.Value.TextDisplay);
			}			
			consoleDisplay.DisplayOuterFrame(0,0,12,10,"-","|");
		}

		public void SelectCurrentFrameItem(int crtIndex) //ok
		{
			//debug>>
			Console.SetCursorPosition(0,30);
			Console.WriteLine($"using index: {crtIndex} in crt frame nr: {this.crtDisplayFrame.FrameNr}, with OrderedKeys count: {this.crtDisplayFrame.OrderedKeys.Count} ");
			//<<debug
			this.crtDisplayFrame.CrtDisplayItem =  this.crtDisplayFrame.DisplayItemsDict[this.crtDisplayFrame.OrderedKeys[crtIndex]];	
		}
		public delegate void SwApp(int choice);
		public void UpdateFrame(SwApp swApp)
		{
			DisplayCRTFrame();
			int crtIndex = this.crtDisplayFrame.CursorPosition;
			int length = this.crtDisplayFrame.DisplayItemsDict.Count;
			int index;
			bool itemPressed;
			while(true)
			{
				length = this.crtDisplayFrame.DisplayItemsDict.Count;
				keyRead(crtIndex, length, out index, out itemPressed);
				if(itemPressed)
				{
					index = ActionOnEnter(this.CrtDisplayFrame.CrtDisplayItem, index, swApp);
				}
				DeleteItemFrame();
				crtIndex = index; 
				SelectCurrentFrameItem(index); 
				ShowItemFrame();
			}
		}
		public static void keyRead(int crtIndex, int length, out int newIndex, out bool enter)
		{
			ConsoleKeyInfo _Key = Console.ReadKey();
			enter = false;
			switch (_Key.Key)
            	{
                case ConsoleKey.RightArrow:
					newIndex = crtIndex+1 ;
					if(newIndex == length)
					{
						newIndex = 0;
					}
					break;
				case ConsoleKey.LeftArrow:
					newIndex = crtIndex-1;
					if(newIndex <0)
					{
						newIndex = length-1;
					}
					break;	
				case ConsoleKey.Enter:
					newIndex = crtIndex;
					enter = true;
					break;
				default:
					newIndex = crtIndex;
                    break;
				}
		}
		public int ActionOnEnter(IFrameItem FrameItem, int OrderedKeysCrtIndex, SwApp swApp)
		{
			if(FrameItem.IsActionTrigger)
			{
				swApp(FrameItem.Link);
				return OrderedKeysCrtIndex;
			}
			else
			{
				int FrameNrToDisplay =this.crtDisplayFrame.CrtDisplayItem.Link;
				foreach(IFrame<IFrameItem> frame in this.displayFrames)
				{
					if(frame.FrameNr == FrameNrToDisplay)
					{
						this.crtDisplayFrame = frame;
						DisplayCRTFrame();
					}
				}
				return 0; //displying new frame => selected display item will be this.crtDisplayFrame.OrderedKeys[0] 
			}
		}
		public static Dictionary<int, IFrameItem> CreateItemsList(List<string[]> readItemsList,string itemsFile)
		{
			Dictionary<int, IFrameItem> allItemsDict = new Dictionary<int, IFrameItem>();
			foreach (string[] textsArray in readItemsList)
            {
                int itemNr, posCol, posRow, link;
				string labelText, itemType;
				bool dyn, actTrig;

                int.TryParse(textsArray[0], out itemNr);
				itemType = textsArray[2];
				labelText = textsArray[2];
				int.TryParse(textsArray[3], out posCol);
				int.TryParse(textsArray[4], out posRow);
				bool.TryParse(textsArray[5], out dyn);
				bool.TryParse(textsArray[6], out actTrig);
				int.TryParse(textsArray[7], out link);
				IFrameItem item = new FrameItemDisplay(itemNr, itemType,labelText, posCol, posRow, dyn, actTrig, link);
				allItemsDict.Add(item.FrameItemNr,item);
            }
            return allItemsDict;
		}

		public static List<IFrame<IFrameItem>> CreateFramesList(List<string[]> readFramesList, string itemsFile)
		{
			List<IFrame<IFrameItem>> framesList = new List<IFrame<IFrameItem>>();

			foreach (string[] frameParams in readFramesList)
            {
				int frameNr, rows,  cols,  activeItemKey; //first four elements from frameParams
				string title;
				int.TryParse(frameParams[0], out frameNr);
				title = frameParams[1];
				int.TryParse(frameParams[2], out rows);
				int.TryParse(frameParams[3], out cols);
				int.TryParse(frameParams[4], out activeItemKey);
				
				int[] frameItemKeys = new int[frameParams.Length-5]; //next elements will form an int[]
				for(int i=0; i<frameItemKeys.Length;i++)
				{
					int.TryParse(frameParams[i+5], out frameItemKeys[i]);
				}
                Dictionary<int, IFrameItem> allItemsDict = Actions.ParseItemListDeleg(itemsFile, CreateItemsList);
				Dictionary<int, IFrameItem> itemsDictframe = new Dictionary<int, IFrameItem>();
				foreach(int key in frameItemKeys)
				{
					itemsDictframe.Add(key,allItemsDict[key]);
				} 

				//IFrame<IFrameItem> frame = new FrameDisplay(frameNr, rows, cols, itemsDictframe, activeItemKey);
				IFrame<IFrameItem> frame = new FrameDisplay(frameNr,title, rows, cols, itemsDictframe, activeItemKey);
				framesList.Add(frame);
			}
			return framesList;
		}


    }

	class TestCompleteMenu
	{
		
	}
}

