using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Logging.CustomLoggers
{
	internal class MultipleLogger : ILog, ILoggerWrapper
	{
		private readonly RootLogger _rootLogger;

		public bool IsDebugEnabled
		{
			get
			{
				return this.Loggers.All<ILog>((ILog l) => l.IsDebugEnabled);
			}
		}

		public bool IsErrorEnabled
		{
			get
			{
				return this.Loggers.All<ILog>((ILog l) => l.IsErrorEnabled);
			}
		}

		public bool IsFatalEnabled
		{
			get
			{
				return this.Loggers.All<ILog>((ILog l) => l.IsFatalEnabled);
			}
		}

		public bool IsInfoEnabled
		{
			get
			{
				return this.Loggers.All<ILog>((ILog l) => l.IsInfoEnabled);
			}
		}

		public bool IsWarnEnabled
		{
			get
			{
				return this.Loggers.All<ILog>((ILog l) => l.IsWarnEnabled);
			}
		}

		public ILogger Logger
		{
			get
			{
				return this._rootLogger;
			}
		}

		private List<ILog> Loggers
		{
			get;
			set;
		}

		public MultipleLogger()
		{
			this._rootLogger = new RootLogger(Level.Off)
			{
				Additivity = false
			};
			this.Loggers = new List<ILog>();
		}

		public void AddLogger(ILog logger)
		{
			this.Loggers.Add(logger);
		}

		public void Debug(object message, Exception exception)
		{
			this.ExecuteLogging((ILog logger) => logger.Debug(message, exception));
		}

		public void Debug(object message)
		{
			this.ExecuteLogging((ILog logger) => logger.Debug(message));
		}

		public void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.DebugFormat(provider, format, args));
		}

		public void DebugFormat(string format, object arg0, object arg1, object arg2)
		{
			this.ExecuteLogging((ILog logger) => logger.DebugFormat(format, arg0, arg1, arg2));
		}

		public void DebugFormat(string format, object arg0, object arg1)
		{
			this.ExecuteLogging((ILog logger) => logger.DebugFormat(format, arg0, arg1));
		}

		public void DebugFormat(string format, object arg0)
		{
			this.ExecuteLogging((ILog logger) => logger.DebugFormat(format, arg0));
		}

		public void DebugFormat(string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.DebugFormat(format, args));
		}

		public void Error(object message, Exception exception)
		{
			this.ExecuteLogging((ILog logger) => logger.Error(message, exception));
		}

		public void Error(object message)
		{
			this.ExecuteLogging((ILog logger) => logger.Error(message));
		}

		public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.ErrorFormat(provider, format, args));
		}

		public void ErrorFormat(string format, object arg0, object arg1, object arg2)
		{
			this.ExecuteLogging((ILog logger) => logger.ErrorFormat(format, arg0, arg1, arg2));
		}

		public void ErrorFormat(string format, object arg0, object arg1)
		{
			this.ExecuteLogging((ILog logger) => logger.ErrorFormat(format, arg0, arg1));
		}

		public void ErrorFormat(string format, object arg0)
		{
			this.ExecuteLogging((ILog logger) => logger.ErrorFormat(format, arg0));
		}

		public void ErrorFormat(string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.ErrorFormat(format, args));
		}

		private void ExecuteLogging(Action<ILog> action)
		{
			foreach (ILog logger in this.Loggers)
			{
				action(logger);
			}
		}

		public void Fatal(object message, Exception exception)
		{
			this.ExecuteLogging((ILog logger) => logger.Fatal(message, exception));
		}

		public void Fatal(object message)
		{
			this.ExecuteLogging((ILog logger) => logger.Fatal(message));
		}

		public void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.FatalFormat(provider, format, args));
		}

		public void FatalFormat(string format, object arg0, object arg1, object arg2)
		{
			this.ExecuteLogging((ILog logger) => logger.FatalFormat(format, arg0, arg1, arg2));
		}

		public void FatalFormat(string format, object arg0, object arg1)
		{
			this.ExecuteLogging((ILog logger) => logger.FatalFormat(format, arg0, arg1));
		}

		public void FatalFormat(string format, object arg0)
		{
			this.ExecuteLogging((ILog logger) => logger.FatalFormat(format, arg0));
		}

		public void FatalFormat(string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.FatalFormat(format, args));
		}

		public void Info(object message, Exception exception)
		{
			this.ExecuteLogging((ILog logger) => logger.Info(message, exception));
		}

		public void Info(object message)
		{
			this.ExecuteLogging((ILog logger) => logger.Info(message));
		}

		public void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.InfoFormat(provider, format, args));
		}

		public void InfoFormat(string format, object arg0, object arg1, object arg2)
		{
			this.ExecuteLogging((ILog logger) => logger.InfoFormat(format, arg0, arg1, arg2));
		}

		public void InfoFormat(string format, object arg0, object arg1)
		{
			this.ExecuteLogging((ILog logger) => logger.InfoFormat(format, arg0, arg1));
		}

		public void InfoFormat(string format, object arg0)
		{
			this.ExecuteLogging((ILog logger) => logger.InfoFormat(format, arg0));
		}

		public void InfoFormat(string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.InfoFormat(format, args));
		}

		public void Warn(object message, Exception exception)
		{
			this.ExecuteLogging((ILog logger) => logger.Warn(message, exception));
		}

		public void Warn(object message)
		{
			this.ExecuteLogging((ILog logger) => logger.Warn(message));
		}

		public void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.WarnFormat(provider, format, args));
		}

		public void WarnFormat(string format, object arg0, object arg1, object arg2)
		{
			this.ExecuteLogging((ILog logger) => logger.WarnFormat(format, arg0, arg1, arg2));
		}

		public void WarnFormat(string format, object arg0, object arg1)
		{
			this.ExecuteLogging((ILog logger) => logger.WarnFormat(format, arg0, arg1));
		}

		public void WarnFormat(string format, object arg0)
		{
			this.ExecuteLogging((ILog logger) => logger.WarnFormat(format, arg0));
		}

		public void WarnFormat(string format, params object[] args)
		{
			this.ExecuteLogging((ILog logger) => logger.WarnFormat(format, args));
		}
	}
}