using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="PhoneType")]
	[Serializable]
	public class PhoneType : EntityObject
	{
		private int _PhoneTypeId;

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
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Phone_PhoneType", "Phone")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<Phone> Phones
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Phone>("UMSModel.FK_Phone_PhoneType", "Phone");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Phone>("UMSModel.FK_Phone_PhoneType", "Phone", value);
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int PhoneTypeId
		{
			get
			{
				return this._PhoneTypeId;
			}
			set
			{
				if (this._PhoneTypeId != value)
				{
					this.ReportPropertyChanging("PhoneTypeId");
					this._PhoneTypeId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("PhoneTypeId");
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

		public PhoneType()
		{
		}

		public static PhoneType CreatePhoneType(int phoneTypeId, string description, int sequence)
		{
			PhoneType phoneType = new PhoneType()
			{
				PhoneTypeId = phoneTypeId,
				Description = description,
				Sequence = sequence
			};
			return phoneType;
		}
	}
}