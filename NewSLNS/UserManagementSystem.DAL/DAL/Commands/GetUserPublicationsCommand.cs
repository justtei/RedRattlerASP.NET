using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetUserPublicationsCommand : BaseCommand<List<Publication>>
	{
		private readonly Guid? _userId;

		public GetUserPublicationsCommand()
		{
			this._userId = null;
		}

		public GetUserPublicationsCommand(Guid userId)
		{
			this._userId = new Guid?(userId);
		}

		protected override void CommandBody(UMSEntities context)
		{
			IQueryable<Book> books;
			List<Publication> publications = new List<Publication>();
			if (!this._userId.HasValue)
			{
				books = context.Books;
			}
			else
			{
				books = 
					from u in context.UserToBooks.Include("UserToBooks.Books").Include("UserToBooks.Book.Brand")
					where (Guid?)u.UserId == this._userId
					select u into b
					select b.Book;
			}
			foreach (Book book in books)
			{
				Publication publication = new Publication(book.BookId, book.BookNumber, new BrandType(book.Brand.BrandId, book.Brand.Description));
				publications.Add(publication);
			}
			this.CommandResult = publications;
		}
	}
}