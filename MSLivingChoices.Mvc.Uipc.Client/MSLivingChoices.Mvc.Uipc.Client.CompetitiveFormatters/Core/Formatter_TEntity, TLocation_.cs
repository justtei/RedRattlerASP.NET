using System;

namespace MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.Core
{
	internal abstract class Formatter<TEntity, TLocation> : IFormatter<TLocation>
	where TEntity : class
	{
		protected Formatter()
		{
		}

		public virtual void Apply(object obj, TLocation location)
		{
			TEntity tEntity = (TEntity)(obj as TEntity);
			if (tEntity != null)
			{
				this.Apply(tEntity, location);
			}
		}

		protected abstract void Apply(TEntity entity, TLocation location);
	}
}