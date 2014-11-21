using System;
namespace Web404.CMS
{
	public interface IDataLoader
	{
		Uri GetFileURI(string year, string postID, string fileName);
		void SavePost(PostDetail post);
		void SaveRelatedFile(string year, string postID, string fileName, System.IO.Stream fileBody);
		void SetupEnvironment();
	}
}
