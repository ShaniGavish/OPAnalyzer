using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPAnalyzer.Test
{
	public class MockFetcher : IFetcher
	{
		private string[] m_data;

		public MockFetcher(string[] data)
		{
			m_data = new string[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				m_data[i] = data[i];
			}
		}

		public string[] FetchData()
		{
			return this.m_data;
		}
	}
}
