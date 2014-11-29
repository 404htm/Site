﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web404.CMS
{
	public partial class Post : IPostSummary
	{
		public string TagList 
		{
			get { return string.Join(",", Tags.Select(t => t.Name)); }
		}
	}
}
