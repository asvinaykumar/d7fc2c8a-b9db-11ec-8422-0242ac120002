using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestIncreasingSubSequence
{
    public class LargestSequence
    {
		public string Find(string numberSequence)
		{
			int[] array = numberSequence.Split(' ').Select(p => int.Parse(p)).ToArray();
			List<int> list = new List<int>();
			List<int> longestList = new List<int>();
			int currentMax;
			int highestCount = 0;
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
						if (list.Count > 1)
						{
							sequences.Add(key, list);
							key++;
							// Compare previous highest subsequence
							if (highestCount < list.Count)
							{
								highestCount = list.Count;
								//longestList = new List<int>(list);
							}
						}

						list = new List<int>();
					}
				}

				if (list.Count > 1)
				{
					sequences.Add(key, list);
					key++;
					// Compare previous highest subsequence
					if (highestCount < list.Count)
					{
						highestCount = list.Count;
						//longestList = new List<int>(list);
					}
				}

				list = new List<int>();
			}
			Console.WriteLine();

			string output = string.Empty;
			foreach (int dicKey in sequences.Keys)
			{
				if (sequences[dicKey].Count == highestCount)
				{
					output = string.Join<int>(" ", sequences[dicKey]);
					break;
				}
			}

			return output;
		}
	}
}
