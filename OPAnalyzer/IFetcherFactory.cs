using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer
{
	public interface IFetcherFactory
	{
		IFetcher GetFetcher(string dataSourceName);
	}
}
