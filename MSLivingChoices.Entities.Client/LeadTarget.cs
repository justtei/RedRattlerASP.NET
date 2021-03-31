using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class LeadTarget
	{
		public LeadTargetData Data
		{
			get;
			set;
		}

		public long InnerId
		{
			get;
			set;
		}

		public long LeadId
		{
			get;
			set;
		}

		public string OuterId
		{
			get;
			set;
		}

		public LeadTargetType Type
		{
			get;
			set;
		}

		public LeadTarget()
		{
			this.Data = new LeadTargetData();
		}
	}
}