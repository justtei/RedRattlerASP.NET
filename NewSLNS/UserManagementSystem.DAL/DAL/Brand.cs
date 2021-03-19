using System;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="Brand")]
	[Serializable]
	public class Brand : EntityObject
	{
		private int _BrandId;

		private string _Description;

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Book_Brand", "Book")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<Book> Books
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Book>("UMSModel.FK_Book_Brand", "Book");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Book>("UMSModel.FK_Book_Brand", "Book", value);
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int BrandId
		{
			get
			{
				return this._BrandId;
			}
			set
			{
				if (this._BrandId != value)
				{
					this.ReportPropertyChanging("BrandId");
					this._BrandId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("BrandId");
				}
			}
		}

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

		public Brand()
		{
		}

		public static Brand CreateBrand(int brandId, string description)
		{
			return new Brand()
			{
				BrandId = brandId,
				Description = description
			};
		}
	}
}