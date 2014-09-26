using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Web404.Common
{
	public static class HtmlUtility
	{
		public static XElement FixLinks(this XElement element, string StorageAcctURL)
		{
			
			Uri baseUri = new Uri(StorageAcctURL);

			var images = element.Descendants("img");
			foreach(var img in images)
			{
				var url = (string)img.Attribute("src");
				if(!IsAbsolute(url))
				{
					var fixedLink = new Uri(baseUri, url);
					img.Attribute("src").Value = fixedLink.ToString();
				}
			}

			return element;
		}

		static bool IsAbsolute(string url)
		{
			Uri result;
			return Uri.TryCreate(url, UriKind.Absolute, out result);
		}
	}
}
