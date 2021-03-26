using System;

namespace MSLivingChoices.Mvc.Uipc.Client.HttpModules
{
	internal enum UrlProcessingResult
	{
		Stop,
		Continue,
		Redirect,
		RedirectPermanent,
		RedirectPermanentIfExist,
		NotFound
	}
}