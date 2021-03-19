using System;
using System.Data.Objects;
using UserManagementSystem.Configuration;
using UserManagementSystem.DAL;
using UserManagementSystem.Logging;

namespace UserManagementSystem.DAL.Commands
{
	internal class BaseCommand
	{
		protected Guid? LoggedInUser;

		public BaseCommand()
		{
			this.LoggedInUser = ConfigurationManager.LoggedInUserId;
		}

		protected virtual void CommandBody(UMSEntities context)
		{
		}

		public virtual void Execute()
		{
			try
			{
				UMSEntities uMSEntity = new UMSEntities();
				try
				{
					this.CommandBody(uMSEntity);
					uMSEntity.SaveChanges();
				}
				finally
				{
					if (uMSEntity != null)
					{
						((IDisposable)uMSEntity).Dispose();
					}
				}
			}
			catch (Exception exception)
			{
				Logger.Error("Error during sql command execution.", exception);
				throw;
			}
		}
	}
}