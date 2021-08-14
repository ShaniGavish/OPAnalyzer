using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace OPAnalyzer
{
	public abstract class WebFetcher : IFetcher
	{
		private readonly string  r_Url;
		private readonly HttpClient r_Client;

		protected WebFetcher(string url, HttpClient client)
		{
			this.r_Url = url;
			this.r_Client = client;
		}

		private async Task<string> fetchHttpRequest(string url)
		{
			HttpResponseMessage response = await r_Client.GetAsync(url);
			if (!response.IsSuccessStatusCode)
			{
				throw new Exception("Failed to fetch data");
			}
			return await response.Content.ReadAsStringAsync();
		}

		protected abstract string[] ExtractDataFromResponseContent(string responseContent);

		public string[] FetchData()
		{
			string content = fetchHttpRequest(r_Url).GetAwaiter().GetResult();
			return ExtractDataFromResponseContent(content);
		}
	}
}
