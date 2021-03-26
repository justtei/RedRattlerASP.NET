using MSLivingChoices.Entities.Client.DisplayOptions;
using System;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver
{
	public class OwnerDisplayProperties
	{
		private OwnerDisplayOptions _displayOptions;

		private bool _name;

		private bool _phone;

		private bool _websiteUrl;

		private bool _logo;

		private bool _address;

		public bool Address
		{
			get
			{
				if (!this._displayOptions.Address)
				{
					return false;
				}
				return this._address;
			}
			set
			{
				this._address = value;
			}
		}

		public bool Logo
		{
			get
			{
				if (!this._displayOptions.Logo)
				{
					return false;
				}
				return this._logo;
			}
			set
			{
				this._logo = value;
			}
		}

		public bool Name
		{
			get
			{
				if (!this._displayOptions.Name)
				{
					return false;
				}
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		public bool Phone
		{
			get
			{
				if (!this._displayOptions.Phone)
				{
					return false;
				}
				return this._phone;
			}
			set
			{
				this._phone = value;
			}
		}

		public bool WebsiteUrl
		{
			get
			{
				if (!this._displayOptions.Website)
				{
					return false;
				}
				return this._websiteUrl;
			}
			set
			{
				this._websiteUrl = value;
			}
		}

		public OwnerDisplayProperties(OwnerDisplayOptions displayOptions)
		{
			this._displayOptions = displayOptions;
		}

		public OwnerDisplayProperties()
		{
			this._displayOptions = new OwnerDisplayOptions()
			{
				Name = true,
				Phone = true,
				Website = true,
				Logo = true,
				Address = true
			};
		}
	}
}