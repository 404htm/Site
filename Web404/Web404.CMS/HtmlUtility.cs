using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Web404.CMS
{
	public static class HtmlUtility
	{
		public static XElement FixLinks(this XElement element, Func<string, string> linkConversion)
		{
			var images = element.Descendants("img");
			foreach(var img in images)
			{
				var url = (string)img.Attribute("src");
				if(!IsAbsolute(url))
				{
					img.Attribute("src").Value = linkConversion(url);
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
