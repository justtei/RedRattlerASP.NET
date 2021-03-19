using System;

namespace UserManagementSystem.DAL.Commands
{
	internal class BaseCommand<T> : BaseCommand
	{
		public T CommandResult;

		public BaseCommand()
		{
		}
	}
}