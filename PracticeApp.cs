using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IOMethNS;
using System.Linq;
using SQLProj;

namespace PDBProject
{
    //construct a new App object , which contains a CompleteMenu object
    //  for the main menu.
    //as for app switch methods, each will construct the corresponding app menu:
    //  TimeApp, FilesApp, encryptApp, etc.

    //public static class MainApp
    public static class PracticeApp
    {
        public const string appName = "Practice";
        public static void ConstructPracticeApp()
        {
            //App DatabaseApp = new App(0, appName);
            //DatabaseApp.Application.CrtApp = DatabaseApp;
            //DatabaseApp.Application.UpdateFrame(AppSwitch);
            Console.SetCursorPosition(0,33);
            Console.WriteLine("Practice App"+"        ");
            //Practice1();
            //Practice2();
            //Practice3();
            //Practice4();
            Practice5();


        }

        public static void Practice1()
        {   
            Console.WriteLine("REVERSING A STRING Sol 1" );
			Console.WriteLine("please enter a text\n");
			string text = Console.ReadLine();
            string reversedText = string.Empty;
            for(int i=0; i<text.Length; i++ )
            {
				reversedText = reversedText+text[text.Length-i-1];
            }
			Console.WriteLine("Reverserd text:"+reversedText);
        }
		public static void Practice2()
        {
			Console.WriteLine("REVERSING A STRING Sol 2" );
			Console.WriteLine("please enter a text\n");
			string text = Console.ReadLine();
			char[] textArr = text.ToCharArray(); 
			for(int i=0, j=text.Length-1; i<j; i++, j-- )
			{
				textArr[i] = text[j];
				textArr[j] = text[i];
			}
			string reversedText = new string(textArr);
			Console.WriteLine("Reverserd text:"+reversedText);

		}

		public static void Practice3()
        {
			Console.WriteLine("REVERSING WORDS IN A TEXT Sol 1" );
			Console.WriteLine("please enter a text\n");
			string text = Console.ReadLine();
			string[] splittedText = text.Split(" ");
			string[] reversedTextArr = new string[splittedText.Length];   
			//string reversedText = string.Empty;
			StringBuilder SBText = new StringBuilder();
			for(int i=splittedText.Length-1; i>=0; i-- )
			{
				SBText.Append(splittedText[i]);
				SBText.Append(" ");
			}
			string reversedText = SBText.ToString();

			Console.WriteLine("Reverserd text:"+reversedText);

		}

		public static void Practice4()
        {
			Console.WriteLine("Check if a given number is prime number Sol 1" );
			Console.WriteLine("please introduce a positive int number\n");
			int number;
			bool isNumber = Int32.TryParse(Console.ReadLine(), out number);
			if(isNumber)
			{
				Console.WriteLine("checking\n");
				//construct empty list of divisors
				//loop from 2 to n/2 and check id n%div == 0
				//add divisor to list
				//if multiplication of list divisors> n break
				List<int> divisors = new List<int>();
				int divisorsProduct =1;
				for(int i=2; i<number/2; i++)
				{
					if (number%i==0)
					{
						Console.WriteLine($"number {number} is not prime\n");
						break;
					}
					else
					{
						divisors.Add(i);
						divisorsProduct*=i;
						if(divisorsProduct>number)
						{
							Console.WriteLine($"number {number} is prime\n");
							break;
						}
					}
				}
			}
			else
			{
				Console.WriteLine("wrong input\n");
			}
		}

        public static void Practice5()
        {
            string practice5Instructions = @"Your goal is to implement a difference function, which subtracts one list from another and returns the result.

It should remove all values from list a, which are present in list b keeping their order.
Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}
If a value is present in b, all of its occurrences must be removed from the other:
Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}";
            Console.WriteLine(practice5Instructions);
            TestSolutionPractice5_ArrayDiff();

            //Console.ReadLine();
        }

        public static int[] SolutionPractice5_ArrayDiff(int[] a, int[] b)
        {
            DisplayArray(a);
            Console.Write(" - ");
            DisplayArray(b);
            int[] indexesToRemove = new int[] { };

            int[] diffArr = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                diffArr[i] = a[i];
            }
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        int[] newIndexesToRemove = new int[indexesToRemove.Length+1];

                        for (int k = 0; k < indexesToRemove.Length; k++)
                        {
                            newIndexesToRemove[k] = indexesToRemove[k];
                        }
                        newIndexesToRemove[newIndexesToRemove.Length - 1] = i;
                        indexesToRemove = new int[newIndexesToRemove.Length];
                        for (int k = 0; k < indexesToRemove.Length; k++)
                        {
                            indexesToRemove[k] = newIndexesToRemove[k];
                        }
                    }
                }
            }
            Console.Write("indexes to remove ");
            DisplayArray(indexesToRemove);
            int crtIndexDelta = 0;
            if(indexesToRemove.Length !=0)
            {
                for (int i=0; i< indexesToRemove.Length; i++)
                {
                    diffArr = RemoveElementFromArray(diffArr, indexesToRemove[i]-crtIndexDelta);
                    crtIndexDelta++;
                }
            } 
            return diffArr;
        } 

        public static int[] RemoveElementFromArray(int[] a, int indToRemove)
        {
            int[] diff = new int[a.Length-1];
            for(int i=0; i< indToRemove; i++)
            {
                diff[i] = a[i];
            }
            for(int i=indToRemove; i< diff.Length; i++)
            {
                diff[i] = a[i+1];
            }

            return diff;
        }

        
        public static void DisplayArray(int[] inputArray)
        {
            foreach(int item in inputArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public static void TestSolutionPractice5_ArrayDiff()
        {
            int[] arrA = new int[] { 14, -3, -14, 16, -11, 2, 13, 6, -12, 0, 10, -12, -14 };
            int[] arrB = new int[] { -11, -7, -7, 3, -2, 20, -7, 11, 3, 16, 18, 1, 6, -11, -18, 0, 7, 3 };
            int[] diffArr = SolutionPractice5_ArrayDiff(arrA, arrB);
            Console.WriteLine("Testing.");
            Console.WriteLine("Input A:");
            DisplayArray(arrA);
            Console.WriteLine("Input B:");
            DisplayArray(arrB);
            Console.WriteLine("solution:");
            DisplayArray(diffArr);
        }



        public static void AppSwitch(int ItemLink)
        {
            switch (ItemLink)
            {
                case -1:
                    MainApp.ConstructMainApp();
                    break;
                case 0:
                    ConstructPracticeApp();
                    break;

                case 1:
                    
                    break;
                
                default:
                    break;
            }
        }
        
        
        
        public static void MultilineQuadrPolynIntDataset(string path)
        {
            try
            {
                StreamWriter writer = new StreamWriter(path);
                Console.WriteLine("creating a dataset using quadratic polynom: a*x*x+b*x+c");
                Console.WriteLine("please insert dataset size");
                int datasetSize = int.Parse(Console.ReadLine());
                Console.WriteLine("please insert start value for a");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("please insert start value for b");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("please insert start value for c");
                int c = int.Parse(Console.ReadLine());
                Console.WriteLine("please insert increment");
                int increment = int.Parse(Console.ReadLine());
                Console.WriteLine("please insert nr of sets to be generated");
                int setsNr = int.Parse(Console.ReadLine());

                using (writer)
                {
                    writer.WriteLine("*"+$"Read me: each dataset is created using the quadratic polynom: {a}*x*x+{b}*x+{c}, where x is between 0 and {datasetSize-1}. Nr of datasets: {setsNr}. Increment:{increment}");
                    
                    for(int i=0; i<setsNr;i++)
                    {
                        for(int j=0; j<datasetSize;j++)
                        {
                            writer.Write(a*j*j+b*j+c);
                            if(j!=datasetSize-1)
                            {
                                writer.Write(",");
                            }
                        }
                        writer.WriteLine(); 
                        a+=increment;   
                        b+=increment; 
                        c+=increment;
                        //a+=increment*i;   
                        //b+=increment*i; 
                        //c+=increment*i;   

                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"There was an issue! {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Cannot read file! Details: {e.Message}");
            }
            finally
            {
                Console.WriteLine("finished");
            }
        }
        public static void Query1()
        {
            Console.SetCursorPosition(0,50);
            Console.WriteLine("Reading data");
            string readDatasetFileName =  IOMethodsCLS.UserDefinedFilePath();
            Console.WriteLine($"reading file:\n{readDatasetFileName}\n");
            List<int[]> readDataset = ParseDataset(readDatasetFileName);
            Console.WriteLine("Query1: selecting integers divisible with user-provided int divisor");
            Console.WriteLine("please insert divisor");
            int divisor = int.Parse(Console.ReadLine());
            foreach(int[] dataset in readDataset)
            {
                var multipleNr =
                    from num in dataset
                    where num % divisor == 0
                    select num;
                foreach(var item in multipleNr)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
        public static void Query2()
        {
            Console.SetCursorPosition(0,50);
            Console.WriteLine("Reading data");
            string readDatasetFileName =  IOMethodsCLS.UserDefinedFilePath();
            Console.WriteLine($"reading file:\n{readDatasetFileName}\n");
            List<int[]> readDataset = ParseDataset(readDatasetFileName);
            Console.WriteLine("Query2: selecting integers inside an user-provided int inteval");
            Console.WriteLine("please insert minimum value");
            int minVal = int.Parse(Console.ReadLine());
            Console.WriteLine("please insert maximum value");
            int maxVal = int.Parse(Console.ReadLine());
            foreach(int[] dataset in readDataset)
            {
                var inRangeNr =
                    from num in dataset
                    where (num > minVal) & (num < maxVal)
                    select num;
                foreach(var item in inRangeNr)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        public static void Query3()
        {
            Console.SetCursorPosition(0,50);
            Console.WriteLine("Reading data");
            string readDatasetFileName =  IOMethodsCLS.UserDefinedFilePath();
            Console.WriteLine($"reading file:\n{readDatasetFileName}\n");
            List<int[]> readDataset = ParseDataset(readDatasetFileName);
            Console.WriteLine("Query3: selecting integers larger than user-provided int number");
            Console.WriteLine("please insert minimum value");
            int minVal = int.Parse(Console.ReadLine());
            Console.WriteLine($"numbers larger than {minVal}:");
            foreach(int[] dataset in readDataset)
            {
                var largerNr = dataset.Where(nr => nr>minVal);
                foreach(var number in largerNr)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
                
            }
        }
        public static void Sort1()
        {
            Console.SetCursorPosition(0,50);
            Console.WriteLine("Reading data");
            string readDatasetFileName =  IOMethodsCLS.UserDefinedFilePath();
            Console.WriteLine($"reading file:\n{readDatasetFileName}\n");
            List<int[]> readDataset = ParseDataset(readDatasetFileName);
            foreach(int[] dataset in readDataset)
            {
                var sorted =
                from item in dataset 
                orderby item ascending
                select item;
                foreach(var item in sorted)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
            }
        }
        public static void Group1()
        {
            Console.SetCursorPosition(0,50);
            Console.WriteLine("Reading data");
            string readDatasetFileName =  IOMethodsCLS.UserDefinedFilePath();
            Console.WriteLine($"reading file:\n{readDatasetFileName}\n");
            List<int[]> readDataset = ParseDataset(readDatasetFileName);
            Console.WriteLine("please insert divisor");
            int divisor = int.Parse(Console.ReadLine());
            foreach(int[] dataset in readDataset)
            {
                var numberGroups =
                from item in dataset
                group item by (item % divisor == 0) into groupedElements 
                select new {Divisible = groupedElements.Key, Items = groupedElements};
                foreach(var groupedElements in numberGroups)
                {
                    Console.WriteLine($"Numbers divisibility by {divisor} {groupedElements.Divisible}");
                    foreach(var item in groupedElements.Items)
                    {
                        Console.WriteLine(item);
                    }
                }
                Console.WriteLine("\nNext Dataset:");
            }
        }

        public static void Join1()
        {
            //move to a create dataset method; 
            DBObjConstruction ProductsAndCategoryDB = new DBObjConstruction();
            ProductsAndCategoryDB.Products.Add(new DBProduct(){Name="Cherry",CategoryID =1});
            
            var productsWithCategories =
                from product in ProductsAndCategoryDB.Products
                join category in ProductsAndCategoryDB.Categories
                    on product.CategoryID equals category.ID
                select new {Name = product.Name, Category = category.Name};
            foreach(var item in productsWithCategories)
            {
                Console.WriteLine(item);
            }
        }

        public static void Nest1()
        {
            Console.SetCursorPosition(0,50);
            Console.WriteLine("nesting");
            DBObjConstruction ProductsAndCategoryDB = new DBObjConstruction();
            var productsWithCategories =
                from product in ProductsAndCategoryDB.Products
                select new {
                    Name = product.Name,
                    Category =
                        (from category in ProductsAndCategoryDB.Categories
                        where category.ID == product.CategoryID
                        select category.Name).First()
                };
            foreach(var item in productsWithCategories)
            {
                Console.WriteLine(item);
            }
        }
        public static void PerformanceTest1()
            {
                Console.SetCursorPosition(0,33);
                int nrOfAddedElements = 50000000;
                Console.WriteLine($"Performance tests. Adding {nrOfAddedElements} elements");
                
                List<int> list1 = new List<int>();
                DateTime startTime = DateTime.Now;
                list1.AddRange(Enumerable.Range(1,nrOfAddedElements));
                Console.WriteLine($"Duration using extension method: {DateTime.Now-startTime}");

                List<int> list2 = new List<int>();
                startTime = DateTime.Now;
                for(int i=0; i<nrOfAddedElements; i++)
                {
                    list2.Add(i);
                }
                Console.WriteLine($"Duration using for loop: {DateTime.Now-startTime}");

                Console.WriteLine("LINQ performance");
                List<int> list3 = new List<int>();
                list3.AddRange(Enumerable.Range(1,nrOfAddedElements));
                startTime = DateTime.Now;
                for(int i=0; i<1000; i++)
                {
                    var elements = list3.Where(e => e>2000);
                }
                Console.WriteLine($"Duration with no execution: {DateTime.Now-startTime}");

                startTime = DateTime.Now;
                /*
                for(int i=0; i<1000; i++)
                {
                    var elements = list3.Where(e => e>2000).First();
                    Console.Write(elements+ " ");
                }
                */
                var elements1 = list3.Where(e => e>2000&e<3000);
                
                foreach(var element in elements1)
                {
                    Console.Write(element + " ");
                }

                Console.WriteLine($"Duration with execution: {DateTime.Now-startTime}");
                
                Console.WriteLine("working with dictionary");
                List<int> dictUnderTest1Keys = new List<int>();
                dictUnderTest1Keys.AddRange(Enumerable.Range(1,5000000));
                List<int> dictUnderTest1Vals = new List<int>();
                dictUnderTest1Vals.AddRange(Enumerable.Range(5,5000005));
                Dictionary<int,int> dictUnderTest1 = new Dictionary<int, int>();
                for(int i=0;i<dictUnderTest1Keys.Count;i++)
                {
                    dictUnderTest1.Add(dictUnderTest1Keys[i],dictUnderTest1Vals[i]);
                }
                startTime = DateTime.Now;
                var elements2 = dictUnderTest1.Where(e => e.Value%777 ==0);
                foreach(var element in elements2)
                {
                    Console.Write(element + " ");
                }
                DateTime stopTime = DateTime.Now;
                
                Console.WriteLine($"Duration with dictionary: {stopTime-startTime}");

                

            }
        
        public static List<int[]> ParseDataset(string fileName)
        {
            List<string[]> readDataString =new List<string[]>();
            List<int[]> convertedData =new List<int[]>();

            readDataString = Actions.ReadMenuTextLines(",",fileName);
            convertedData = ConvertToIntArrList(readDataString);
            return convertedData;
        }

        public static List<int[]> ConvertToIntArrList(List<string[]> inputData)
        {
            List<int[]> outputData =new List<int[]>();

            for(int i=0; i<inputData.Count; i++)
            {
                int[] crtOutputArr = new int[inputData[i].Length]; 
                for(int j=0; j<crtOutputArr.Length; j++)
                {
                    int.TryParse(inputData[i][j], out crtOutputArr[j]);
                }
                outputData.Add(crtOutputArr);
            }

            return outputData;
        } 



    }
    //public static class TestDatabaseApp
    //{
        
    //}
}


