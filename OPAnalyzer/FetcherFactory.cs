using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer
{
	public class FetcherFactory : IFetcherFactory
	{
		private static class DataSourceNames
		{
			public const string stackoverflow = "stackoverflow";
			public const string github = "github";
		}

		public IFetcher GetFetcher(string dataSourceName)
		{
			if (string.Equals(dataSourceName, DataSourceNames.stackoverflow, StringComparison.OrdinalIgnoreCase))
			{
				return new StackoverflowFetcher();
			}
			else if (string.Equals(dataSourceName, DataSourceNames.github, StringComparison.OrdinalIgnoreCase))
			{
				return new GithubFetcher();
			}

			throw new Exception("Invalid data source name");
		}
	}
}
