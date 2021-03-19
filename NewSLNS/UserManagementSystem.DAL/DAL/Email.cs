using System;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="Email")]
	[Serializable]
	public class Email : EntityObject
	{
		private int _EmailId;

		private string _Email1;

		private int _EmailTypeId;

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
		public string Email1
		{
			get
			{
				return this._Email1;
			}
			set
			{
				this.ReportPropertyChanging("Email1");
				this._Email1 = StructuralObject.SetValidValue(value, false);
				this.ReportPropertyChanged("Email1");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int EmailId
		{
			get
			{
				return this._EmailId;
			}
			set
			{
				if (this._EmailId != value)
				{
					this.ReportPropertyChanging("EmailId");
					this._EmailId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("EmailId");
				}
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Email_EmailType", "EmailType")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.EmailType EmailType
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.EmailType>("UMSModel.FK_Email_EmailType", "EmailType").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.EmailType>("UMSModel.FK_Email_EmailType", "EmailType").Value = value;
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public int EmailTypeId
		{
			get
			{
				return this._EmailTypeId;
			}
			set
			{
				this.ReportPropertyChanging("EmailTypeId");
				this._EmailTypeId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("EmailTypeId");
			}
		}

		[Browsable(false)]
		[DataMember]
		public EntityReference<UserManagementSystem.DAL.EmailType> EmailTypeReference
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.EmailType>("UMSModel.FK_Email_EmailType", "EmailType");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.EmailType>("UMSModel.FK_Email_EmailType", "EmailType", value);
				}
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
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Email_User", "User")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.User User
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Email_User", "User").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Email_User", "User").Value = value;
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
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Email_User", "User");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_Email_User", "User", value);
				}
			}
		}

		public Email()
		{
		}

		public static Email CreateEmail(int emailId, string email1, int emailTypeId, Guid userId, int sequence, Guid createUserId, DateTime createDate, Guid modifyUserId, DateTime modifyDate)
		{
			Email email = new Email()
			{
				EmailId = emailId,
				Email1 = email1,
				EmailTypeId = emailTypeId,
				UserId = userId,
				Sequence = sequence,
				CreateUserId = createUserId,
				CreateDate = createDate,
				ModifyUserId = modifyUserId,
				ModifyDate = modifyDate
			};
			return email;
		}
	}
}