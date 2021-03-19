using System;
using System.Collections.Generic;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Interfaces.Components
{
	public interface IPublicationDac
	{
		List<Publication> GetAllPublications();

		List<BrandType> GetBrands();

		List<Publication> GetPublications(Guid userId);

		List<Publication> GetPublications(BrandType brand);
	}
}