using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="Country")]
	[Serializable]
	public class Country : EntityObject
	{
		private int _CountryId;

		private string _Code;

		private string _Name;

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				this.ReportPropertyChanging("Code");
				this._Code = StructuralObject.SetValidValue(value, false);
				this.ReportPropertyChanged("Code");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int CountryId
		{
			get
			{
				return this._CountryId;
			}
			set
			{
				if (this._CountryId != value)
				{
					this.ReportPropertyChanging("CountryId");
					this._CountryId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("CountryId");
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this.ReportPropertyChanging("Name");
				this._Name = StructuralObject.SetValidValue(value, false);
				this.ReportPropertyChanged("Name");
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_State_Country", "State")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<State> States
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<State>("UMSModel.FK_State_Country", "State");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<State>("UMSModel.FK_State_Country", "State", value);
				}
			}
		}

		public Country()
		{
		}

		public static Country CreateCountry(int countryId, string code, string name)
		{
			Country country = new Country()
			{
				CountryId = countryId,
				Code = code,
				Name = name
			};
			return country;
		}
	}
}