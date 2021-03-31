using MSLivingChoices.Entities.Client;
using MSLivingChoices.SqlDacs.Client.Helpers;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MSLivingChoices.SqlDacs.Client.SqlCommands
{
	internal class GetServiceByIdCommand : CachedBaseCommand<ServiceProvider>
	{
		private readonly long _id;

		private ServiceProvider _service;

		public GetServiceByIdCommand(long id)
		{
			base.StoredProcedureName = ClientStoredProcedures.SpGetServiceClientDetail;
			this._id = id;
			base.CacheKey = CachedBaseCommand<ServiceProvider>.GetCacheKey(new string[] { base.StoredProcedureName, this._id.ToString() });
		}

		protected override void CommandBody(SqlCommand command)
		{
			command.CommandText = base.StoredProcedureName;
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@ServiceId", SqlDbType.BigInt).Value = this._id;
			SqlDataReader sqlDataReader = command.ExecuteReader();
			if (sqlDataReader.Read())
			{
				this._service = sqlDataReader.GetServiceDetail();
			}
			if (this._service == null)
			{
				return;
			}
			if (sqlDataReader.NextResult())
			{
				while (sqlDataReader.Read())
				{
					Image image = sqlDataReader.GetImage();
					this._service.Images.Add(image);
				}
			}
			if (sqlDataReader.NextResult())
			{
				this._service.OfficeHours = sqlDataReader.GetOfficeHours();
			}
			if (sqlDataReader.NextResult())
			{
				this._service.ServiceCategories = new List<string>();
				while (sqlDataReader.Read())
				{
					this._service.ServiceCategories.Add(sqlDataReader.GetShortAdditionalInfo());
				}
			}
			if (sqlDataReader.NextResult())
			{
				this._service.AcceptedPayments = new List<string>();
				while (sqlDataReader.Read())
				{
					this._service.AcceptedPayments.Add(sqlDataReader.GetShortAdditionalInfo());
				}
			}
			if (sqlDataReader.NextResult() && sqlDataReader.Read())
			{
				this._service.Coupon = sqlDataReader.GetCoupon();
			}
			if (sqlDataReader.NextResult())
			{
				this._service.CountiesServed = sqlDataReader.GetCounties();
			}
		}

		protected override ServiceProvider GetCommandResult(SqlCommand command)
		{
			return this._service;
		}
	}
}