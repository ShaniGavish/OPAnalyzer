using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer
{
	public class APIAnalyzer : IAnalyzer
	{
		private IFetcherFactory m_FetcherFactory;
		private AnalysisFlowManager m_AnalysisFlowManager;
		public APIAnalyzer(IFetcherFactory fetcherFactory, AnalysisFlowManager analysisFlowManager)
		{
			m_FetcherFactory = fetcherFactory;
			m_AnalysisFlowManager = analysisFlowManager;
		}

		public string[] Analyze(string dataSourceName)
		{
			IFetcher fetcher = m_FetcherFactory.GetFetcher(dataSourceName);
			string[] dataStrings = fetcher.FetchData();
			return dataStrings;
		}

		public string[] Analyze(string datasourceName, long analysisFlowId)
		{
			string[] dataStrings = Analyze(datasourceName);
			AnalysisFlow analysisFlow = this.m_AnalysisFlowManager.GetAnalysisFlowById(analysisFlowId);
			return analysisFlow.Execute(dataStrings);
		}
	}
}
