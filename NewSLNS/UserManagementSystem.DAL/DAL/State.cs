using System;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="State")]
	[Serializable]
	public class State : EntityObject
	{
		private string _Name;

		private int _StateId;

		private int _CountryId;

		private string _Code;

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_City_State", "City")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<City> Cities
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<City>("UMSModel.FK_City_State", "City");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<City>("UMSModel.FK_City_State", "City", value);
				}
			}
		}

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
		[EdmRelationshipNavigationProperty("UMSModel", "FK_State_Country", "Country")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.Country Country
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.Country>("UMSModel.FK_State_Country", "Country").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.Country>("UMSModel.FK_State_Country", "Country").Value = value;
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public int CountryId
		{
			get
			{
				return this._CountryId;
			}
			set
			{
				this.ReportPropertyChanging("CountryId");
				this._CountryId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("CountryId");
			}
		}

		[Browsable(false)]
		[DataMember]
		public EntityReference<UserManagementSystem.DAL.Country> CountryReference
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.Country>("UMSModel.FK_State_Country", "Country");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.Country>("UMSModel.FK_State_Country", "Country", value);
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
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int StateId
		{
			get
			{
				return this._StateId;
			}
			set
			{
				if (this._StateId != value)
				{
					this.ReportPropertyChanging("StateId");
					this._StateId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("StateId");
				}
			}
		}

		public State()
		{
		}

		public static State CreateState(string name, int stateId, int countryId, string code)
		{
			State state = new State()
			{
				Name = name,
				StateId = stateId,
				CountryId = countryId,
				Code = code
			};
			return state;
		}
	}
}