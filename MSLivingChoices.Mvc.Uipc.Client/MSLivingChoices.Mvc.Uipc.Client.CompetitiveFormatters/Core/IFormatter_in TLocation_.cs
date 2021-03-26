using System;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core
{
	internal interface IFormatter<in TLocation>
	{
		void Apply(object obj, TLocation location);
	}
}