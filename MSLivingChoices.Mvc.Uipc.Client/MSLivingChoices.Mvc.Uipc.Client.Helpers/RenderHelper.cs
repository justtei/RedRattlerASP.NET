using System;
using System.Web;
using System.Web.Mvc;
using MSLivingChoices.Configuration;
using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using MSLivingChoices.Utilities;

namespace MSLivingChoices.Mvc.Uipc.Client.Helpers
{
	public static class RenderHelper
	{
		public static IHtmlString Json(this HtmlHelper helper, object data)
		{
			string value = JsHelper.MapToJson(data);
			return helper.Raw(value);
		}

		public static IHtmlString DatePlaceholder(this HtmlHelper helper)
		{
			string value = DateTime.Now.ToString(ConfigurationManager.Instance.ClientServerDateFormat);
			return helper.Raw(value);
		}

		public static IHtmlString Image(ImageVm vm, params string[] css)
		{
			return new HtmlString(Image(vm, isThumbnail: false, css).SafeToString(TagRenderMode.SelfClosing));
		}

		public static IHtmlString Thumbnail(ImageVm vm, params string[] css)
		{
			return new HtmlString(Image(vm, isThumbnail: true, css).SafeToString(TagRenderMode.SelfClosing));
		}

		public static IHtmlString ImageWithMicrodata(ImageVm vm, params string[] css)
		{
			TagBuilder tag = Image(vm, isThumbnail: false, css);
			tag.ItemProp("image");
			return new HtmlString(tag.SafeToString(TagRenderMode.SelfClosing));
		}

		public static IHtmlString ThumbnailWithMicrodata(ImageVm vm, params string[] css)
		{
			TagBuilder tag = Image(vm, isThumbnail: true, css);
			tag.ItemProp("image");
			return new HtmlString(tag.SafeToString(TagRenderMode.SelfClosing));
		}

		private static TagBuilder Image(ImageVm vm, bool isThumbnail, params string[] css)
		{
			if (vm == null)
			{
				return null;
			}
			string value = (isThumbnail ? vm.ThumbnailSrc : vm.Src);
			string arg = (isThumbnail ? vm.Src : vm.ThumbnailSrc);
			TagBuilder tagBuilder = new TagBuilder("img");
			tagBuilder.MergeAttribute("onerror", string.Format("this.onerror=function() {{ this.onerror=null; this.src=\"{1}\"}};this.src=\"{0}\"", arg, vm.OnErrorSrc));
			tagBuilder.MergeAttribute("alt", vm.Alt);
			tagBuilder.MergeAttribute("src", value);
			tagBuilder.MergeAttribute("title", vm.Alt);
			tagBuilder.Css(css);
			return tagBuilder;
		}

		private static void Css(this TagBuilder tag, params string[] classes)
		{
			foreach (string text in classes)
			{
				if (!text.IsNullOrEmpty())
				{
					tag.AddCssClass(text);
				}
			}
		}

		private static void ItemProp(this TagBuilder tag, string value)
		{
			if (tag != null && !value.IsNullOrEmpty())
			{
				tag.MergeAttribute("itemprop", value);
			}
		}

		private static void ItemType(this TagBuilder tag, string typeUrl)
		{
			if (tag != null && !typeUrl.IsNullOrEmpty())
			{
				tag.MergeAttribute("itemscope", string.Empty);
				tag.MergeAttribute("itemtype", typeUrl);
			}
		}

		private static string SafeToString(this TagBuilder tag, TagRenderMode mode = TagRenderMode.Normal)
		{
			return tag?.ToString(mode);
		}
	}

}