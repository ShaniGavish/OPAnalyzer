using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer
{
	public class AnalysisFlow
	{
		private long m_Id;
		private Step[] m_Steps;

		public AnalysisFlow(long id, Step[] steps)
		{
			this.m_Id = id;
			this.m_Steps = new Step[steps.Length];
			for (int i = 0; i < steps.Length; i++)
			{
				this.m_Steps[i] = new Step(steps[i]);
			}
		}

		public long Id
		{
			get { return this.m_Id; }
		}

		public string[] Execute(string[] dataToAnalyze)
		{
			foreach (Step step in m_Steps)
			{
				dataToAnalyze = step.Execute(dataToAnalyze);
			}
			return dataToAnalyze;
		}
	}
}
