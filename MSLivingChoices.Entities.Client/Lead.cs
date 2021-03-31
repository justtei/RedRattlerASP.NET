using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class Lead
	{
		public MSLivingChoices.Entities.Client.Customer Customer
		{
			get;
			set;
		}

		public LeadData Data
		{
			get;
			set;
		}

		public long Id
		{
			get;
			set;
		}

		public InquiryType Inquiry
		{
			get;
			set;
		}

		public string Message
		{
			get;
			set;
		}

		public LeadMetadata Metadata
		{
			get;
			set;
		}

		public List<LeadTarget> Targets
		{
			get;
			set;
		}

		public Lead()
		{
			this.Targets = new List<LeadTarget>();
			this.Metadata = new LeadMetadata();
			this.Data = new LeadData();
		}
	}
}