using System;
using System.Data.EntityClient;
using System.Data.Objects;

namespace UserManagementSystem.DAL
{
	public class UMSEntities : ObjectContext
	{
		private ObjectSet<Address> _Addresses;

		private ObjectSet<Book> _Books;

		private ObjectSet<Brand> _Brands;

		private ObjectSet<City> _Cities;

		private ObjectSet<Country> _Countries;

		private ObjectSet<Email> _Emails;

		private ObjectSet<EmailType> _EmailTypes;

		private ObjectSet<Phone> _Phones;

		private ObjectSet<PhoneType> _PhoneTypes;

		private ObjectSet<State> _States;

		private ObjectSet<User> _Users;

		private ObjectSet<UserToBook> _UserToBooks;

		public ObjectSet<Address> Addresses
		{
			get
			{
				if (this._Addresses == null)
				{
					this._Addresses = base.CreateObjectSet<Address>("Addresses");
				}
				return this._Addresses;
			}
		}

		public ObjectSet<Book> Books
		{
			get
			{
				if (this._Books == null)
				{
					this._Books = base.CreateObjectSet<Book>("Books");
				}
				return this._Books;
			}
		}

		public ObjectSet<Brand> Brands
		{
			get
			{
				if (this._Brands == null)
				{
					this._Brands = base.CreateObjectSet<Brand>("Brands");
				}
				return this._Brands;
			}
		}

		public ObjectSet<City> Cities
		{
			get
			{
				if (this._Cities == null)
				{
					this._Cities = base.CreateObjectSet<City>("Cities");
				}
				return this._Cities;
			}
		}

		public ObjectSet<Country> Countries
		{
			get
			{
				if (this._Countries == null)
				{
					this._Countries = base.CreateObjectSet<Country>("Countries");
				}
				return this._Countries;
			}
		}

		public ObjectSet<Email> Emails
		{
			get
			{
				if (this._Emails == null)
				{
					this._Emails = base.CreateObjectSet<Email>("Emails");
				}
				return this._Emails;
			}
		}

		public ObjectSet<EmailType> EmailTypes
		{
			get
			{
				if (this._EmailTypes == null)
				{
					this._EmailTypes = base.CreateObjectSet<EmailType>("EmailTypes");
				}
				return this._EmailTypes;
			}
		}

		public ObjectSet<Phone> Phones
		{
			get
			{
				if (this._Phones == null)
				{
					this._Phones = base.CreateObjectSet<Phone>("Phones");
				}
				return this._Phones;
			}
		}

		public ObjectSet<PhoneType> PhoneTypes
		{
			get
			{
				if (this._PhoneTypes == null)
				{
					this._PhoneTypes = base.CreateObjectSet<PhoneType>("PhoneTypes");
				}
				return this._PhoneTypes;
			}
		}

		public ObjectSet<State> States
		{
			get
			{
				if (this._States == null)
				{
					this._States = base.CreateObjectSet<State>("States");
				}
				return this._States;
			}
		}

		public ObjectSet<User> Users
		{
			get
			{
				if (this._Users == null)
				{
					this._Users = base.CreateObjectSet<User>("Users");
				}
				return this._Users;
			}
		}

		public ObjectSet<UserToBook> UserToBooks
		{
			get
			{
				if (this._UserToBooks == null)
				{
					this._UserToBooks = base.CreateObjectSet<UserToBook>("UserToBooks");
				}
				return this._UserToBooks;
			}
		}

		public UMSEntities() : base("name=UMSEntities", "UMSEntities")
		{
			base.ContextOptions.LazyLoadingEnabled = true;
		}

		public UMSEntities(string connectionString) : base(connectionString, "UMSEntities")
		{
			base.ContextOptions.LazyLoadingEnabled = true;
		}

		public UMSEntities(EntityConnection connection) : base(connection, "UMSEntities")
		{
			base.ContextOptions.LazyLoadingEnabled = true;
		}

		public void AddToAddresses(Address address)
		{
			base.AddObject("Addresses", address);
		}

		public void AddToBooks(Book book)
		{
			base.AddObject("Books", book);
		}

		public void AddToBrands(Brand brand)
		{
			base.AddObject("Brands", brand);
		}

		public void AddToCities(City city)
		{
			base.AddObject("Cities", city);
		}

		public void AddToCountries(Country country)
		{
			base.AddObject("Countries", country);
		}

		public void AddToEmails(Email email)
		{
			base.AddObject("Emails", email);
		}

		public void AddToEmailTypes(EmailType emailType)
		{
			base.AddObject("EmailTypes", emailType);
		}

		public void AddToPhones(Phone phone)
		{
			base.AddObject("Phones", phone);
		}

		public void AddToPhoneTypes(PhoneType phoneType)
		{
			base.AddObject("PhoneTypes", phoneType);
		}

		public void AddToStates(State state)
		{
			base.AddObject("States", state);
		}

		public void AddToUsers(User user)
		{
			base.AddObject("Users", user);
		}

		public void AddToUserToBooks(UserToBook userToBook)
		{
			base.AddObject("UserToBooks", userToBook);
		}

		public int ChangeUserName(string oldUserName, string newUserName)
		{
			ObjectParameter objectParameter;
			ObjectParameter objectParameter1;
			objectParameter = (oldUserName == null ? new ObjectParameter("OldUserName", typeof(string)) : new ObjectParameter("OldUserName", oldUserName));
			objectParameter1 = (newUserName == null ? new ObjectParameter("NewUserName", typeof(string)) : new ObjectParameter("NewUserName", newUserName));
			ObjectParameter[] objectParameterArray = new ObjectParameter[] { objectParameter, objectParameter1 };
			return base.ExecuteFunction("ChangeUserName", objectParameterArray);
		}
	}
}