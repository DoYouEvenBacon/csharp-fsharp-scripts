using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

public class FreqCS{
	IEnumerable<(int, string)> Frequencies (string[] alphabetText, int k) {
		var sortedFreq = alphabetText
			.GroupBy(str => str.ToUpper())          
			.Select(g => (g.Count(), g.Key))    
			.OrderByDescending(kc => kc.Item1).ThenBy(kc => kc.Item2).Take(k)      
			;
		return sortedFreq;
	}

	public static void Main(string[] args) {
		try{
			var textFile = args[0];
			int k = 3;
			if(args.Length == 2){ 
				k = Convert.ToInt32(args[1]);
				if(k < 0){ //negative k
					throw new Exception();
				}
			}
			var rawText = File.ReadAllText(textFile);
			Regex alphabetRegex = new Regex("[^a-zA-Z]+"); //match not a-zA-Z
			var alphabetText = alphabetRegex.Replace(rawText, " ").Trim().Split(' ');
			
			FreqCS f1 = new FreqCS();
			var sortedFreq = f1.Frequencies(alphabetText, k).ToArray();
			Array.ForEach(sortedFreq, keyCount => Console.WriteLine("{0} {1}", keyCount.Item1, keyCount.Item2));
		}
		catch(IndexOutOfRangeException){ //no text file specified
			Console.WriteLine("*** Error: Missing text file name.");
			Environment.ExitCode = 1;
		}
		catch(FileNotFoundException e){ //if file name specified but does not exist
			Console.WriteLine("*** Error: Text file {0} does not exist in this directory.", e.FileName);
			Environment.ExitCode = 1;
		}
		catch(FormatException){ //passed K value is not an int
			Console.WriteLine("*** Error: Optional parameter provided is not an Integer.");
			try{ //check if file name is invalid too
				var textFile = args[0];
				var rawText = File.ReadAllText(textFile);
			}
			catch(FileNotFoundException e){ //throw another error message below parent error message
				Console.WriteLine(" Text file {0} does not exist in this directory.", e.FileName);
			}
			Environment.ExitCode = 1;
		}
		catch(Exception){ //handle negative k value 
			Console.WriteLine("*** Error: No output; negative k value entered.");
			Environment.ExitCode = 1;
		}
	}
}