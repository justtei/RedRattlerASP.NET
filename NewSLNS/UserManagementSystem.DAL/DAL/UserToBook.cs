using System;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UserManagementSystem.DAL
{
	[DataContract(IsReference=true)]
	[EdmEntityType(NamespaceName="UMSModel", Name="UserToBook")]
	[Serializable]
	public class UserToBook : EntityObject
	{
		private Guid _UserId;

		private int _BookId;

		private int _UserToBookId;

		private int? _TempUserGroupId;

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_UserToBook_Book", "Book")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.Book Book
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.Book>("UMSModel.FK_UserToBook_Book", "Book").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.Book>("UMSModel.FK_UserToBook_Book", "Book").Value = value;
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=false)]
		public int BookId
		{
			get
			{
				return this._BookId;
			}
			set
			{
				this.ReportPropertyChanging("BookId");
				this._BookId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("BookId");
			}
		}

		[Browsable(false)]
		[DataMember]
		public EntityReference<UserManagementSystem.DAL.Book> BookReference
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.Book>("UMSModel.FK_UserToBook_Book", "Book");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.Book>("UMSModel.FK_UserToBook_Book", "Book", value);
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=false, IsNullable=true)]
		public int? TempUserGroupId
		{
			get
			{
				return this._TempUserGroupId;
			}
			set
			{
				this.ReportPropertyChanging("TempUserGroupId");
				this._TempUserGroupId = StructuralObject.SetValidValue(value);
				this.ReportPropertyChanged("TempUserGroupId");
			}
		}

		[DataMember]
		[EdmRelationshipNavigationProperty("UMSModel", "FK_UserToBook_User", "User")]
		[SoapIgnore]
		[XmlIgnore]
		public UserManagementSystem.DAL.User User
		{
			get
			{
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_UserToBook_User", "User").Value;
			}
			set
			{
				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_UserToBook_User", "User").Value = value;
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
				return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_UserToBook_User", "User");
			}
			set
			{
				if (value != null)
				{
					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<UserManagementSystem.DAL.User>("UMSModel.FK_UserToBook_User", "User", value);
				}
			}
		}

		[DataMember]
		[EdmScalarProperty(EntityKeyProperty=true, IsNullable=false)]
		public int UserToBookId
		{
			get
			{
				return this._UserToBookId;
			}
			set
			{
				if (this._UserToBookId != value)
				{
					this.ReportPropertyChanging("UserToBookId");
					this._UserToBookId = StructuralObject.SetValidValue(value);
					this.ReportPropertyChanged("UserToBookId");
				}
			}
		}

		public UserToBook()
		{
		}

		public static UserToBook CreateUserToBook(Guid userId, int bookId, int userToBookId)
		{
			UserToBook userToBook = new UserToBook()
			{
				UserId = userId,
				BookId = bookId,
				UserToBookId = userToBookId
			};
			return userToBook;
		}
	}
}