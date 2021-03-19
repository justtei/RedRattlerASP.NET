using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using UserManagementSystem.DAL;
using UserManagementSystem.Entities;

namespace UserManagementSystem.DAL.Commands
{
	internal class GetPublicationsCommand : BaseCommand<List<Publication>>
	{
		private readonly int _brandTypeId;

		public GetPublicationsCommand(int brandTypeId)
		{
			this._brandTypeId = brandTypeId;
		}

		protected override void CommandBody(UMSEntities context)
		{
			List<Publication> publications = new List<Publication>();
			List<Book> list = (
				from b in context.Books.Include("Brand")
				where b.BrandId == this._brandTypeId
				select b).ToList<Book>();
			foreach (Book book in list)
			{
				Publication publication = new Publication(book.BookId, book.BookNumber, new BrandType(book.Brand.BrandId, book.Brand.Description));
				publications.Add(publication);
			}
			this.CommandResult = publications;
		}
	}
}