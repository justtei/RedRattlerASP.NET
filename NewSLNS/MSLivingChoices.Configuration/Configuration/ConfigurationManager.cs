using MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache;
using MSLivingChoices.Configuration.ConfigurationSections.MsSqlCache;
using MSLivingChoices.Configuration.ConfigurationSections.SearchTemplates;
using MSLivingChoices.Configuration.ConfigurationSections.UrlRedirects;
using MSLivingChoices.Configuration.Entities.SearchTemplates;
using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Caching;
using System.Web.Security;

namespace MSLivingChoices.Configuration
{
	public class ConfigurationManager
	{
		private static MSLivingChoices.Configuration.ConfigurationManager _configurationManager;

		private readonly static object Locker;

		public const int AmenityNameMaxLength = 100;

		public const int CallTrackingPhoneMaxLength = 20;

		public const int CallTrackingProvisionPhoneMaxLength = 20;

		public const int CallTrackingListingPhoneMaxLength = 20;

		public const int CommunityNameMaxLength = 50;

		public const int CommunityServiceNameMaxLength = 50;

		public const int CommunityVirtualTourMaxLength = 200;

		public const int CommunityWebsiteUrlMaxLength = 200;

		public const int ContactFirstNameMaxLength = 50;

		public const int ContactLastNameMaxLength = 50;

		public const int CouponDescriptionMaxLength = 200;

		public const int CouponNameMaxLength = 50;

		public const int EmailMaxLength = 255;

		public const int FloorPlanNameMaxLength = 50;

		public const int HouseNameMaxLength = 50;

		public const int OfficeHoursNoteMaxLength = 100;

		public const int OwnerNameMaxLength = 50;

		public const int OwnerWebsiteUrlMaxLength = 200;

		public const int PhoneNumberMaxLength = 20;

		public const int PostalCodeMaxLength = 10;

		public const int ServiceProviderNameMaxLength = 50;

		public const int ServiceProviderWebsiteUrlMaxLength = 200;

		public const int SpecHomeNameMaxLength = 50;

		public const int StreetAddressMaxLength = 50;

		public const string ActiveCountryCode = "USA";

		public const int ActiveCountryId = 1;

		public int AdditionalImagesMaxCount
		{
			get;
			private set;
		}

		public string AddThisKey
		{
			get;
			private set;
		}

		public string AdminJsDateFormat
		{
			get;
			private set;
		}

		public string AdminServerDateFormat
		{
			get;
			private set;
		}

		public IEnumerable<string> AppsLogsPaths
		{
			get;
			private set;
		}

		public int AutocompleteTimerDelay
		{
			get;
			private set;
		}

		public int BasePackgeCommunityDisplayImageCollectionMaxLength
		{
			get;
			private set;
		}

		public int BasePackgeServiceProviderDisplayImageCollectionMaxLength
		{
			get;
			private set;
		}

		public Guid CallTrackingPhoneSchedulerUserId
		{
			get;
			private set;
		}

		public string CanonicalPattern
		{
			get;
			private set;
		}

		public int CarouselShiftDelay
		{
			get;
			private set;
		}

		public int ClientImagesCashExpiresDays
		{
			get;
			private set;
		}

		public string ClientJsDateFormat
		{
			get;
			private set;
		}

		public string ClientServerDateFormat
		{
			get;
			private set;
		}

		public int CommunityImagesMaxLength
		{
			get;
			private set;
		}

		public long? CommunityListingPhoneTypeId
		{
			get;
			private set;
		}

		public int CommunityUnitImagesMaxLength
		{
			get;
			private set;
		}

		public int CommunityUnitsMaxLength
		{
			get;
			private set;
		}

		public Dictionary<int, List<string>> CompetitiveItems
		{
			get;
			set;
		}

		public string CouponDateFormat
		{
			get;
			private set;
		}

		public string CssJsVersion
		{
			get;
			private set;
		}

		public Guid? CurrentUserId
		{
			get
			{
				MembershipUser user = Membership.GetUser();
				if (user != null && user.ProviderUserKey != null)
				{
					return (Guid?)user.ProviderUserKey;
				}
				return null;
			}
		}

		public int DbCacheSlidingExpirationMinutes
		{
			get;
			private set;
		}

		public DateTime DefaultEndDate
		{
			get;
			private set;
		}

		public int DefaultGridPageNumber
		{
			get;
			private set;
		}

		public int DefaultGridPageSize
		{
			get;
			private set;
		}

		public int DefaultPageSize
		{
			get;
			private set;
		}

		public int DisplayBasePackageCommunityUnitCollectionMaxLength
		{
			get;
			private set;
		}

		public string DomainFindPatter
		{
			get;
			private set;
		}

		public string DomainReplace
		{
			get;
			private set;
		}

		public bool EnableCommunityUnitsAutoNaming
		{
			get;
			private set;
		}

		public int FeaturedCommunitiesMaxCount
		{
			get;
			private set;
		}

		public int FeaturedProvidersMaxCount
		{
			get;
			private set;
		}

		public string GetActiveImagesQuery
		{
			get;
			private set;
		}

		public string GetInactiveImagesQuery
		{
			get;
			private set;
		}

		public string GoogleAnalyticsKey
		{
			get;
			private set;
		}

		public string GoogleMapsApiKey
		{
			get;
			private set;
		}

		public string IgnoreSearchTypePattern
		{
			get;
			private set;
		}

		public int ImageProcessingServiceMaxRetryCount
		{
			get;
			private set;
		}

		public string ImageQueueConnectionString
		{
			get;
			private set;
		}

		public string ImagesDriveBaseUrl
		{
			get;
			private set;
		}

		public string ImagesDrivePath
		{
			get;
			private set;
		}

		public int IndexStubCitiesMaxCount
		{
			get;
			private set;
		}

		public static MSLivingChoices.Configuration.ConfigurationManager Instance
		{
			get
			{
				if (MSLivingChoices.Configuration.ConfigurationManager._configurationManager == null)
				{
					lock (MSLivingChoices.Configuration.ConfigurationManager.Locker)
					{
						if (MSLivingChoices.Configuration.ConfigurationManager._configurationManager == null)
						{
							MSLivingChoices.Configuration.ConfigurationManager._configurationManager = new MSLivingChoices.Configuration.ConfigurationManager();
						}
					}
				}
				return MSLivingChoices.Configuration.ConfigurationManager._configurationManager;
			}
		}

		public bool IsEnabledDbCache
		{
			get;
			private set;
		}

		public bool IsEnabledJsCssOptimization
		{
			get;
			private set;
		}

		public bool IsEnabledPngOptimization
		{
			get;
			private set;
		}

		public bool IsExceptionRewrite
		{
			get;
			private set;
		}

		public bool IsWebSessionDisabled
		{
			get;
			private set;
		}

		public int LogFilesKeepingDays
		{
			get;
			private set;
		}

		public int LogoImagesMaxLength
		{
			get;
			private set;
		}

		public string MailFromAddress
		{
			get;
			set;
		}

		public string MailFromDisplayName
		{
			get;
			set;
		}

		public string MailTemplatesPath
		{
			get;
			private set;
		}

		public string MarkImagesAsDeletedQuery
		{
			get;
			private set;
		}

		public int MaxAutocompleteVariantsCount
		{
			get;
			private set;
		}

		public string MlcSlcConnectionString
		{
			get;
			private set;
		}

		public string MlcSlcEntryName
		{
			get;
			private set;
		}

		public string MomentJsTimeFormat
		{
			get;
			private set;
		}

		public MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache.MsSqlCache MsSqlCache
		{
			get;
			set;
		}

		public int NearbyCitiesMaxCount
		{
			get;
			private set;
		}

		public string NoImageListingSrc
		{
			get;
			private set;
		}

		public string NoImageUnitSrc
		{
			get;
			private set;
		}

		public string NumberFormat
		{
			get;
			private set;
		}

		public string OldDetailsPattern
		{
			get;
			private set;
		}

		public string OldSearchPattern
		{
			get;
			private set;
		}

		public Size OriginalResolution
		{
			get;
			private set;
		}

		public string PngOptimizerArguments
		{
			get;
			private set;
		}

		public string PngOptimizerPath
		{
			get;
			private set;
		}

		public List<RedirectElement> RedirectRules
		{
			get;
			private set;
		}

		public int SearchAmenitiesListMaxCount
		{
			get;
			private set;
		}

		public List<MSLivingChoices.Configuration.Entities.SearchTemplates.SearchTemplates> SearchTemplates
		{
			get;
			private set;
		}

		public int SearchTypeStubCitiesMaxCount
		{
			get;
			private set;
		}

		public int SearchTypeStubFeaturedCitiesCount
		{
			get;
			private set;
		}

		public long? ServiceListingPhoneTypeId
		{
			get;
			private set;
		}

		public int ServiceProviderImagesMaxLength
		{
			get;
			private set;
		}

		public int ShortDescriptionLength
		{
			get;
			private set;
		}

		public bool SitemapMemorySaving
		{
			get;
			private set;
		}

		public string SitemapsSubFolder
		{
			get;
			private set;
		}

		public string SiteRootPath
		{
			get;
			private set;
		}

		public string SiteUrl
		{
			get;
			private set;
		}

		public int SlideDuration
		{
			get;
			private set;
		}

		public string SmtpHost
		{
			get;
			private set;
		}

		public int SmtpPort
		{
			get;
			private set;
		}

		public string SpaceFindPatter
		{
			get;
			private set;
		}

		public string SpacesPattern
		{
			get;
			private set;
		}

		public string SpacesReplace
		{
			get;
			private set;
		}

		public int SqlCommandTimeoutSeconds
		{
			get;
			private set;
		}

		public HashSet<Tuple<int, int>> SupportedImageResolutions
		{
			get;
			private set;
		}

		public string TechnicalPattern
		{
			get;
			private set;
		}

		public string TempImageDirectoryPath
		{
			get;
			private set;
		}

		public string TempImagesDirectoryPath
		{
			get;
			private set;
		}

		public Size ThumbnailResolution
		{
			get;
			private set;
		}

		public string TimeFormat
		{
			get;
			private set;
		}

		public string TimePickerTimeFormat
		{
			get;
			private set;
		}

		public int TimeStepMinute
		{
			get;
			private set;
		}

		public string TrailingSlashPattern
		{
			get;
			private set;
		}

		public string UpperCasePattern
		{
			get;
			private set;
		}

		public string UrlScheme
		{
			get;
			private set;
		}

		public string UserInfoCookieName
		{
			get;
			private set;
		}

		public int UserInfoCookiesLifeSpanDays
		{
			get;
			private set;
		}

		public string WhiteListPattern
		{
			get;
			private set;
		}

		static ConfigurationManager()
		{
			MSLivingChoices.Configuration.ConfigurationManager.Locker = new object();
		}

		private ConfigurationManager()
		{
			this.Init();
		}

		private bool GetBooleanValueFromWebConfig(string name)
		{
			bool flag;
			bool.TryParse(this.GetValueFromWebConfig(name), out flag);
			return flag;
		}

		private DateTime GetDateTimeValueFromWebConfig(string name)
		{
			DateTime dateTime;
			DateTime.TryParse(this.GetValueFromWebConfig(name), out dateTime);
			return dateTime;
		}

		private Size GetImageResolutionFromWebConfig(string name)
		{
			int num;
			Size size = new Size();
			string item = System.Configuration.ConfigurationManager.AppSettings[name];
			if (string.IsNullOrWhiteSpace(item))
			{
				Logger.WarnFormat(LogMessages.Configuration.ConfigurationManager.ValueNotFound, new object[] { name });
				return size;
			}
			string str = item.Substring(0, item.IndexOf('x')).Trim();
			string str1 = item.Substring(item.IndexOf('x') + 1).Trim();
			int num1 = 0;
			if (!int.TryParse(str, out num) || !int.TryParse(str1, out num1))
			{
				Logger.WarnFormat(LogMessages.Configuration.ConfigurationManager.IncorrectResolutionValue, new object[] { item });
			}
			size.Width = num;
			size.Height = num1;
			return size;
		}

		private int GetIntValueFromWebConfig(string name)
		{
			int num;
			int.TryParse(this.GetValueFromWebConfig(name), out num);
			return num;
		}

		private long? GetLongValueFromWebConfig(string name)
		{
			long num;
			if (long.TryParse(this.GetValueFromWebConfig(name), out num))
			{
				return new long?(num);
			}
			return null;
		}

		private static MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache.MsSqlCache GetMsSqlCacheData()
		{
			object obj;
			CacheItemPriority cacheItemPriority;
			MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache.MsSqlCache msSqlCache = null;
			if (MSLivingChoices.Configuration.ConfigurationManager.GetSection("msSqlCache", out obj))
			{
				MsSqlCacheSection msSqlCacheSection = (MsSqlCacheSection)obj;
				msSqlCache = new MSLivingChoices.Configuration.ConfigurationEntities.MsSqlCache.MsSqlCache();
				foreach (CachedDataSpElement cachedDataDependencyMap in msSqlCacheSection.CachedDataDependencyMap)
				{
					CachedDataSpDependencies cachedDataSpDependency = new CachedDataSpDependencies()
					{
						StoredProcedureName = cachedDataDependencyMap.Name
					};
					foreach (CachedDataDependencyElement dependency in cachedDataDependencyMap.Dependencies)
					{
						cachedDataSpDependency.Dependencies.Add(dependency.Table);
					}
					if (!Enum.TryParse<CacheItemPriority>(cachedDataDependencyMap.Priority, true, out cacheItemPriority))
					{
						cacheItemPriority = CacheItemPriority.Normal;
					}
					cachedDataSpDependency.Priority = cacheItemPriority;
					msSqlCache.CachedDataDependencyMap.Add(cachedDataSpDependency);
				}
				foreach (FreeCacheSpElement freeCacheDependencyMap in msSqlCacheSection.FreeCacheDependencyMap)
				{
					FreeCacheSpDependencies freeCacheSpDependency = new FreeCacheSpDependencies()
					{
						StoredProcedureName = freeCacheDependencyMap.Name
					};
					foreach (FreeCacheDependencyElement freeCacheDependencyElement in freeCacheDependencyMap.Dependencies)
					{
						freeCacheSpDependency.Dependencies.Add(freeCacheDependencyElement.StoredProcedure);
					}
					msSqlCache.FreeCacheDependencyMap.Add(freeCacheSpDependency);
				}
			}
			return msSqlCache;
		}

		private static List<RedirectElement> GetRedirectRules()
		{
			object obj;
			if (!MSLivingChoices.Configuration.ConfigurationManager.GetSection("urlRedirects", out obj))
			{
				return null;
			}
			UrlRedirectSection urlRedirectSection = (UrlRedirectSection)obj;
			ConfigurationElement[] configurationElementArray = new ConfigurationElement[urlRedirectSection.Redirects.Count];
			urlRedirectSection.Redirects.CopyTo(configurationElementArray, 0);
			return configurationElementArray.Cast<RedirectElement>().ToList<RedirectElement>();
		}

		private static List<MSLivingChoices.Configuration.Entities.SearchTemplates.SearchTemplates> GetSearchTemplates()
		{
			object obj;
			List<MSLivingChoices.Configuration.Entities.SearchTemplates.SearchTemplates> searchTemplates = null;
			if (MSLivingChoices.Configuration.ConfigurationManager.GetSection("searchTemplates", out obj))
			{
				SearchTemplatesSection searchTemplatesSection = (SearchTemplatesSection)obj;
				searchTemplates = new List<MSLivingChoices.Configuration.Entities.SearchTemplates.SearchTemplates>();
				foreach (CountryElement countryList in searchTemplatesSection.CountryList)
				{
					MSLivingChoices.Configuration.Entities.SearchTemplates.SearchTemplates searchTemplate = new MSLivingChoices.Configuration.Entities.SearchTemplates.SearchTemplates()
					{
						Placeholder = countryList.Placeholder,
						CountryCode = countryList.CountryCode
					};
					foreach (TemplateElement template in countryList.Templates)
					{
						QueryTemplate queryTemplate = new QueryTemplate()
						{
							LookupLocation = template.LookupLocation,
							Template = template.Template,
							Url = template.Url
						};
						searchTemplate.Templates.Add(queryTemplate);
					}
					searchTemplates.Add(searchTemplate);
				}
			}
			return searchTemplates;
		}

		private static bool GetSection(string sectionName, out object section)
		{
			section = System.Configuration.ConfigurationManager.GetSection(sectionName);
			if (section != null)
			{
				return true;
			}
			Logger.WarnFormat(LogMessages.Configuration.ConfigurationManager.SectionNotFound, new object[] { sectionName });
			return false;
		}

		private HashSet<Tuple<int, int>> GetSupportedResolutionsFromWebConfig(string name)
		{
			HashSet<Tuple<int, int>> tuples = new HashSet<Tuple<int, int>>();
			string item = System.Configuration.ConfigurationManager.AppSettings[name];
			if (string.IsNullOrWhiteSpace(item))
			{
				Logger.WarnFormat(LogMessages.Configuration.ConfigurationManager.ValueNotFound, new object[] { name });
				return tuples;
			}
			string[] strArrays = item.Split(",;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string str = strArrays[i];
				string str1 = str.Substring(0, str.IndexOf('x')).Trim();
				string str2 = str.Substring(str.IndexOf('x') + 1).Trim();
				int num = 0;
				int num1 = 0;
				if (!int.TryParse(str1, out num) || !int.TryParse(str2, out num1))
				{
					Logger.WarnFormat(LogMessages.Configuration.ConfigurationManager.IncorrectResolutionValue, new object[] { str });
				}
				else
				{
					tuples.Add(new Tuple<int, int>(num, num1));
				}
			}
			return tuples;
		}

		private string GetValueFromWebConfig(string name)
		{
			string item = System.Configuration.ConfigurationManager.AppSettings[name];
			if (string.IsNullOrWhiteSpace(item))
			{
				Logger.WarnFormat(LogMessages.Configuration.ConfigurationManager.ValueNotFound, new object[] { name });
			}
			return item;
		}

		private void Init()
		{
			this.MlcSlcConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MLCSLC"].ConnectionString;
			this.ImageQueueConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ImageQueue"].ConnectionString;
			this.TempImagesDirectoryPath = this.GetValueFromWebConfig("Mslc.Site.TempImageDirectoryPath");
			this.ImagesDrivePath = this.GetValueFromWebConfig("Mslc.Services.ImageProcessing.ImageDrivePath");
			this.ImagesDriveBaseUrl = this.GetValueFromWebConfig("Mslc.Services.ImageProcessing.ImageDriveBaseUrl");
			this.OriginalResolution = this.GetImageResolutionFromWebConfig("Mslc.Site.OriginalImageResolution");
			this.ThumbnailResolution = this.GetImageResolutionFromWebConfig("Mslc.Site.ThumbnailImageResolution");
			this.NoImageListingSrc = this.GetValueFromWebConfig("Mslc.Site.NoImage.ListingSrc");
			this.NoImageUnitSrc = this.GetValueFromWebConfig("Mslc.Site.NoImage.UnitSrc");
			this.MaxAutocompleteVariantsCount = this.GetIntValueFromWebConfig("Mslc.Site.MaxAutocompleteVariantsCount");
			this.AutocompleteTimerDelay = this.GetIntValueFromWebConfig("Mslc.Site.AutocompleteTimerDelay");
			this.DefaultGridPageNumber = this.GetIntValueFromWebConfig("Mslc.Site.DefaultGridPageNumber");
			this.DefaultGridPageSize = this.GetIntValueFromWebConfig("Mslc.Site.DefaultGridPageSize");
			this.TimeFormat = this.GetValueFromWebConfig("Mslc.Site.TimeFormat");
			this.TimePickerTimeFormat = this.GetValueFromWebConfig("Mslc.Site.TimePickerTimeFormat");
			this.MomentJsTimeFormat = this.GetValueFromWebConfig("Mslc.Site.MomentJsTimeFormat");
			this.CouponDateFormat = this.GetValueFromWebConfig("Mslc.Site.CouponDateFormat");
			this.TimeStepMinute = this.GetIntValueFromWebConfig("Mslc.Site.TimeStepMinute");
			this.AdminServerDateFormat = this.GetValueFromWebConfig("Mslc.Site.Admin.ServerDateFormat");
			this.AdminJsDateFormat = this.GetValueFromWebConfig("Mslc.Site.Admin.JsDateFormat");
			this.ClientServerDateFormat = this.GetValueFromWebConfig("Mslc.Site.Client.ServerDateFormat");
			this.ClientJsDateFormat = this.GetValueFromWebConfig("Mslc.Site.Client.JsDateFormat");
			this.NumberFormat = this.GetValueFromWebConfig("Mslc.Site.NumberFormat");
			this.CommunityListingPhoneTypeId = this.GetLongValueFromWebConfig("Mslc.Site.CommunityListingPhoneTypeId");
			this.ServiceListingPhoneTypeId = this.GetLongValueFromWebConfig("Mslc.Site.ServiceListingPhoneTypeId");
			this.DefaultEndDate = this.GetDateTimeValueFromWebConfig("Mslc.Site.DefaultEndDate");
			this.ShortDescriptionLength = this.GetIntValueFromWebConfig("Mslc.Site.ShortDescriptionLength");
			this.SlideDuration = this.GetIntValueFromWebConfig("Mslc.Site.SlideDuration");
			this.CssJsVersion = this.GetValueFromWebConfig("Mslc.Site.CssJsVersion");
			this.LogoImagesMaxLength = this.GetIntValueFromWebConfig("Mslc.Site.LogoImagesMaxLength");
			this.CommunityImagesMaxLength = this.GetIntValueFromWebConfig("Mslc.Site.CommunityImagesMaxLength");
			this.BasePackgeCommunityDisplayImageCollectionMaxLength = this.GetIntValueFromWebConfig("Mslc.Site.BasePackgeCommunityDisplayImageCollectionMaxLength");
			this.ServiceProviderImagesMaxLength = this.GetIntValueFromWebConfig("Mslc.Site.ServiceProviderImagesMaxLength");
			this.BasePackgeServiceProviderDisplayImageCollectionMaxLength = this.GetIntValueFromWebConfig("Mslc.Site.BasePackgeServiceProviderDisplayImageCollectionMaxLength");
			this.CommunityUnitImagesMaxLength = this.GetIntValueFromWebConfig("Mslc.Site.CommunityUnitImagesMaxLength");
			this.CommunityUnitsMaxLength = this.GetIntValueFromWebConfig("Mslc.Site.CommunityUnitsMaxLength");
			this.DisplayBasePackageCommunityUnitCollectionMaxLength = this.GetIntValueFromWebConfig("Mslc.Site.DisplayBasePackageCommunityUnitCollectionMaxLength");
			string valueFromWebConfig = this.GetValueFromWebConfig("Mslc.CallTrackingScheduler.CallTrackingPhoneSchedulerUserId");
			this.CallTrackingPhoneSchedulerUserId = (valueFromWebConfig != null ? new Guid(valueFromWebConfig) : Guid.Empty);
			this.GoogleMapsApiKey = this.GetValueFromWebConfig("Mslc.Site.Google.MapsApiKey");
			this.GoogleAnalyticsKey = this.GetValueFromWebConfig("Mslc.Site.Google.AnalyticsKey");
			this.AddThisKey = this.GetValueFromWebConfig("Mslc.Site.AddThisKey");
			this.MlcSlcEntryName = this.GetValueFromWebConfig("Mslc.Site.MlcSlcEntryName");
			this.IsEnabledDbCache = this.GetBooleanValueFromWebConfig("Mslc.Site.IsEnabledDbCache");
			this.IsWebSessionDisabled = this.GetBooleanValueFromWebConfig("Mslc.Site.IsWebSessionDisabled");
			this.DbCacheSlidingExpirationMinutes = this.GetIntValueFromWebConfig("Mslc.Site.DbCacheSlidingExpirationMinutes");
			this.ClientImagesCashExpiresDays = this.GetIntValueFromWebConfig("Mslc.Site.ClientImagesCashExpiresDays");
			this.SiteRootPath = this.GetValueFromWebConfig("Mslc.SitemapGenerator.SiteRootPath");
			this.SiteUrl = this.GetValueFromWebConfig("Mslc.Site.CanonicalUrl");
			if (!string.IsNullOrWhiteSpace(this.SiteUrl) && this.SiteUrl.EndsWith("/"))
			{
				this.SiteUrl = this.SiteUrl.Remove(this.SiteUrl.Length - 1, 1);
			}
			this.SitemapsSubFolder = this.GetValueFromWebConfig("Mslc.SitemapGenerator.SubFolder");
			this.SitemapMemorySaving = this.GetBooleanValueFromWebConfig("Mslc.SitemapGenerator.MemorySaving");
			this.GetInactiveImagesQuery = this.GetValueFromWebConfig("Mslc.AppRelatedFilesCleaner.GetInactiveImagesQuery");
			this.MarkImagesAsDeletedQuery = this.GetValueFromWebConfig("Mslc.AppRelatedFilesCleaner.MarkAsDeletedQuery");
			this.GetActiveImagesQuery = this.GetValueFromWebConfig("Mslc.AppRelatedFilesCleaner.GetActiveImagesQuery");
			this.LogFilesKeepingDays = this.GetIntValueFromWebConfig("Mslc.AppRelatedFilesCleaner.LogFilesKeepingDays");
			this.AppsLogsPaths = new string[] { this.GetValueFromWebConfig("Mslc.AppRelatedFilesCleaner.LogsPath.Cleaner"), this.GetValueFromWebConfig("Mslc.AppRelatedFilesCleaner.LogsPath.MslcSiteSite"), this.GetValueFromWebConfig("Mslc.AppRelatedFilesCleaner.LogsPath.MslcSiteMapGenerator"), this.GetValueFromWebConfig("Mslc.AppRelatedFilesCleaner.LogsPath.MslcCallTrackingScheduler"), this.GetValueFromWebConfig("Mslc.AppRelatedFilesCleaner.LogsPath.UmsSite"), this.GetValueFromWebConfig("Mslc.AppRelatedFilesCleaner.LogsPath.UmsService") };
			this.TempImageDirectoryPath = this.GetValueFromWebConfig("Mslc.Site.TempImageDirectoryPath");
			this.SupportedImageResolutions = this.GetSupportedResolutionsFromWebConfig("Mslc.Site.SupportedImageResolutions");
			this.CarouselShiftDelay = this.GetIntValueFromWebConfig("Mslc.Site.CarouselShiftDelayMiliseconds");
			this.MailTemplatesPath = this.GetValueFromWebConfig("Mslc.Mail.TemplatesPath");
			this.MailFromDisplayName = this.GetValueFromWebConfig("Mslc.Mail.From.Name");
			this.MailFromAddress = this.GetValueFromWebConfig("Mslc.Mail.From.Address");
			this.SmtpHost = this.GetValueFromWebConfig("Mslc.Mail.Smtp.Host");
			this.SmtpPort = this.GetIntValueFromWebConfig("Mslc.Mail.Smtp.Port");
			this.ImageProcessingServiceMaxRetryCount = this.GetIntValueFromWebConfig("Mslc.Services.ImageProcessing.MaxRetryCount");
			this.IsEnabledPngOptimization = this.GetBooleanValueFromWebConfig("Mslc.Services.ImageProcessing.EnablePngOptimization");
			this.PngOptimizerPath = this.GetValueFromWebConfig("Mslc.Services.ImageProcessing.PngOptimizer.Path");
			this.PngOptimizerArguments = this.GetValueFromWebConfig("Mslc.Services.ImageProcessing.PngOptimizer.Arguments");
			this.IsEnabledJsCssOptimization = this.GetBooleanValueFromWebConfig("Mslc.Site.EnableJsCssOptimization");
			this.SearchTemplates = MSLivingChoices.Configuration.ConfigurationManager.GetSearchTemplates();
			this.MsSqlCache = MSLivingChoices.Configuration.ConfigurationManager.GetMsSqlCacheData();
			this.DefaultPageSize = this.GetIntValueFromWebConfig("Mslc.Site.DefaultPageSize");
			this.UserInfoCookieName = this.GetValueFromWebConfig("Mslc.Site.Cookie.UserInfo.Name");
			this.UserInfoCookiesLifeSpanDays = this.GetIntValueFromWebConfig("Mslc.Site.Cookie.UserInfo.LifeSpanDays");
			this.SqlCommandTimeoutSeconds = this.GetIntValueFromWebConfig("Mslc.Common.DB.SqlCommandTimeoutSeconds");
			this.IsExceptionRewrite = this.GetBooleanValueFromWebConfig("Mslc.Site.IsExceptionRewrite");
			this.SearchAmenitiesListMaxCount = this.GetIntValueFromWebConfig("Mslc.Site.SearchAmenitiesListMaxCount");
			this.AdditionalImagesMaxCount = this.GetIntValueFromWebConfig("Mslc.Site.AdditionalImagesMaxCount");
			this.FeaturedCommunitiesMaxCount = this.GetIntValueFromWebConfig("Mslc.Site.FeaturedCommunitiesMaxCount");
			this.FeaturedProvidersMaxCount = this.GetIntValueFromWebConfig("Mslc.Site.FeaturedProvidersMaxCount");
			this.NearbyCitiesMaxCount = this.GetIntValueFromWebConfig("Mslc.Site.NearbyCitiesMaxCount");
			this.EnableCommunityUnitsAutoNaming = this.GetBooleanValueFromWebConfig("Mslc.Site.EnableCommunityUnitsAutoNaming");
			this.SearchTypeStubCitiesMaxCount = this.GetIntValueFromWebConfig("Mslc.Site.SearchTypeStub.CitiesMaxCount");
			this.IndexStubCitiesMaxCount = this.GetIntValueFromWebConfig("Mslc.Site.Index.CitiesMaxCount");
			this.SearchTypeStubFeaturedCitiesCount = this.GetIntValueFromWebConfig("Mslc.Site.SearchTypeStub.FeaturedCitiesCount");
			this.WhiteListPattern = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.WhiteList");
			this.OldDetailsPattern = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.OldDetails");
			this.OldSearchPattern = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.OldSearch");
			this.TechnicalPattern = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.Technical");
			this.TrailingSlashPattern = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.TrailingSlash");
			this.UpperCasePattern = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.UpperCase");
			this.SpacesPattern = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.Spaces");
			this.CanonicalPattern = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.Canonical");
			this.SpaceFindPatter = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.SpaceFind");
			this.DomainFindPatter = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.DomainFind");
			this.IgnoreSearchTypePattern = this.GetValueFromWebConfig("Mslc.Site.Url.Pattern.IgnoreSearchType");
			this.DomainReplace = this.GetValueFromWebConfig("Mslc.Site.Url.Replace.Domain");
			this.SpacesReplace = this.GetValueFromWebConfig("Mslc.Site.Url.Replace.Spaces");
			this.UrlScheme = this.GetValueFromWebConfig("Mslc.Site.Url.Scheme");
			this.RedirectRules = MSLivingChoices.Configuration.ConfigurationManager.GetRedirectRules();
		}

		public bool IsActiveCompetitiveItem(int package, string itemKey)
		{
			if (this.CompetitiveItems == null || !this.CompetitiveItems.ContainsKey(package))
			{
				return false;
			}
			return this.CompetitiveItems[package].Contains(itemKey);
		}
	}
}