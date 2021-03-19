using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlOwnerDac : IOwnerDac
	{
		private readonly List<Owner> _owners;

		public SqlOwnerDac()
		{
			_owners = new List<Owner>();
			for (int k = 1; k <= 5; k++)
			{
				Owner owner = new Owner
				{
					Id = k,
					OwnerType = OwnerType.PropertyManager,
					Name = "Name" + k,
					Address = new Address(),
					Emails = new List<Email>
				{
					new Email
					{
						EmailTypeId = k,
						Value = $"email{k}@mail.ru"
					}
				},
					Contacts = new List<Contact>
				{
					new Contact
					{
						FirstName = "FirstName" + k,
						LastName = "LastName" + k
					}
				}
				};
				_owners.Add(owner);
			}
			for (int j = 6; j <= 10; j++)
			{
				Owner owner2 = new Owner
				{
					Id = j,
					OwnerType = OwnerType.Builder,
					Name = "Name" + j,
					Address = new Address(),
					Emails = new List<Email>
				{
					new Email
					{
						EmailTypeId = j,
						Value = $"email{j}@mail.ru"
					}
				},
					Contacts = new List<Contact>
				{
					new Contact
					{
						FirstName = "FirstName" + j,
						LastName = "LastName" + j
					}
				}
				};
				_owners.Add(owner2);
			}
			for (int i = 11; i <= 15; i++)
			{
				Owner owner3 = new Owner
				{
					Id = i,
					OwnerType = OwnerType.Advertiser,
					Name = "Name" + i,
					Address = new Address(),
					Emails = new List<Email>
				{
					new Email
					{
						EmailTypeId = i,
						Value = $"email{i}@mail.ru"
					}
				},
					Contacts = new List<Contact>
				{
					new Contact
					{
						FirstName = "FirstName" + i,
						LastName = "LastName" + i
					}
				}
				};
				_owners.Add(owner3);
			}
		}

		public List<Owner> GetAllByOwnerType(OwnerType ownerType, int? pageNumber, int? pageSize, out int totalCount)
		{
			pageNumber = pageNumber ?? ConfigurationManager.Instance.DefaultGridPageNumber;
			pageSize = pageSize ?? ConfigurationManager.Instance.DefaultGridPageSize;
			GetAllByOwnerTypeWithPagingCommand command = new GetAllByOwnerTypeWithPagingCommand(ownerType, pageNumber.Value, pageSize.Value);
			command.Execute();
			totalCount = command.GetTotalCount();
			return command.CommandResult;
		}

		public List<Owner> GetAllByOwnerType(OwnerType ownerType)
		{
			GetAllByOwnerTypeCommand getAllByOwnerTypeCommand = new GetAllByOwnerTypeCommand(ownerType);
			getAllByOwnerTypeCommand.Execute();
			return getAllByOwnerTypeCommand.CommandResult;
		}

		public List<Owner> GetAll()
		{
			return _owners;
		}

		public Owner SaveNewOwner(Owner entity)
		{
			SaveOwnerCommand saveOwnerCommand = new SaveOwnerCommand(entity);
			saveOwnerCommand.Execute();
			return saveOwnerCommand.CommandResult;
		}

		public Owner GetById(long id)
		{
			GetOwnerByIdCommand getOwnerByIdCommand = new GetOwnerByIdCommand(id);
			getOwnerByIdCommand.Execute();
			return getOwnerByIdCommand.CommandResult;
		}
	}
}