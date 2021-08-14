using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OPAnalyzer.Test
{
	[TestClass]
	public class AnalysisFlowTest
	{
		[TestMethod]
		public void Test_ExecuteAnalysisFlow()
		{
			string[] dataToAnalyze =
				{
					"Lorem ipsum dolor sit amet, consectetur adipiscing elit",
					"Ipsu"
				};
			AnalysisFlow analysisFlow = TestUtils.CreateAnalysisFlow();
			string[] expected =
				{
					"Loremipsumdolorsitamet,consecteturadipiscingelit"
				};
			string[] actual = analysisFlow.Execute(dataToAnalyze);

			CollectionAssert.AreEquivalent(expected, actual);
		}
	}
}
