using MSLivingChoices.Bcs.Admin;
using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using MSLivingChoices.MarchexService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UserManagementSystem.Shared.Entities;
using UserManagementSystem.Shared.Entities.Enum;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class CallTrackingBc
	{
		private readonly ICallTrackingDac _callTrackingDac;

		private static CallTrackingBc _callTrackingBc;

		private readonly static object Locker;

		public static CallTrackingBc Instance
		{
			get
			{
				if (CallTrackingBc._callTrackingBc == null)
				{
					lock (CallTrackingBc.Locker)
					{
						if (CallTrackingBc._callTrackingBc == null)
						{
							CallTrackingBc._callTrackingBc = new CallTrackingBc();
						}
					}
				}
				return CallTrackingBc._callTrackingBc;
			}
		}

		static CallTrackingBc()
		{
			CallTrackingBc.Locker = new object();
		}

		private CallTrackingBc()
		{
			this._callTrackingDac = AdminDacFactoryClient.GetConcreteFactory().GetCallTrackingDac();
		}

		public List<CallTrackingPhone> GetAll(int? pageNumber, int? pageSize, out int totalCount)
		{
			List<Book> books = this.GetBooks(AccountBc.Instance.GetCurrentUserId());
			return this._callTrackingDac.GetAll(books, pageNumber, pageSize, out totalCount);
		}

		private List<Book> GetBooks(Guid? userId)
		{
			List<Book> books = new List<Book>();
			if (userId.HasValue)
			{
				if (!AccountBc.Instance.IsUserInRole(userId.Value, UmsRoles.Admin))
				{
					books = AccountBc.Instance.GetBooks(userId.Value).ConvertAll<Book>((Publication p) => new Book()
					{
						Id = new long?((long)p.Id)
					});
				}
				else
				{
					books.Add(new Book()
					{
						Id = new long?((long)-1)
					});
				}
			}
			return books;
		}

		public Community ProvisionPhones(Community community)
		{
			Community book = community;
			if (book.Book == null && book.Id.HasValue)
			{
				Community byId = CommunityBc.Instance.GetById(book.Id.Value);
				book.Book = byId.Book;
				if (book.Address == null || book.Address.Country == null || !book.Address.Country.Id.HasValue)
				{
					book.Address = byId.Address;
				}
			}
			List<Publication> books = AccountBc.Instance.GetBooks();
			if (books.Any<Publication>((Publication b) => {
				long id = (long)b.Id;
				long? nullable = book.Book.Id;
				return id == nullable.GetValueOrDefault() & nullable.HasValue;
			}))
			{
				book.Book.Number = books.First<Publication>((Publication b) => {
					long id = (long)b.Id;
					long? nullable = book.Book.Id;
					return id == nullable.GetValueOrDefault() & nullable.HasValue;
				}).Name;
			}
			book = MarchexBc.ProvisionPhones(book);
			return book;
		}

		public ServiceProvider ProvisionPhones(ServiceProvider serviceProvider)
		{
			ServiceProvider book = serviceProvider;
			if (book.Book == null && book.Id.HasValue)
			{
				ServiceProvider byId = ServiceProviderBc.Instance.GetById(book.Id.Value);
				book.Book = byId.Book;
				if (book.Address == null || book.Address.Country == null || !book.Address.Country.Id.HasValue)
				{
					book.Address = byId.Address;
				}
			}
			List<Publication> books = AccountBc.Instance.GetBooks();
			if (books.Any<Publication>((Publication b) => {
				long id = (long)b.Id;
				long? nullable = book.Book.Id;
				return id == nullable.GetValueOrDefault() & nullable.HasValue;
			}))
			{
				book.Book.Number = books.First<Publication>((Publication b) => {
					long id = (long)b.Id;
					long? nullable = book.Book.Id;
					return id == nullable.GetValueOrDefault() & nullable.HasValue;
				}).Name;
			}
			book = MarchexBc.ProvisionPhones(book);
			return book;
		}

		public void ProvisionPhonesAndSave(long communityId, List<CallTrackingPhone> callTrackingPhones)
		{
			Community byId = CommunityBc.Instance.GetById(communityId);
			byId.CallTrackingPhones = callTrackingPhones;
			byId = this.ProvisionPhones(byId);
			this.SaveCallTrackingPhones(communityId, byId.CallTrackingPhones);
		}

		public void SaveCallTrackingPhones(long communityId, List<CallTrackingPhone> phones)
		{
			this._callTrackingDac.SaveCallTrackingPhones(communityId, phones);
		}

		public void SaveCallTrackingPhones(Community community)
		{
			this._callTrackingDac.SaveCallTrackingPhones(community);
		}

		public void SaveCallTrackingPhones(ServiceProvider serviceProvider)
		{
			this._callTrackingDac.SaveCallTrackingPhones(serviceProvider);
		}

		public void ValidateCallTrackingPhones()
		{
			this.ValidateCallTrackingPhones(AccountBc.Instance.GetCurrentUserId().Value);
		}

		private void ValidateCallTrackingPhones(Guid userId)
		{
			List<Book> books = this.GetBooks(new Guid?(userId));
			List<CallTrackingPhone> all = this._callTrackingDac.GetAll(books);
			List<CallTrackingPhone> callTrackingPhones = new List<CallTrackingPhone>();
			List<CallTrackingPhone> callTrackingPhones1 = new List<CallTrackingPhone>();
			foreach (CallTrackingPhone callTrackingPhone in all)
			{
				if (!callTrackingPhone.IsDisconnected && !callTrackingPhone.DisconnectDate.HasValue && callTrackingPhone.EndDate.HasValue && callTrackingPhone.EndDate.Value.Date < DateTime.UtcNow.Date)
				{
					callTrackingPhones.Add(callTrackingPhone);
					Logger.InfoFormat(LogMessages.BcsAdmin.Components.PhoneDisconnected, new object[] { callTrackingPhone.Id, callTrackingPhone.CommunityId, callTrackingPhone.Phone, callTrackingPhone.ProvisionPhone });
				}
				if (!callTrackingPhone.IsDisconnected || !callTrackingPhone.DisconnectDate.HasValue || !(callTrackingPhone.DisconnectDate.Value.AddDays(180).Date < DateTime.UtcNow.Date) || !MarchexBc.DisconnectCallTracking(callTrackingPhone))
				{
					continue;
				}
				callTrackingPhones1.Add(callTrackingPhone);
				Logger.InfoFormat(LogMessages.BcsAdmin.Components.PhoneDeleted, new object[] { callTrackingPhone.Id, callTrackingPhone.CommunityId, callTrackingPhone.Phone, callTrackingPhone.ProvisionPhone });
			}
			this._callTrackingDac.DisconnectCallTrackingPhones(userId, callTrackingPhones);
			this._callTrackingDac.DeleteCallTrackingPhones(userId, callTrackingPhones1);
		}

		public void ValidateCallTrackingPhonesFromScheduler()
		{
			Guid callTrackingPhoneSchedulerUserId = ConfigurationManager.Instance.CallTrackingPhoneSchedulerUserId;
			this._callTrackingDac.ValidateCallTrackingPhones(callTrackingPhoneSchedulerUserId);
			this.ValidateCallTrackingPhones(callTrackingPhoneSchedulerUserId);
		}
	}
}