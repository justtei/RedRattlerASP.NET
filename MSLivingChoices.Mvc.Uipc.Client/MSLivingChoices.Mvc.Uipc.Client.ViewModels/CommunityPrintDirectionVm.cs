using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class CommunityPrintDirectionVm : CommunityDetailsVm
	{
		public double StartLatitude
		{
			get;
			set;
		}

		public double StartLongitude
		{
			get;
			set;
		}

		public CommunityPrintDirectionVm()
		{
		}
	}
}