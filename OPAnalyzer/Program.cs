using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer
{
	public class Program
	{
		static AnalysisFlowManager CreateAnalysisFlowManager()
		{
			AnalysisFlow analysisFlow = CreateAnalysisFlow();
			AnalysisFlowManager analysisFlowManager = new AnalysisFlowManager();
			return analysisFlowManager;
		}

		static AnalysisFlow CreateAnalysisFlow()
		{
			Step[] steps = CreateSteps();
			return new AnalysisFlow(1, steps);
		}


		static Step[] CreateSteps()
		{
			Step removeShortItems = new Step("Remove short items", "remove items which contains less than 5 characters", RemoveShortItems);
			Step removeSpaces = new Step("Remove spaces", "remove spaces from items", RemoveSpaces);
			Step[] steps = { removeShortItems, removeSpaces };
			return steps;
		}
 
		static string[] RemoveShortItems(string[] dataToAnalyze)
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

		static string[] RemoveSpaces(string[] dataToAnalyze)
		{
			List<string> stringList = new List<string>();
			foreach (string str in dataToAnalyze)
			{
				stringList.Add(str.Replace(" ", ""));
			}
			return stringList.ToArray();
		}


		static void AppendDataToStringBuilder(string[] data, StringBuilder stringBuilder)
		{
			foreach(string str in data)
			{
				stringBuilder.AppendLine(str);
			}

			stringBuilder.AppendLine();
		}

		static void Main()
		{
			AnalysisFlow analysisFlow = CreateAnalysisFlow();
			AnalysisFlowManager analysisFlowManager = CreateAnalysisFlowManager();
			analysisFlowManager.AddAnalysisFlow(analysisFlow);
			FetcherFactory fetcherFactory = new FetcherFactory();
			APIAnalyzer apiAnalyzer =  new APIAnalyzer(fetcherFactory, analysisFlowManager);
			
			StringBuilder dataStringBuilder = new StringBuilder();

			string[] githubData = apiAnalyzer.Analyze("stackoverflow");
			dataStringBuilder.AppendLine("Stackoverflow Data: ");
			AppendDataToStringBuilder(githubData, dataStringBuilder);

			string[] githubFilterData = apiAnalyzer.Analyze("stackoverflow", analysisFlow.Id);
			dataStringBuilder.AppendLine("Stackoverflow Filter Data: ");
			AppendDataToStringBuilder(githubFilterData, dataStringBuilder);

			Console.WriteLine(dataStringBuilder);
		}
	}
}
