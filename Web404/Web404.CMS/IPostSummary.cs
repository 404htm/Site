using System;
namespace Web404.CMS
{
	public interface IPostSummary
	{
		bool Active { get; set; }
		string Body { get; set; }
		DateTime Date { get; set; }
		int ID { get; set; }
		string Partition { get; set; }
		int PostTypeID { get; set; }
		string SID { get; set; }
		string Summary { get; set; }
		
		string Title { get; set; }
		string TagList { get; }

	}
}
