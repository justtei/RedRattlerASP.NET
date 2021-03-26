using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class SearchVm<TResult> : SearchWithServicesVm
	{
		public TResult Result
		{
			get;
			set;
		}

		public SearchVm()
		{
		}
	}
}