using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web404.CMS;

namespace Web404.Uploader
{
	class Program
	{
		static void Main(string[] args)
		{
			string directory;

			if(args.Count() < 1)
			{
				Console.WriteLine("Enter Directory Name:");
				directory = Console.ReadLine();
			}
			else
			{
				directory = args[0];
			}


			var uploader = AzureDataLoader.CreateDevLoader();
			uploader.SetupEnvironment();

			var parser = new PostParser(uploader);
			parser.UploadDirectory(directory);
		}
	}
}
