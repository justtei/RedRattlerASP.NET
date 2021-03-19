using System;
using System.Collections.Generic;
using UserManagementSystem.DAL.Commands;
using UserManagementSystem.DAL.Interfaces.Components;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Components
{
	public class SqlPublicationDac : IPublicationDac
	{
		public SqlPublicationDac()
		{
		}

		public List<Publication> GetAllPublications()
		{
			GetUserPublicationsCommand getUserPublicationsCommand = new GetUserPublicationsCommand();
			getUserPublicationsCommand.Execute();
			return getUserPublicationsCommand.CommandResult;
		}

		public List<BrandType> GetBrands()
		{
			GetBrandsCommand getBrandsCommand = new GetBrandsCommand();
			getBrandsCommand.Execute();
			return getBrandsCommand.CommandResult;
		}

		public List<Publication> GetPublications(Guid userId)
		{
			GetUserPublicationsCommand getUserPublicationsCommand = new GetUserPublicationsCommand(userId);
			getUserPublicationsCommand.Execute();
			return getUserPublicationsCommand.CommandResult;
		}

		public List<Publication> GetPublications(BrandType brand)
		{
			GetPublicationsCommand getPublicationsCommand = new GetPublicationsCommand(brand.Id);
			getPublicationsCommand.Execute();
			return getPublicationsCommand.CommandResult;
		}
	}
}