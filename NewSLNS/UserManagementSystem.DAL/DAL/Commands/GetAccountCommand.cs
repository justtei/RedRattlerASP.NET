using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetAccountCommand : BaseCommand<Account>
	{
		private readonly Guid _userId;

		public GetAccountCommand(Guid userId)
		{
			this._userId = userId;
		}

		protected override void CommandBody(UMSEntities context)
		{
			User user = context.Users.Include("Emails").Include("Emails.EmailType").Include("UserToBooks").Include("UserToBooks.Book").Include("UserToBooks.Book.Brand").Include("Phones").Include("Phones.PhoneType").Include("Addresses").SingleOrDefault<User>((User a) => a.UserId == this._userId);
			if (user == null)
			{
				throw new Exception("Selected null account form DB");
			}
			Account account = new Account()
			{
				Id = user.UserId,
				PrimaryEmail = user.PrimaryEmail,
				FirstName = user.FirstName,
				LastName = user.LastName
			};
			account.CommunicationSettings.HasLeads = user.HasLeadsNotifications;
			account.CommunicationSettings.HasNotifications = user.HasNotifications;
			account.CreateUserId = user.CreateUserId;
			account.CreateDate = user.CreateDate;
			account.ModifyUserId = user.ModifyUserId;
			account.ModifyDate = user.ModifyDate;
			account.Phones = (
				from dbPhone in user.Phones
				select new UserManagementSystem.Entities.Phone(dbPhone.PhoneId, new UserManagementSystem.Entities.PhoneType(dbPhone.PhoneTypeReference.Value.PhoneTypeId, dbPhone.PhoneType.Description), dbPhone.Phone1, dbPhone.CreateDate, dbPhone.ModifyDate, dbPhone.CreateUserId, dbPhone.ModifyUserId)).ToList<UserManagementSystem.Entities.Phone>();
			account.Emails = (
				from dbEmail in user.Emails
				select new UserManagementSystem.Entities.Email(dbEmail.EmailId, new UserManagementSystem.Entities.EmailType(dbEmail.EmailTypeReference.Value.EmailTypeId, dbEmail.EmailType.Description), dbEmail.Email1, dbEmail.CreateDate, dbEmail.ModifyDate, dbEmail.CreateUserId, dbEmail.ModifyUserId)).ToList<UserManagementSystem.Entities.Email>();
			account.Publications = new List<Publication>();
			foreach (UserToBook userToBook in user.UserToBooks)
			{
				Publication publication = new Publication(userToBook.Book.BookId, userToBook.Book.BookNumber, new BrandType(userToBook.Book.Brand.BrandId, userToBook.Book.Brand.Description));
				account.Publications.Add(publication);
			}
			account.FullAddresses = new List<FullAddress>();
			Address address = user.Addresses.FirstOrDefault<Address>();
			if (address != null)
			{
				UserManagementSystem.DAL.Country country = address.City.State.Country;
				UserManagementSystem.Entities.Country country1 = new UserManagementSystem.Entities.Country(country.CountryId, country.Code, country.Name);
				UserManagementSystem.DAL.State state = address.City.State;
				UserManagementSystem.Entities.State state1 = new UserManagementSystem.Entities.State(state.StateId, state.Code, state.Name, country1);
				UserManagementSystem.DAL.City city = address.City;
				UserManagementSystem.Entities.City city1 = new UserManagementSystem.Entities.City(city.CityId, city.Name, state1);
				FullAddress fullAddress = new FullAddress(address.AddressId, address.AddressLine1, address.AddressLine2, city1, state1, country1, address.PostalCode, address.CreateUserId, user.ModifyUserId, user.CreateDate, address.ModifyDate);
				account.FullAddresses.Add(fullAddress);
			}
			this.CommandResult = account;
		}
	}
}