using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlProcessingDac : IProcessingDac
	{
		public SqlProcessingDac()
		{
		}

		public List<Image> GetUnprocessedCommunityImages(long entityId)
		{
			GetUnprocessedCommunityImagesCommand getUnprocessedCommunityImagesCommand = new GetUnprocessedCommunityImagesCommand(entityId);
			getUnprocessedCommunityImagesCommand.Execute();
			return getUnprocessedCommunityImagesCommand.CommandResult;
		}

		public List<Image> GetUnprocessedImages(ImageOwner owner, long entityId)
		{
			GetUnprocessedImagesCommand getUnprocessedImagesCommand = new GetUnprocessedImagesCommand(owner, entityId);
			getUnprocessedImagesCommand.Execute();
			return getUnprocessedImagesCommand.CommandResult;
		}

		public void UpdateImage(Image image)
		{
			(new UpdateImageCommand(image)).Execute();
		}
	}
}