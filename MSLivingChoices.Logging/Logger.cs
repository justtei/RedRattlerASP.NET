using log4net;
using log4net.Util;
using MSLivingChoices.Logging.CustomLoggers;
using MSLivingChoices.Logging.Messages;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;

namespace MSLivingChoices.Logging
{
	public static class Logger
	{
		private readonly static MultipleLogger DebugLog;

		private readonly static MultipleLogger InfoLog;

		private readonly static MultipleLogger WarnLog;

		private readonly static MultipleLogger ErrorLog;

		private readonly static MultipleLogger FatalLog;

		private readonly static bool IsEnabledDebugLog;

		static Logger()
		{
			Logger.DebugLog = new MultipleLogger();
			Logger.InfoLog = new MultipleLogger();
			Logger.WarnLog = new MultipleLogger();
			Logger.ErrorLog = new MultipleLogger();
			Logger.FatalLog = new MultipleLogger();
			Logger.IsEnabledDebugLog = Logger.GetBoolValueFromWebConfig("Mslc.Common.Logger.Trace.IsEnabled");
			if (Logger.GetBoolValueFromWebConfig("Mslc.Common.Logger.File.IsEnabled"))
			{
				Logger.DebugLog.AddLogger(LogManager.GetLogger("DebugFileLogger"));
				Logger.InfoLog.AddLogger(LogManager.GetLogger("InfoFileLogger"));
				Logger.WarnLog.AddLogger(LogManager.GetLogger("WarnFileLogger"));
				Logger.ErrorLog.AddLogger(LogManager.GetLogger("ErrorFileLogger"));
				Logger.FatalLog.AddLogger(LogManager.GetLogger("FatalFileLogger"));
			}
			if (Logger.GetBoolValueFromWebConfig("Mslc.Common.Logger.Db.IsEnabled"))
			{
				Logger.DebugLog.AddLogger(LogManager.GetLogger("DebugDbLogger"));
				Logger.InfoLog.AddLogger(LogManager.GetLogger("InfoDbLogger"));
				Logger.WarnLog.AddLogger(LogManager.GetLogger("WarnDbLogger"));
				Logger.ErrorLog.AddLogger(LogManager.GetLogger("ErrorDbLogger"));
				Logger.FatalLog.AddLogger(LogManager.GetLogger("FatalDbLogger"));
			}
		}

		public static void Debug(Message message)
		{
			if (Logger.IsEnabledDebugLog)
			{
				Logger.PutMachineName();
				Logger.PutUrl();
				Logger.PutReferrerUrl();
				Logger.PutPageTypeId();
				Logger.DebugLog.Debug(message.Text);
			}
		}

		public static void DebugFormat(Message message, params object[] args)
		{
			if (Logger.IsEnabledDebugLog)
			{
				Logger.PutMachineName();
				Logger.PutUrl();
				Logger.PutReferrerUrl();
				Logger.PutPageTypeId();
				Logger.DebugLog.DebugFormat(message.Text, args);
			}
		}

		public static void Error(Message message)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.PutUrl();
			Logger.PutReferrerUrl();
			Logger.PutPageTypeId();
			Logger.ErrorLog.Error(message.Text);
		}

		public static void Error(Message message, Exception exception)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.PutUrl();
			Logger.PutReferrerUrl();
			Logger.PutPageTypeId();
			Logger.ErrorLog.Error(message.Text, exception);
		}

		public static void ErrorFormat(Message message, params object[] args)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.PutUrl();
			Logger.PutReferrerUrl();
			Logger.PutPageTypeId();
			Logger.ErrorLog.ErrorFormat(message.Text, args);
		}

		public static void ErrorFormat(Message message, Exception exception, params object[] args)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.PutUrl();
			Logger.PutReferrerUrl();
			Logger.PutPageTypeId();
			Logger.ErrorLog.Error(string.Format(message.Text, args), exception);
		}

		public static void Fatal(Message message)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.PutUrl();
			Logger.PutReferrerUrl();
			Logger.PutPageTypeId();
			Logger.FatalLog.Fatal(message.Text);
		}

		public static void Fatal(Message message, Exception exception)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.PutUrl();
			Logger.PutReferrerUrl();
			Logger.PutPageTypeId();
			Logger.FatalLog.Fatal(message.Text, exception);
		}

		public static void FatalFormat(Message message, params object[] args)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.PutUrl();
			Logger.PutReferrerUrl();
			Logger.PutPageTypeId();
			Logger.FatalLog.FatalFormat(message.Text, args);
		}

		public static void FatalFormat(Message message, Exception exception, params object[] args)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.PutUrl();
			Logger.PutReferrerUrl();
			Logger.PutPageTypeId();
			Logger.FatalLog.Fatal(string.Format(message.Text, args), exception);
		}

		private static bool GetBoolValueFromWebConfig(string name)
		{
			bool flag;
			bool.TryParse(ConfigurationManager.AppSettings[name], out flag);
			return flag;
		}

		public static void Info(Message message)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.InfoLog.Info(message.Text);
		}

		public static void InfoFormat(Message message, params object[] args)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.InfoLog.InfoFormat(message.Text, args);
		}

		private static void PutMachineName()
		{
			string machineName;
			try
			{
				machineName = Environment.MachineName;
			}
			catch (Exception exception)
			{
				machineName = null;
			}
			log4net.ThreadContext.Properties["machineName"] = machineName;
		}

		private static void PutMessageKey(Message message)
		{
			log4net.ThreadContext.Properties["messageKey"] = message.Key;
		}

		private static void PutPageTypeId()
		{
			int? nullable;
			try
			{
				if (HttpContext.Current.Request.RequestContext.RouteData.Values["pageType"] != null)
				{
					nullable = new int?((int)HttpContext.Current.Request.RequestContext.RouteData.Values["pageType"]);
				}
				else {
					nullable = null;
				}
			}
			catch (Exception exception)
			{
				nullable = null;
			}
			log4net.ThreadContext.Properties["pageTypeId"] = nullable;
		}

		private static void PutReferrerUrl()
		{
			string str = null;
			try
			{
				if (HttpContext.Current != null && HttpContext.Current.Request.UrlReferrer != null)
				{
					str = HttpContext.Current.Request.UrlReferrer.ToString();
					if (string.IsNullOrWhiteSpace(str))
					{
						str = null;
					}
				}
			}
			catch (Exception exception)
			{
				str = null;
			}
			log4net.ThreadContext.Properties["referrer"] = str;
		}

		private static void PutUrl()
		{
			string str = null;
			try
			{
				if (HttpContext.Current != null)
				{
					str = HttpContext.Current.Request.Url.ToString();
					if (string.IsNullOrWhiteSpace(str))
					{
						str = null;
					}
				}
			}
			catch (Exception exception)
			{
				str = null;
			}
			log4net.ThreadContext.Properties["url"] = str;
		}

		public static void Warn(Message message)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.WarnLog.Warn(message.Text);
		}

		public static void WarnFormat(Message message, params object[] args)
		{
			Logger.PutMessageKey(message);
			Logger.PutMachineName();
			Logger.WarnLog.WarnFormat(message.Text, args);
		}
	}
}