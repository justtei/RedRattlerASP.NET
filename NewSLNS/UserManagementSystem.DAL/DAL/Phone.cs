using System;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="Phone")]
	[Serializable]
	public class Phone : EntityObject
	{
		private int _PhoneId;

		private string _Phone1;

		private int _PhoneTypeId;

		private Guid _UserId;

		private int _Sequence;

		private Guid _CreateUserId;

		private DateTime _CreateDate;

		private Guid _ModifyUserId;

		private DateTime _ModifyDate;

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
		public string Phone1
		{
			get
			{
				return this._Phone1;
			}
			set
			{
				this.ReportPropertyChanging("Phone1");
				this._Phone1 = StructuralObject.SetValidValue(value, false);
				this.ReportPropertyChanged("Phone1");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int PhoneId
		{
			get
			{
				return this._PhoneId;
			}
			set
			{
				if (this._PhoneId != value)
				{
					this.ReportPropertyChanging("PhoneId");
					this._PhoneId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("PhoneId");
				}
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Phone_PhoneType", "PhoneType")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.PhoneType PhoneType
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.PhoneType>("UMSModel.FK_Phone_PhoneType", "PhoneType").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.PhoneType>("UMSModel.FK_Phone_PhoneType", "PhoneType").Value = value;
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public int PhoneTypeId
		{
			get
			{
				return this._PhoneTypeId;
			}
			set
			{
				this.ReportPropertyChanging("PhoneTypeId");
				this._PhoneTypeId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("PhoneTypeId");
			}
		}

		[Browsable(false)]
		[DataMember]
		public EntityReference<UserManagementSystem.DAL.PhoneType> PhoneTypeReference
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.PhoneType>("UMSModel.FK_Phone_PhoneType", "PhoneType");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.PhoneType>("UMSModel.FK_Phone_PhoneType", "PhoneType", value);
				}
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
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Phone_User", "User")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.User User
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Phone_User", "User").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Phone_User", "User").Value = value;
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
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Phone_User", "User");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Phone_User", "User", value);
				}
			}
		}

		public Phone()
		{
		}

		public static Phone CreatePhone(int phoneId, string phone1, int phoneTypeId, Guid userId, int sequence, Guid createUserId, DateTime createDate, Guid modifyUserId, DateTime modifyDate)
		{
			Phone phone = new Phone()
			{
				PhoneId = phoneId,
				Phone1 = phone1,
				PhoneTypeId = phoneTypeId,
				UserId = userId,
				Sequence = sequence,
				CreateUserId = createUserId,
				CreateDate = createDate,
				ModifyUserId = modifyUserId,
				ModifyDate = modifyDate
			};
			return phone;
		}
	}
}