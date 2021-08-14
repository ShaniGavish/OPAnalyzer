using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer.Test
{
	public class MockFetcherFactory : IFetcherFactory
	{
		private IFetcher m_fetcher;

		public MockFetcherFactory(IFetcher fetcher)
		{
			m_fetcher = fetcher;
		}

		public IFetcher GetFetcher(string dataSourceName)
		{
			return this.m_fetcher;
		}
	}
}
