using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web404.AzureCMS;

namespace Web404.Uploader
{
	class Program
	{
		static void Main(string[] args)
		{
			var directory = @"C:\Users\Kelly Gendron\Source\Repos\BlogPosts\Articles\EFMisconceptions";
			var uploader = new AzureDataLoader("");
			var parser = new PostParser(uploader);
			parser.UploadDirectory(directory);
		}
	}
}
