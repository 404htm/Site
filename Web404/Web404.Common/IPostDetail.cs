using System;
namespace Web404.Common
{
	public interface IPostDetail : IPostSummary
	{
		string ArticleBody { get; set; }
	}
}
