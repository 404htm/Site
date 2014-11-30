﻿using System;
using System.Collections.Generic;
namespace Web404.CMS
{
	public interface ICmsManager
	{
		//object GetPage(int PageID);
		//Page GetPage(string pageUrl);
		//string GetPageContent(string ID);
		IList<PostSummary> GetPostSummaries(int start = 0, int? pageCount = null);
		//System.Collections.Generic.List<PageSummary> GetPageSummaries(int start = 0, int? pageCount = null);
		//Page GetSectionDefaultPage(string sectionName);
		//System.Collections.Generic.List<Page> GetSectionPages(string sectionName);
		IList<PostSummary> GetTagPostSummaries(string tag, int start = 0, int? pageCount = null);

		string GetPostContent(string Partition, string Name);

		Post GetPost(string partition, string ID);
	}
}
