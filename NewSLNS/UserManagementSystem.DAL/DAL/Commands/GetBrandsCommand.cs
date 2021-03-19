using System;
using System.Collections.Generic;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetBrandsCommand : BaseCommand<List<BrandType>>
	{
		public GetBrandsCommand()
		{
		}

		protected override void CommandBody(UMSEntities context)
		{
			List<BrandType> brandTypes = new List<BrandType>();
			foreach (Brand brand in (IEnumerable<Brand>)context.Brands)
			{
				brandTypes.Add(new BrandType(brand.BrandId, brand.Description));
			}
			this.CommandResult = brandTypes;
		}
	}
}