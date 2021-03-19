using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class Owner
	{
		public MSLivingChoices.Entities.Admin.Address Address
		{
			get;
			set;
		}

		public List<Contact> Contacts
		{
			get;
			set;
		}

		public bool DisplayAddress
		{
			get;
			set;
		}

		public bool DisplayLogo
		{
			get;
			set;
		}

		public bool DisplayName
		{
			get;
			set;
		}

		public bool DisplayPhone
		{
			get;
			set;
		}

		public bool DisplayWebsiteUrl
		{
			get;
			set;
		}

		public List<Email> Emails
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public List<Image> LogoImages
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Enums.OwnerType OwnerType
		{
			get;
			set;
		}

		public List<Phone> Phones
		{
			get;
			set;
		}

		public Guid UserId
		{
			get;
			set;
		}

		public string WebsiteUrl
		{
			get;
			set;
		}

		public Owner()
		{
			this.LogoImages = new List<Image>();
		}
	}
}