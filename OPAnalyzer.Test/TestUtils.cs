using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OPAnalyzer.Test
{
	public static class TestUtils
	{
		public static string[] RemoveShortItems(string[] dataToAnalyze)
		{
			List<string> stringList = new List<string>();
			foreach (string str in dataToAnalyze)
			{
				if (str.Length >= 5)
				{
					stringList.Add(str);
				}
			}

			return stringList.ToArray();
		}

		public static string[] RemoveSpaces(string[] dataToAnalyze)
		{
			List<string> stringList = new List<string>();
			foreach (string str in dataToAnalyze)
			{
				stringList.Add(str.Replace(" ", ""));
			}
			return stringList.ToArray();
		}

		public static AnalysisFlow CreateAnalysisFlow(long id = 1)
		{
			Step removeShortItems = new Step("Remove short items", "remove items which contains less than 5 characters", RemoveShortItems);
			Step removeSpaces = new Step("Remove spaces", "remove spaces from items", RemoveSpaces);
			Step[] steps = { removeShortItems, removeSpaces };
			return new AnalysisFlow(id, steps);
		}
	}
}
