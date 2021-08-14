using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer
{
	public interface IAnalyzer
	{
		string[] Analyze(string dataSourceName);
		string[] Analyze(string datasourceName, long analysisFlowId);
	}
}
