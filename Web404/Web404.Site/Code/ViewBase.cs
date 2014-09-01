using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web404.Site
{
	public abstract class ViewBase<TModel> : WebViewPage<TModel>
	{
		public string Title 
		{
			get {  return ViewBag.Title; }
			set {  ViewBag.Title = value;}
		}
		public bool FullScreen {
			get {  return ViewBag.FullScreen??false; }
			set {  ViewBag.FullScreen = value; }
		}

		public override void InitHelpers()
		{
			base.InitHelpers();
		}

		public override void Execute()
		{
		}
	}

	public abstract class ViewBase : ViewBase<object>
	{

	}
}