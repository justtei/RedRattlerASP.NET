using MSLivingChoices.Bcs.Admin;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class OwnerBc
	{
		private readonly IOwnerDac _ownerDac;

		private static OwnerBc _ownerBc;

		private readonly static object Locker;

		public static OwnerBc Instance
		{
			get
			{
				if (OwnerBc._ownerBc == null)
				{
					lock (OwnerBc.Locker)
					{
						if (OwnerBc._ownerBc == null)
						{
							OwnerBc._ownerBc = new OwnerBc();
						}
					}
				}
				return OwnerBc._ownerBc;
			}
		}

		static OwnerBc()
		{
			OwnerBc.Locker = new object();
		}

		private OwnerBc()
		{
			this._ownerDac = AdminDacFactoryClient.GetConcreteFactory().GetOwnerDac();
		}

		public List<Owner> GetAll()
		{
			return this._ownerDac.GetAll();
		}

		public List<Owner> GetAllByOwnerType(OwnerType ownerType, int? pageNumber, int? pageSize, out int totalCount)
		{
			return this._ownerDac.GetAllByOwnerType(ownerType, pageNumber, pageSize, out totalCount);
		}

		public List<Owner> GetAllByOwnerType(OwnerType ownerType)
		{
			return this._ownerDac.GetAllByOwnerType(ownerType);
		}

		public Owner GetById(long id)
		{
			return this._ownerDac.GetById(id);
		}

		public Owner SaveNewOwner(Owner owner)
		{
			Guid? currentUserId = AccountBc.Instance.GetCurrentUserId();
			if (currentUserId.HasValue)
			{
				owner.UserId = currentUserId.Value;
			}
			Owner owner1 = this._ownerDac.SaveNewOwner(owner);
			ImageBc.Instance.ProcessImages(ImageOwner.Owner, owner1.Id.Value);
			return owner1;
		}
	}
}