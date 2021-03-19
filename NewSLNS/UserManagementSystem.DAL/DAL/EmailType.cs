using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="EmailType")]
	[Serializable]
	public class EmailType : EntityObject
	{
		private int _EmailTypeId;

		private string _Description;

		private int _Sequence;

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				this.ReportPropertyChanging("Description");
				this._Description = StructuralObject.SetValidValue(value, false);
				this.ReportPropertyChanged("Description");
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Email_EmailType", "Email")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<Email> Emails
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Email>("UMSModel.FK_Email_EmailType", "Email");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Email>("UMSModel.FK_Email_EmailType", "Email", value);
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int EmailTypeId
		{
			get
			{
				return this._EmailTypeId;
			}
			set
			{
				if (this._EmailTypeId != value)
				{
					this.ReportPropertyChanging("EmailTypeId");
					this._EmailTypeId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("EmailTypeId");
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

		public EmailType()
		{
		}

		public static EmailType CreateEmailType(int emailTypeId, string description, int sequence)
		{
			EmailType emailType = new EmailType()
			{
				EmailTypeId = emailTypeId,
				Description = description,
				Sequence = sequence
			};
			return emailType;
		}
	}
}