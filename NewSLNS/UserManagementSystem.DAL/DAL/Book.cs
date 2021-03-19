using System;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="Book")]
	[Serializable]
	public class Book : EntityObject
	{
		private int _BookId;

		private string _BookNumber;

		private int _BrandId;

		private string _BookName;

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int BookId
		{
			get
			{
				return this._BookId;
			}
			set
			{
				if (this._BookId != value)
				{
					this.ReportPropertyChanging("BookId");
					this._BookId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("BookId");
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=true)]
		public string BookName
		{
			get
			{
				return this._BookName;
			}
			set
			{
				this.ReportPropertyChanging("BookName");
				this._BookName = StructuralObject.SetValidValue(value, true);
				this.ReportPropertyChanged("BookName");
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public string BookNumber
		{
			get
			{
				return this._BookNumber;
			}
			set
			{
				this.ReportPropertyChanging("BookNumber");
				this._BookNumber = StructuralObject.SetValidValue(value, false);
				this.ReportPropertyChanged("BookNumber");
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_Book_Brand", "Brand")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.Brand Brand
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.Brand>("UMSModel.FK_Book_Brand", "Brand").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.Brand>("UMSModel.FK_Book_Brand", "Brand").Value = value;
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public int BrandId
		{
			get
			{
				return this._BrandId;
			}
			set
			{
				this.ReportPropertyChanging("BrandId");
				this._BrandId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("BrandId");
			}
		}

		[Browsable(false)]
		[DataMember]
		public EntityReference<UserManagementSystem.DAL.Brand> BrandReference
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.Brand>("UMSModel.FK_Book_Brand", "Brand");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.Brand>("UMSModel.FK_Book_Brand", "Brand", value);
				}
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_UserToBook_Book", "UserToBook")]
		[SoapIgnore]
		[XmlIgnore]
		public EntityCollection<UserToBook> UserToBooks
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<UserToBook>("UMSModel.FK_UserToBook_Book", "UserToBook");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<UserToBook>("UMSModel.FK_UserToBook_Book", "UserToBook", value);
				}
			}
		}

		public Book()
		{
		}

		public static Book CreateBook(int bookId, string bookNumber, int brandId)
		{
			Book book = new Book()
			{
				BookId = bookId,
				BookNumber = bookNumber,
				BrandId = brandId
			};
			return book;
		}
	}
}