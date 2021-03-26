using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class AutocompleteVm
	{
		public string End
		{
			get;
			set;
		}

		public string LookupLocation
		{
			get
			{
				return string.Format("{0}{1}", this.Start, this.End);
			}
		}

		public string Start
		{
			get;
			set;
		}

		public string Template
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public AutocompleteVm()
		{
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}", this.Template, this.LookupLocation);
		}
	}
}