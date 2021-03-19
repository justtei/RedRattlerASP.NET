using MSLivingChoices.Bcs.Admin;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using System;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class SeoBc
	{
		private readonly ISeoDac _seoDac;

		private static SeoBc _seoBc;

		private readonly static object Locker;

		public static SeoBc Instance
		{
			get
			{
				if (SeoBc._seoBc == null)
				{
					lock (SeoBc.Locker)
					{
						if (SeoBc._seoBc == null)
						{
							SeoBc._seoBc = new SeoBc();
						}
					}
				}
				return SeoBc._seoBc;
			}
		}

		static SeoBc()
		{
			SeoBc.Locker = new object();
		}

		private SeoBc()
		{
			this._seoDac = AdminDacFactoryClient.GetConcreteFactory().GetSeoDac();
		}

		public Seo GetSeoMetaData(Seo seo)
		{
			return this._seoDac.GetSeoMetaData(seo);
		}

		public Seo SaveSeoMetaData(Seo seo)
		{
			return this._seoDac.SaveSeoMetaData(seo);
		}
	}
}