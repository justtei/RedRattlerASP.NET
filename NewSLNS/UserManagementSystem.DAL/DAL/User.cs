using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="User")]
	[Serializable]
	public class User : EntityObject
	{
		private Guid _UserId;

		private string _FirstName;

		private string _LastName;

		private bool _HasLeadsNotifications;

		private bool _HasNotifications;

		private Guid _CreateUserId;

		private DateTime _CreateDate;

		private Guid _ModifyUserId;

		private DateTime _ModifyDate;

		private string _PrimaryEmail;

		private Guid? _TempContactId;

		private Guid? _TempAddressId;

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Address_User", "Address")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<Address> Addresses
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Address>("UMSModel.FK_Address_User", "Address");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Address>("UMSModel.FK_Address_User", "Address", value);
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				this.ReportPropertyChanging("CreateDate");
				this._CreateDate = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("CreateDate");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public Guid CreateUserId
		{
			get
			{
				return this._CreateUserId;
			}
			set
			{
				this.ReportPropertyChanging("CreateUserId");
				this._CreateUserId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("CreateUserId");
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Email_User", "Email")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<Email> Emails
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Email>("UMSModel.FK_Email_User", "Email");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Email>("UMSModel.FK_Email_User", "Email", value);
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=true)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				this.ReportPropertyChanging("FirstName");
				this._FirstName = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("FirstName");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public bool HasLeadsNotifications
		{
			get
			{
				return this._HasLeadsNotifications;
			}
			set
			{
				this.ReportPropertyChanging("HasLeadsNotifications");
				this._HasLeadsNotifications = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("HasLeadsNotifications");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public bool HasNotifications
		{
			get
			{
				return this._HasNotifications;
			}
			set
			{
				this.ReportPropertyChanging("HasNotifications");
				this._HasNotifications = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("HasNotifications");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=true)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				this.ReportPropertyChanging("LastName");
				this._LastName = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("LastName");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public DateTime ModifyDate
		{
			get
			{
				return this._ModifyDate;
			}
			set
			{
				this.ReportPropertyChanging("ModifyDate");
				this._ModifyDate = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("ModifyDate");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public Guid ModifyUserId
		{
			get
			{
				return this._ModifyUserId;
			}
			set
			{
				this.ReportPropertyChanging("ModifyUserId");
				this._ModifyUserId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("ModifyUserId");
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Phone_User", "Phone")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<Phone> Phones
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Phone>("UMSModel.FK_Phone_User", "Phone");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Phone>("UMSModel.FK_Phone_User", "Phone", value);
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=true)]
		public string PrimaryEmail
		{
			get
			{
				return this._PrimaryEmail;
			}
			set
			{
				this.ReportPropertyChanging("PrimaryEmail");
				this._PrimaryEmail = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("PrimaryEmail");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=true)]
		public Guid? TempAddressId
		{
			get
			{
				return this._TempAddressId;
			}
			set
			{
				this.ReportPropertyChanging("TempAddressId");
				this._TempAddressId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("TempAddressId");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=true)]
		public Guid? TempContactId
		{
			get
			{
				return this._TempContactId;
			}
			set
			{
				this.ReportPropertyChanging("TempContactId");
				this._TempContactId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("TempContactId");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if (this._UserId != value)
				{
					this.ReportPropertyChanging("UserId");
					this._UserId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("UserId");
				}
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_UserToBook_User", "UserToBook")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<UserToBook> UserToBooks
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<UserToBook>("UMSModel.FK_UserToBook_User", "UserToBook");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<UserToBook>("UMSModel.FK_UserToBook_User", "UserToBook", value);
				}
			}
		}

		public User()
		{
		}

		public static User CreateUser(Guid userId, bool hasLeadsNotifications, bool hasNotifications, Guid createUserId, DateTime createDate, Guid modifyUserId, DateTime modifyDate)
		{
			User user = new User()
			{
				UserId = userId,
				HasLeadsNotifications = hasLeadsNotifications,
				HasNotifications = hasNotifications,
				CreateUserId = createUserId,
				CreateDate = createDate,
				ModifyUserId = modifyUserId,
				ModifyDate = modifyDate
			};
			return user;
		}
	}
}