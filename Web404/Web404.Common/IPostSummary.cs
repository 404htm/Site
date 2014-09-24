using System;
namespace Web404.Common
{
	public interface IPostSummary
	{
		string ID { get; set;}
		string Partition { get; set;}
		bool Active { get; set; }
		DateTime Date { get; }
		string Summary { get; set; }
		string Tags { get; set; }
		string Title { get; set; }
		PostType Type { get; set; }
	}
}
