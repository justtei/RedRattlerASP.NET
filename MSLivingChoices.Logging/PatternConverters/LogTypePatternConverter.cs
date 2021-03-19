using log4net.Core;
using log4net.Layout.Pattern;
using MSLivingChoices.Logging.LogTypes;
using System;
using System.IO;

namespace MSLivingChoices.Logging.PatternConverters
{
	internal class LogTypePatternConverter : PatternLayoutConverter
	{
		public LogTypePatternConverter()
		{
		}

		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			LogType logType;
			string name = loggingEvent.Level.Name;
			if (name == "DEBUG")
			{
				logType = LogType.Debug;
			}
			else if (name == "INFO")
			{
				logType = LogType.Info;
			}
			else if (name == "WARN")
			{
				logType = LogType.Warn;
			}
			else if (name == "ERROR")
			{
				logType = LogType.Error;
			}
			else if (name == "FATAL")
			{
				logType = LogType.Fatal;
			}
			else
			{
				logType = (LogType)0;
			}
			writer.Write((int)logType);
		}
	}
}