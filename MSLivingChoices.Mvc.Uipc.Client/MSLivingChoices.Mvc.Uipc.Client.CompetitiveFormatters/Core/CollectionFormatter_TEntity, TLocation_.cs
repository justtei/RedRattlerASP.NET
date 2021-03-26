using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core
{
	internal class CollectionFormatter<TEntity, TLocation> : Formatter<IEnumerable<TEntity>, TLocation>
	{
		public CollectionFormatter()
		{
		}

		protected override void Apply(IEnumerable<TEntity> entities, TLocation location)
		{
			if (entities != null)
			{
				foreach (TEntity entity in entities)
				{
					FormatterResolver.ApplyFormatting<TLocation>(entity, location);
				}
			}
		}
	}
}