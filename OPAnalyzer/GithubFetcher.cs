using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OPAnalyzer
{

	public class GithubFetcher : WebFetcher
	{
		public GithubFetcher() : base(
			"https://api.github.com/repos/highcharts/highcharts/commits", initClient())
		{
		}

		private static HttpClient initClient()
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("User-Agent", "OPAnalyzer");
			return client;
		}

		protected override string[] ExtractDataFromResponseContent(string responseContent)
		{
			JArray responseContentAsJsonArray = JArray.Parse(responseContent);
			string[] dataArr = new string[responseContentAsJsonArray.Count];
			for (int i = 0; i < responseContentAsJsonArray.Count; i++)
			{
				dataArr[i] = (string)responseContentAsJsonArray[i]["commit"]["message"];
			}
			return dataArr;
		}
	}
}
