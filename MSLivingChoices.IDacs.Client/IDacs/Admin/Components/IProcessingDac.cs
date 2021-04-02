using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface IProcessingDac
	{
		List<Image> GetUnprocessedCommunityImages(long entityId);

		List<Image> GetUnprocessedImages(ImageOwner owner, long entityId);

		void UpdateImage(Image image);
	}
}