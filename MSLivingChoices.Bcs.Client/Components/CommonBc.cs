using MSLivingChoices.Bcs.Client;
using MSLivingChoices.Entities.Client.DisplayOptions;
using MSLivingChoices.IDacs.Client;
using MSLivingChoices.IDacs.Client.Components;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Bcs.Client.Components
{
	public class CommonBc
	{
		private readonly ICommonDac _commonDac;

		private static CommonBc _commonBc;

		private readonly static object Locker;

		public static CommonBc Instance
		{
			get
			{
				if (CommonBc._commonBc == null)
				{
					lock (CommonBc.Locker)
					{
						if (CommonBc._commonBc == null)
						{
							CommonBc._commonBc = new CommonBc();
						}
					}
				}
				return CommonBc._commonBc;
			}
		}

		static CommonBc()
		{
			CommonBc.Locker = new object();
		}

		private CommonBc()
		{
			this._commonDac = ClientDacFactoryClient.GetConcreteFactory().GetCommonDac();
		}

		public Dictionary<int, List<CompetitiveItem>> GetCompetitiveItems(bool takeActiveOnly = true)
		{
			return this._commonDac.GetCompetitiveItems(takeActiveOnly);
		}
	}
}