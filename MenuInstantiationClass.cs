﻿using System;
using System.Collections.Generic;

//https://en.wikipedia.org/wiki/Singleton_pattern
namespace PDBProject
{
	public static class MenuInstantiation
    {
      public const string FramesFile = "FramesDataFile.txt";
      public const string ItemsFile = "ItemsDataFile.txt";
		  //public static CompleteMenu Instance {get;} = new CompleteMenu(0,Actions.ParseFrameList(FramesFile, ItemsFile));

      public static CompleteMenu Instance {get;} = new CompleteMenu(0,Actions.ParseFrameListDeleg(FramesFile, ItemsFile, CompleteMenu.CreateFramesList));    
    }
}

