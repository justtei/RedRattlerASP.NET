using MSLivingChoices.Entities.Admin;
using MSLivingChoices.SqlDacs.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Admin.SqlCommands
{
	internal class UpdateImageCommand : BaseCommand
	{
		private readonly Image _image;

		public UpdateImageCommand(Image image)
		{
			this._image = image;
			base.StoredProcedureName = AdminStoredProcedures.SpUpdateImage;
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@ImageId", SqlDbType.BigInt).Value = (this._image.Id.HasValue ? this._image.Id : new long?((long)-1));
			command.Parameters.Add("@OriginalPath", SqlDbType.VarChar, 255).Value = this._image.Url.ValueOrDBNull<string>();
			command.Parameters.Add("@ThumbnailPath", SqlDbType.VarChar, 255).Value = this._image.ThumbnailUrl.ValueOrDBNull<string>();
			command.Parameters.Add("@StatusId", SqlDbType.Int).Value = (int)this._image.Status;
			command.ExecuteNonQuery();
		}
	}
}