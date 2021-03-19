using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface IOwnerDac
	{
		List<Owner> GetAll();

		List<Owner> GetAllByOwnerType(OwnerType ownerType, int? pageNumber, int? pageSize, out int totalCount);

		List<Owner> GetAllByOwnerType(OwnerType ownerType);

		Owner GetById(long id);

		Owner SaveNewOwner(Owner entity);
	}
}