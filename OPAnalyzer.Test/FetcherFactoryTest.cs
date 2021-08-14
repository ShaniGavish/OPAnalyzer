using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OPAnalyzer.Test
{
	[TestClass]
	public class FetcherFactoryTest
	{
		[TestMethod]
		public void Test_GetStackoverflowFetcher()
		{
			string stackoverflowDataSource = "stackoverflow";
			FetcherFactory fetcherFactory = new FetcherFactory();
			Type expected = typeof(StackoverflowFetcher);
			Type actual = fetcherFactory.GetFetcher(stackoverflowDataSource).GetType();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_GetStackoverflowFetcherIgnoreCapitalLetters()
		{
			string stackoverflowDataSource = "StackOverfLoW";
			FetcherFactory fetcherFactory = new FetcherFactory();
			Type expected = typeof(StackoverflowFetcher);
			Type actual = fetcherFactory.GetFetcher(stackoverflowDataSource).GetType();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_GetGithubFetcher()
		{
			string githubDataSource = "gitHub";
			FetcherFactory fetcherFactory = new FetcherFactory();
			Type expected = typeof(GithubFetcher);
			Type actual = fetcherFactory.GetFetcher(githubDataSource).GetType();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_GetGithubFetcherIgnoreCapitalLetters()
		{
			string githubDataSource = "GiTHuB";
			FetcherFactory fetcherFactory = new FetcherFactory();
			Type expected = typeof(GithubFetcher);
			Type actual = fetcherFactory.GetFetcher(githubDataSource).GetType();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_GetExceptionForInvalidDataSource()
		{
			string invalidDataSource = "AAAA";
			FetcherFactory fetcherFactory = new FetcherFactory();
			Assert.ThrowsException<Exception>(() => fetcherFactory.GetFetcher(invalidDataSource));
		}
	}
}
