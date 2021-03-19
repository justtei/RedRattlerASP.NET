using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class SaveAccountCommand : BaseCommand
	{
		private readonly Account _account;

		public SaveAccountCommand(Account account)
		{
			this._account = account;
		}

		protected override void CommandBody(UMSEntities context)
		{
			SaveAccountCommand.<>c__DisplayClass28 variable;
			User firstName = context.Users.FirstOrDefault<User>((User u) => u.UserId == this._account.Id);
			if (firstName != null)
			{
				firstName.FirstName = this._account.FirstName;
				firstName.LastName = this._account.LastName;
				firstName.HasNotifications = this._account.CommunicationSettings.HasNotifications;
				firstName.HasLeadsNotifications = this._account.CommunicationSettings.HasLeads;
				firstName.ModifyUserId = this._account.ModifyUserId;
				firstName.ModifyDate = this._account.ModifyDate;
				IEnumerable<Address> addresses = 
					from addr in context.Addresses
					where addr.UserId == firstName.UserId
					select addr;
				IEnumerable<FullAddress> fullAddresses = this._account.FullAddresses.Where<FullAddress>((FullAddress newAddr) => return addresses.Count<Address>((Address exisAddr) => exisAddr.AddressId == newAddr.Id) == 0);
				IEnumerable<Address> addresses1 = 
					from exisAddr in addresses
					where this._account.FullAddresses.Count<FullAddress>((FullAddress newAddr) => newAddr.Id == exisAddr.AddressId) == 0
					select exisAddr;
				IEnumerable<Address> addresses2 = 
					from exisAddr in addresses
					where this._account.FullAddresses.Count<FullAddress>((FullAddress newAddr) => newAddr.Id == exisAddr.AddressId) > 0
					select exisAddr;
				foreach (FullAddress fullAddress in fullAddresses)
				{
					Address address = new Address()
					{
						AddressId = fullAddress.Id,
						AddressLine1 = fullAddress.AddressLine1,
						AddressLine2 = fullAddress.AddressLine2,
						CityId = fullAddress.City.Id,
						PostalCode = fullAddress.Zip,
						Sequence = 1,
						CreateUserId = fullAddress.CreateUserId,
						ModifyUserId = fullAddress.ModifyUserId,
						CreateDate = fullAddress.CreateDate,
						ModifyDate = fullAddress.ModifyDate
					};
					context.Addresses.AddObject(address);
				}
				foreach (Address id in addresses2)
				{
					FullAddress fullAddress1 = this._account.FullAddresses.First<FullAddress>((FullAddress newAddr) => newAddr.Id == id.AddressId);
					id.AddressId = fullAddress1.Id;
					id.AddressLine1 = fullAddress1.AddressLine1;
					id.AddressLine2 = fullAddress1.AddressLine2;
					id.CityId = fullAddress1.City.Id;
					id.PostalCode = fullAddress1.Zip;
					id.Sequence = 1;
					id.ModifyUserId = fullAddress1.ModifyUserId;
					id.ModifyDate = fullAddress1.ModifyDate;
					context.Addresses.Detach(id);
					context.Addresses.Attach(id);
					context.ObjectStateManager.ChangeObjectState(id, EntityState.Modified);
				}
				addresses1.ToList<Address>().ForEach((Address addr) => context.Addresses.DeleteObject(addr));
				IEnumerable<UserManagementSystem.DAL.Phone> phones = 
					from ph in context.Phones
					where ph.UserId == firstName.UserId
					select ph;
				IEnumerable<UserManagementSystem.Entities.Phone> phones1 = this._account.Phones.Where<UserManagementSystem.Entities.Phone>((UserManagementSystem.Entities.Phone newPh) => return phones.Count<UserManagementSystem.DAL.Phone>((UserManagementSystem.DAL.Phone exisPh) => exisPh.PhoneId == newPh.Id) == 0);
				IEnumerable<UserManagementSystem.DAL.Phone> phones2 = 
					from exisPh in phones
					where this._account.Phones.Count<UserManagementSystem.Entities.Phone>((UserManagementSystem.Entities.Phone newPh) => newPh.Id == exisPh.PhoneId) == 0
					select exisPh;
				IEnumerable<UserManagementSystem.DAL.Phone> phones3 = 
					from exisPh in phones
					where this._account.Phones.Count<UserManagementSystem.Entities.Phone>((UserManagementSystem.Entities.Phone newPh) => newPh.Id == exisPh.PhoneId) > 0
					select exisPh;
				foreach (UserManagementSystem.Entities.Phone phone in phones1)
				{
					UserManagementSystem.DAL.Phone phone1 = new UserManagementSystem.DAL.Phone()
					{
						PhoneId = phone.Id,
						Phone1 = phone.Number,
						PhoneTypeId = phone.Type.Id,
						UserId = this._account.Id,
						Sequence = 1,
						CreateUserId = phone.CreateUserId,
						ModifyUserId = phone.ModifyUserId,
						CreateDate = phone.CreateDate,
						ModifyDate = phone.ModifyDate
					};
					context.Phones.AddObject(phone1);
				}
				foreach (UserManagementSystem.DAL.Phone number in phones3)
				{
					UserManagementSystem.Entities.Phone phone2 = this._account.Phones.First<UserManagementSystem.Entities.Phone>((UserManagementSystem.Entities.Phone newPh) => newPh.Id == number.PhoneId);
					number.PhoneId = phone2.Id;
					number.Phone1 = phone2.Number;
					number.PhoneTypeId = phone2.Type.Id;
					number.UserId = this._account.Id;
					number.Sequence = 1;
					number.ModifyUserId = phone2.ModifyUserId;
					number.ModifyDate = phone2.ModifyDate;
					context.Phones.Detach(number);
					context.Phones.Attach(number);
					context.ObjectStateManager.ChangeObjectState(number, EntityState.Modified);
				}
				phones2.ToList<UserManagementSystem.DAL.Phone>().ForEach((UserManagementSystem.DAL.Phone ph) => context.Phones.DeleteObject(ph));
				IEnumerable<UserManagementSystem.DAL.Email> emails = 
					from em in context.Emails
					where em.UserId == firstName.UserId
					select em;
				IEnumerable<UserManagementSystem.Entities.Email> emails1 = this._account.Emails.Where<UserManagementSystem.Entities.Email>((UserManagementSystem.Entities.Email newEm) => return emails.Count<UserManagementSystem.DAL.Email>((UserManagementSystem.DAL.Email exisEm) => exisEm.EmailId == newEm.Id) == 0);
				IEnumerable<UserManagementSystem.DAL.Email> emails2 = 
					from exisEm in emails
					where this._account.Emails.Count<UserManagementSystem.Entities.Email>((UserManagementSystem.Entities.Email newEm) => newEm.Id == exisEm.EmailId) == 0
					select exisEm;
				IEnumerable<UserManagementSystem.DAL.Email> emails3 = 
					from exisEm in emails
					where this._account.Emails.Count<UserManagementSystem.Entities.Email>((UserManagementSystem.Entities.Email newEm) => newEm.Id == exisEm.EmailId) > 0
					select exisEm;
				foreach (UserManagementSystem.Entities.Email email in emails1)
				{
					UserManagementSystem.DAL.Email email1 = new UserManagementSystem.DAL.Email()
					{
						EmailId = email.Id,
						Email1 = email.Value,
						EmailTypeId = email.Type.Id,
						UserId = this._account.Id,
						Sequence = 1,
						CreateUserId = email.CreateUserId,
						ModifyUserId = email.ModifyUserId,
						CreateDate = email.CreateDate,
						ModifyDate = email.ModifyDate
					};
					context.Emails.AddObject(email1);
				}
				foreach (UserManagementSystem.DAL.Email value in emails3)
				{
					UserManagementSystem.Entities.Email email2 = this._account.Emails.First<UserManagementSystem.Entities.Email>((UserManagementSystem.Entities.Email newEm) => newEm.Id == value.EmailId);
					value.EmailId = email2.Id;
					value.Email1 = email2.Value;
					value.EmailTypeId = email2.Type.Id;
					value.UserId = this._account.Id;
					value.Sequence = 1;
					value.ModifyUserId = email2.ModifyUserId;
					value.ModifyDate = email2.ModifyDate;
					context.Emails.Detach(value);
					context.Emails.Attach(value);
					context.ObjectStateManager.ChangeObjectState(value, EntityState.Modified);
				}
				emails2.ToList<UserManagementSystem.DAL.Email>().ForEach((UserManagementSystem.DAL.Email em) => context.Emails.DeleteObject(em));
				IEnumerable<UserToBook> userToBooks = 
					from utb in context.UserToBooks
					where utb.UserId == this._account.Id
					select utb;
				IEnumerable<Publication> publications = this._account.Publications.Where<Publication>((Publication newPublc) => return userToBooks.Count<UserToBook>((UserToBook exisUtb) => exisUtb.BookId == newPublc.Id) == 0);
				IEnumerable<UserToBook> userToBooks1 = 
					from exisUtb in userToBooks
					where this._account.Publications.Count<Publication>((Publication publ) => publ.Id == exisUtb.BookId) == 0
					select exisUtb;
				foreach (Publication publication in publications)
				{
					UserToBook userToBook = new UserToBook()
					{
						BookId = publication.Id,
						UserId = this._account.Id
					};
					context.UserToBooks.AddObject(userToBook);
				}
				userToBooks1.ToList<UserToBook>().ForEach((UserToBook utb) => context.UserToBooks.DeleteObject(utb));
			}
			else
			{
				firstName = new User()
				{
					UserId = this._account.Id,
					FirstName = this._account.FirstName,
					LastName = this._account.LastName,
					PrimaryEmail = this._account.PrimaryEmail,
					HasNotifications = this._account.CommunicationSettings.HasNotifications,
					HasLeadsNotifications = this._account.CommunicationSettings.HasLeads,
					CreateUserId = this._account.CreateUserId,
					CreateDate = this._account.CreateDate,
					ModifyUserId = this._account.ModifyUserId,
					ModifyDate = this._account.ModifyDate
				};
				foreach (FullAddress fullAddress2 in this._account.FullAddresses)
				{
					Address address1 = new Address()
					{
						AddressLine1 = fullAddress2.AddressLine1,
						CityId = fullAddress2.City.Id,
						UserId = this._account.Id,
						PostalCode = fullAddress2.Zip,
						Sequence = 1,
						CreateUserId = fullAddress2.CreateUserId,
						CreateDate = fullAddress2.CreateDate,
						ModifyUserId = fullAddress2.ModifyUserId,
						ModifyDate = fullAddress2.ModifyDate
					};
					firstName.Addresses.Add(address1);
				}
				foreach (Publication publication1 in this._account.Publications)
				{
					Book book = context.Books.FirstOrDefault<Book>((Book b) => b.BookId == publication1.Id);
					if (book != null)
					{
						UserToBook userToBook1 = new UserToBook()
						{
							BookId = book.BookId,
							UserId = this._account.Id
						};
						firstName.UserToBooks.Add(userToBook1);
					}
				}
				foreach (UserManagementSystem.Entities.Email email3 in this._account.Emails)
				{
					UserManagementSystem.DAL.Email email4 = new UserManagementSystem.DAL.Email()
					{
						Email1 = email3.Value,
						EmailTypeId = email3.Type.Id,
						UserId = this._account.Id,
						Sequence = 1,
						CreateUserId = email3.CreateUserId,
						CreateDate = email3.CreateDate,
						ModifyUserId = email3.ModifyUserId,
						ModifyDate = email3.ModifyDate
					};
					firstName.Emails.Add(email4);
				}
				foreach (UserManagementSystem.Entities.Phone phone3 in this._account.Phones)
				{
					UserManagementSystem.DAL.Phone phone4 = new UserManagementSystem.DAL.Phone()
					{
						Phone1 = phone3.Number,
						PhoneTypeId = phone3.Type.Id,
						UserId = this._account.Id,
						Sequence = 1,
						CreateUserId = phone3.CreateUserId,
						CreateDate = phone3.CreateDate,
						ModifyUserId = phone3.ModifyUserId,
						ModifyDate = phone3.ModifyDate
					};
					firstName.Phones.Add(phone4);
				}
				context.Users.AddObject(firstName);
			}
		}
	}
}