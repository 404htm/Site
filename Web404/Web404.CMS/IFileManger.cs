using System;
namespace Web404.CMS
{
	interface IFileManger
	{
		Uri GetFileURI(string year, string postID, string fileName);
		string GetPostContent(string year, string postName);
		void SavePostContent(string year, string postName, string postBody);
		void SaveRelatedFile(string year, string postID, string fileName, System.IO.Stream fileBody);
		void SetupEnvironment();
	}
}
