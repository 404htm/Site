using System;
namespace Web404.CMS
{
	public interface IFileManger
	{
		Uri GetFileURI(string year, string postID, string fileName);

		void SaveRelatedFile(string year, string postID, string fileName, System.IO.Stream fileBody);
		void SetupEnvironment();
	}
}
