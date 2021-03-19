using System;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="Address")]
	[Serializable]
	public class Address : EntityObject
	{
		private int _AddressId;

		private string _AddressLine1;

		private string _AddressLine2;

		private int _CityId;

		private string _PostalCode;

		private Guid _UserId;

		private int _Sequence;

		private Guid _CreateUserId;

		private DateTime _CreateDate;

		private Guid _ModifyUserId;

		private DateTime _ModifyDate;

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int AddressId
		{
			get
			{
				return this._AddressId;
			}
			set
			{
				if (this._AddressId != value)
				{
					this.ReportPropertyChanging("AddressId");
					this._AddressId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("AddressId");
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=true)]
		public string AddressLine1
		{
			get
			{
				return this._AddressLine1;
			}
			set
			{
				this.ReportPropertyChanging("AddressLine1");
				this._AddressLine1 = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("AddressLine1");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=true)]
		public string AddressLine2
		{
			get
			{
				return this._AddressLine2;
			}
			set
			{
				this.ReportPropertyChanging("AddressLine2");
				this._AddressLine2 = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("AddressLine2");
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Address_City", "City")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.City City
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.City>("UMSModel.FK_Address_City", "City").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.City>("UMSModel.FK_Address_City", "City").Value = value;
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public int CityId
		{
			get
			{
				return this._CityId;
			}
			set
			{
				this.ReportPropertyChanging("CityId");
				this._CityId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("CityId");
			}
		}

		[Browsable(false)]
		[DataMember]
		public EntityReference<UserManagementSystem.DAL.City> CityReference
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.City>("UMSModel.FK_Address_City", "City");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.City>("UMSModel.FK_Address_City", "City", value);
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
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public string PostalCode
		{
			get
			{
				return this._PostalCode;
			}
			set
			{
				this.ReportPropertyChanging("PostalCode");
				this._PostalCode = StructuralObject.SetValidValue(value, false);
				this.ReportPropertyChanged("PostalCode");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public int Sequence
		{
			get
			{
				return this._Sequence;
			}
			set
			{
				this.ReportPropertyChanging("Sequence");
				this._Sequence = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("Sequence");
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Address_User", "User")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.User User
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Address_User", "User").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Address_User", "User").Value = value;
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				this.ReportPropertyChanging("UserId");
				this._UserId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("UserId");
			}
		}

		[Browsable(false)]
		[DataMember]
		public EntityReference<UserManagementSystem.DAL.User> UserReference
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Address_User", "User");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Address_User", "User", value);
				}
			}
		}

		public Address()
		{
		}

		public static Address CreateAddress(int addressId, int cityId, string postalCode, Guid userId, int sequence, Guid createUserId, DateTime createDate, Guid modifyUserId, DateTime modifyDate)
		{
			Address address = new Address()
			{
				AddressId = addressId,
				CityId = cityId,
				PostalCode = postalCode,
				UserId = userId,
				Sequence = sequence,
				CreateUserId = createUserId,
				CreateDate = createDate,
				ModifyUserId = modifyUserId,
				ModifyDate = modifyDate
			};
			return address;
		}
	}
}