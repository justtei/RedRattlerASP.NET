using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Security;
using UserManagementSystem.Business;
using UserManagementSystem.DAL.Interfaces;
using UserManagementSystem.DAL.Interfaces.Components;
using UserManagementSystem.Entities;

namespace UserManagementSystem.Business.Components
{
	public class PublicationBc
	{
		private readonly IPublicationDac _publicationDac;

		private static PublicationBc _publicationBc;

		private readonly static object Locker;

		public static PublicationBc Instance
		{
			get
			{
				if (PublicationBc._publicationBc == null)
				{
					lock (PublicationBc.Locker)
					{
						if (PublicationBc._publicationBc == null)
						{
							PublicationBc._publicationBc = new PublicationBc();
						}
					}
				}
				return PublicationBc._publicationBc;
			}
		}

		static PublicationBc()
		{
			PublicationBc.Locker = new object();
		}

		private PublicationBc()
		{
			this._publicationDac = DacFactoryClient.GetFactory().GetPublicationDac();
		}

		public List<BrandType> GetBrands()
		{
			return this._publicationDac.GetBrands();
		}

		public List<Publication> GetPublications(Guid userId)
		{
			List<Publication> publications;
			MembershipUser user = Membership.GetUser(userId);
			if (user != null)
			{
				publications = (Roles.IsUserInRole(user.UserName, "Admin") ? this._publicationDac.GetAllPublications() : this._publicationDac.GetPublications(userId));
			}
			else
			{
				publications = new List<Publication>();
			}
			return publications;
		}

		public List<Publication> GetPublications(BrandType brandType)
		{
			return this._publicationDac.GetPublications(brandType);
		}

		public List<Publication> GetPublications(int brandTypeId)
		{
			return this._publicationDac.GetPublications(new BrandType()
			{
				Id = brandTypeId
			});
		}

		public List<Publication> GetPublications(string brandType)
		{
			BrandType brandType1 = this._publicationDac.GetBrands().FirstOrDefault<BrandType>((BrandType b) => b.Description == brandType);
			return this._publicationDac.GetPublications(brandType1);
		}
	}
}