using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OPAnalyzer
{
	public class StackoverflowFetcher : WebFetcher
	{
		static readonly HttpClientHandler StackoverflowHandler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

		public StackoverflowFetcher() : base(
			"https://api.stackexchange.com/2.2/tags/highcharts/faq?site=stackoverflow", new HttpClient(StackoverflowHandler))
		{
		}

		protected override string[] ExtractDataFromResponseContent(string responseContent)
		{
			JObject responseContentAsJson = JObject.Parse(responseContent);
			JArray jsonDataArr = (JArray)responseContentAsJson["items"];
			string[] dataArr = new string[jsonDataArr.Count];
			for (int i = 0; i < jsonDataArr.Count; i++)
			{
				dataArr[i] = (string)jsonDataArr[i]["title"];
			}
			return dataArr;
		}
	}
}
