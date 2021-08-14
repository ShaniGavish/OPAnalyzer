using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OPAnalyzer.Test
{
	[TestClass]
	public class AnalysisFlowManagerTest : AnalysisFlowManager
	{
		[TestMethod]
		public void Test_AddAnalysisFlow()
		{
			AnalysisFlow analysisFlow = TestUtils.CreateAnalysisFlow(1);
			AddAnalysisFlow(analysisFlow);
			Assert.IsTrue(this.m_AnalysisFlowDict.ContainsKey(1));
		}

		[TestMethod]
		public void Test_GetExceptionForAnalysisFlowAlreadyExists()
		{
			AnalysisFlow analysisFlow = TestUtils.CreateAnalysisFlow(1);
			AddAnalysisFlow(analysisFlow);
			Assert.ThrowsException<Exception>(() => AddAnalysisFlow(analysisFlow));
		}

		[TestMethod]
		public void Test_GetAnalysisFlow()
		{
			AnalysisFlow analysisFlow = TestUtils.CreateAnalysisFlow(1);
			AddAnalysisFlow(analysisFlow);
			AnalysisFlow expected = analysisFlow;
			AnalysisFlow actual = GetAnalysisFlowById(1);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_GetExceptionForAnalysisFlowNotExists()
		{
			AnalysisFlow analysisFlow = TestUtils.CreateAnalysisFlow(1);
			AddAnalysisFlow(analysisFlow);
			Assert.ThrowsException<Exception>(() => GetAnalysisFlowById(3));
		}
	}
}
