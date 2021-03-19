using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common
{
	public class KeyValuePairVm<TK, TV>
	{
		public TK Key
		{
			get;
			set;
		}

		public TV Value
		{
			get;
			set;
		}

		public KeyValuePairVm()
		{
		}
	}
}