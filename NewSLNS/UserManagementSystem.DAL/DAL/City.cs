using System;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="City")]
	[Serializable]
	public class City : EntityObject
	{
		private int _CityId;

		private int _StateId;

		private string _Name;

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Address_City", "Address")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<Address> Addresses
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Address>("UMSModel.FK_Address_City", "Address");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Address>("UMSModel.FK_Address_City", "Address", value);
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int CityId
		{
			get
			{
				return this._CityId;
			}
			set
			{
				if (this._CityId != value)
				{
					this.ReportPropertyChanging("CityId");
					this._CityId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("CityId");
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
		[EdmRelationshipNavigationProperty("UMSModel", "FK_City_State", "State")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.State State
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.State>("UMSModel.FK_City_State", "State").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.State>("UMSModel.FK_City_State", "State").Value = value;
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public int StateId
		{
			get
			{
				return this._StateId;
			}
			set
			{
				this.ReportPropertyChanging("StateId");
				this._StateId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("StateId");
			}
		}

		[Browsable(false)]
		[DataMember]
		public EntityReference<UserManagementSystem.DAL.State> StateReference
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.State>("UMSModel.FK_City_State", "State");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.State>("UMSModel.FK_City_State", "State", value);
				}
			}
		}

		public City()
		{
		}

		public static City CreateCity(int cityId, int stateId, string name)
		{
			City city = new City()
			{
				CityId = cityId,
				StateId = stateId,
				Name = name
			};
			return city;
		}
	}
}