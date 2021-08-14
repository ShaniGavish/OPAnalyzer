using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OPAnalyzer.Test
{
	[TestClass]
	public class ExtractDataTest
	{
		[TestClass]
		public class ExtractStackoverflowDataTest : StackoverflowFetcher
		{
			[TestMethod]
			public void Test_ExtractDataFromStackoverflowResponseContent()
			{
				string mockResponseContent = "{\"items\": [{\"title\": \"Title 1\"}, {\"title\": \"Title 2\"}]}";
				string[] expected = { "Title 1", "Title 2" };
				string[] actual = ExtractDataFromResponseContent(mockResponseContent);
				CollectionAssert.AreEquivalent(expected, actual);
			}
		}

		[TestClass]
		public class ExtractGithubDataTest : GithubFetcher
		{
			[TestMethod]
			public void Test_ExtractDataFromGitHubResponseContent()
			{
				string mockResponseContent = "[{\"commit\": {\"message\": \"message 1\"}}, {\"commit\": {\"message\": \"message 2\"}}]";
				string[] expected = { "message 1", "message 2" };
				string[] actual = ExtractDataFromResponseContent(mockResponseContent);
				CollectionAssert.AreEquivalent(expected, actual);
			}
		}
	}
}
