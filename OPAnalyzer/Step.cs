using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer
{
	public delegate string[] ExecuteDelegate(string[] data);

	public class Step
	{
		private string m_Name;
		private string m_Description;
		private ExecuteDelegate m_Executor;

		public Step(string name, string description, ExecuteDelegate executor)
		{
			this.m_Name = name;
			this.m_Description = description;
			this.m_Executor = executor;
		}

		public Step(Step otherStep)
		{
			this.m_Name = otherStep.Name;
			this.m_Description = otherStep.Description;
			this.m_Executor = otherStep.m_Executor;
		}

		public string Name
		{
			get { return this.m_Name; }
		}

		public string Description
		{
			get { return this.m_Description; }
		}

		public ExecuteDelegate Executor
		{
			get { return this.m_Executor; }
		}

		public string[] Execute(string[] data)
		{
			return this.m_Executor.Invoke(data);
		}
	}
}
