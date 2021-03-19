using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class UserVm
	{
		public string FirstName
		{
			get;
			set;
		}

		public string FullName
		{
			get
			{
				return string.Format("{0} {1}", this.FirstName, this.LastName);
			}
		}

		public string LastName
		{
			get;
			set;
		}

		public UserVm()
		{
		}
	}
}