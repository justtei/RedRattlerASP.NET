using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class PdfBrochure
	{
		public DateTime DateAdded
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Position
		{
			get;
			set;
		}

		public PdfBrochure()
		{
		}
	}
}