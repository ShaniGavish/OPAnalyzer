using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OPAnalyzer.Test
{
	[TestClass]
	public class APITest
	{
		[TestMethod]
		public void Test_AnalyzeByDataSourceOnly()
		{
			string[] data =
				{
					"Lorem ipsum dolor sit amet, consectetur adipiscing elit",
					"Duis posuere luctus nulla",
					"non",
					"Sed rhoncus turpis leo, vel porta mi posuere nec"
				};

			MockFetcher mockFetcher = new MockFetcher(data);
			APIAnalyzer apiAnalyzer = new APIAnalyzer(new MockFetcherFactory(mockFetcher), new AnalysisFlowManager());
			string[] expected = data;
			string[] actual = apiAnalyzer.Analyze("mock");
			CollectionAssert.AreEquivalent(expected, actual);
		}

		[TestMethod]
		public void Test_AnalyzeByDataSourceAndAnalysisFlow()
		{
			string[] data =
				{
					"Lorem ipsum dolor sit amet, consectetur adipiscing elit",
					"Duis posuere luctus nulla",
					"non",
					"Sed rhoncus turpis leo, vel porta mi posuere nec"
				};

			AnalysisFlowManager analysisFlowManager = new AnalysisFlowManager();
			AnalysisFlow analysisFlow = TestUtils.CreateAnalysisFlow();
			analysisFlowManager.AddAnalysisFlow(analysisFlow);
			MockFetcher mockFetcher = new MockFetcher(data);
			APIAnalyzer apiAnalyzer = new APIAnalyzer(new MockFetcherFactory(mockFetcher), analysisFlowManager);
			string[] expected = {
					                    "Loremipsumdolorsitamet,consecteturadipiscingelit",
					                    "Duisposuereluctusnulla",
					                    "Sedrhoncusturpisleo,velportamiposuerenec"
				                    };
			string[] actual = apiAnalyzer.Analyze("mock", analysisFlow.Id);
			CollectionAssert.AreEquivalent(expected, actual);
		}

	}
}
