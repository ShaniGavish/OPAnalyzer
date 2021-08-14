using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer
{
	public class AnalysisFlowManager : IAnalysisFlowManager
	{
		protected IDictionary<long, AnalysisFlow> m_AnalysisFlowDict;

		public AnalysisFlowManager()
		{
			m_AnalysisFlowDict = new Dictionary<long, AnalysisFlow>();
		}

		public AnalysisFlow GetAnalysisFlowById(long id)
		{
			if (!m_AnalysisFlowDict.ContainsKey(id))
			{
				throw new Exception("Analysis flow id does not exists");
			}
			return m_AnalysisFlowDict[id];
		}

		public void AddAnalysisFlow(AnalysisFlow analysisFlow)
		{
			if (m_AnalysisFlowDict.ContainsKey(analysisFlow.Id))
			{
				throw new Exception("Analysis flow id already exists");

			}
			m_AnalysisFlowDict.Add(analysisFlow.Id, analysisFlow);
		}
	}
}
