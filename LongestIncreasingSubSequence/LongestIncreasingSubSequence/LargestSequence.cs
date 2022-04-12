using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubSequence
{
    public class LargestSequence
    {
		public string Find(string numberSequence)
		{
			//Create array fron the string 
			int[] array = numberSequence.Split(' ').Select(p => int.Parse(p)).ToArray();

			List<int> list = new List<int>();
			int currentMax;
			int highestCount = 0;

			//Store sequences in dictionary
			Dictionary<int, List<int>> sequences = new Dictionary<int, List<int>>();
			int key = 1;
			for (int i = 0; i < array.Length; i++)
			{
				currentMax = int.MinValue;
				for (int j = i; j < array.Length; j++)
				{
					if (array[j] > currentMax)
					{
						list.Add(array[j]);
						currentMax = array[j];
					}
					else
					{
						//Add the sequence to dictionary
						if (list.Count > 1)
						{
							sequences.Add(key, list);
							key++;
							// Compare previous highest subsequence
							if (highestCount < list.Count)
							{
								highestCount = list.Count;
							}
						}

						list = new List<int>();
					}
				}

				//Add the sequence to dictionary in case of last item
				if (list.Count > 1)
				{
					sequences.Add(key, list);
					key++;
					// Compare previous highest subsequence
					if (highestCount < list.Count)
					{
						highestCount = list.Count;
					}
				}

				list = new List<int>();
			}

			string output = string.Empty;

			//Get the first longest sequence
			foreach (int dictionaryKey in sequences.Keys)
			{
				if (sequences[dictionaryKey].Count == highestCount)
				{
					output = string.Join<int>(" ", sequences[dictionaryKey]);
					break;
				}
			}

			return output;
		}
	}
}
