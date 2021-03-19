using log4net.ObjectRenderer;
using System;
using System.Collections;
using System.IO;

namespace MSLivingChoices.Logging.ObjectRenders
{
	public class ExceptionRender : IObjectRenderer
	{
		public ExceptionRender()
		{
		}

		public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
		{
			for (Exception i = obj as Exception; i != null; i = i.InnerException)
			{
				this.WriteException(i, writer);
			}
		}

		private void WriteException(Exception ex, TextWriter writer)
		{
			writer.WriteLine("Type: {0}", ex.GetType().FullName);
			writer.WriteLine("Message: {0}", ex.Message);
			writer.WriteLine("Source: {0}", ex.Source);
			writer.WriteLine("TargetSite: {0}", ex.TargetSite);
			this.WriteExceptionData(ex, writer);
			writer.WriteLine("StackTrace: {0}", ex.StackTrace);
		}

		private void WriteExceptionData(Exception ex, TextWriter writer)
		{
			foreach (DictionaryEntry datum in ex.Data)
			{
				writer.WriteLine("{0}: {1}", datum.Key, datum.Value);
			}
		}
	}
}