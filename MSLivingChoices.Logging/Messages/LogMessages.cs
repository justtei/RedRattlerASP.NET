using MSLivingChoices.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MSLivingChoices.Logging.Messages
{
	public static class LogMessages
	{
		public static void CheckDuplicateMessagesKeys()
		{
			HashSet<int> nums = new HashSet<int>();
			Type[] nestedTypes = typeof(LogMessages).GetNestedTypes();
			for (int i = 0; i < (int)nestedTypes.Length; i++)
			{
				Type[] typeArray = nestedTypes[i].GetNestedTypes();
				for (int j = 0; j < (int)typeArray.Length; j++)
				{
					Type type = typeArray[j];
					FieldInfo[] fields = type.GetFields();
					for (int k = 0; k < (int)fields.Length; k++)
					{
						int key = ((Message)fields[k].GetValue(null)).Key;
						if (!nums.Add(key))
						{
							Logger.WarnFormat(LogMessages.Logging.Messages.DuplicateMessageKeyError, new object[] { key, type.FullName });
						}
					}
				}
			}
		}

		public struct AddressGeocodingService
		{
			public struct AddressGeocoder
			{
				public readonly static Message AddressGeocoderError;

				static AddressGeocoder()
				{
					LogMessages.AddressGeocodingService.AddressGeocoder.AddressGeocoderError = new Message(5010101, "Error during address geocodig.");
				}
			}
		}

		public struct BcsAdmin
		{
			public struct Components
			{
				public readonly static Message PhoneDisconnected;

				public readonly static Message PhoneDeleted;

				public readonly static Message ResizeImageError;

				public readonly static Message CroppingImageError;

				public readonly static Message EnqueueImageError;

				public readonly static Message EnqueueImageDebug;

				public readonly static Message ImageConsumedDebug;

				public readonly static Message ImageProcessingConsumingFailed;

				static Components()
				{
					LogMessages.BcsAdmin.Components.PhoneDisconnected = new Message(1010101, "Disconnected Phone of the PhoneId: {0}, CommunityId: {1}, TargetNumber: {2}, DisplayNumber: {3}.");
					LogMessages.BcsAdmin.Components.PhoneDeleted = new Message(1010102, "Deleted Phone of the PhoneId: {0}, CommunityId: {1}, TargetNumber: {2}, DisplayNumber: {3}.");
					LogMessages.BcsAdmin.Components.ResizeImageError = new Message(1010103, "Error during image resize and saving.");
					LogMessages.BcsAdmin.Components.CroppingImageError = new Message(1010104, "Error during image cropping and saving.");
					LogMessages.BcsAdmin.Components.EnqueueImageError = new Message(1010105, "Unable to enqueue image for processing.");
					LogMessages.BcsAdmin.Components.EnqueueImageDebug = new Message(1010106, "Image was added to processing queue. Image name: {0}; Task id: {1}.");
					LogMessages.BcsAdmin.Components.ImageConsumedDebug = new Message(1010107, "Image was consumed by service. Task id: {0}");
					LogMessages.BcsAdmin.Components.ImageProcessingConsumingFailed = new Message(1010108, "Task {0} consuming failed.");
				}
			}
		}

		public struct CallTrackingPhoneScheduler
		{
			public struct Program
			{
				public readonly static Message StartCallTrackingScheduler;

				public readonly static Message CallTrackingSchedulerExecutionError;

				public readonly static Message EndCallTrackingScheduler;

				static Program()
				{
					LogMessages.CallTrackingPhoneScheduler.Program.StartCallTrackingScheduler = new Message(8010101, "Starting of Call Tracking Phone Scheduler...");
					LogMessages.CallTrackingPhoneScheduler.Program.CallTrackingSchedulerExecutionError = new Message(8010102, "Error During Call Tracking Phone Scheduler Execution.");
					LogMessages.CallTrackingPhoneScheduler.Program.EndCallTrackingScheduler = new Message(8010103, "Ending of Call Tracking Phone Scheduler...");
				}
			}
		}

		public struct Configuration
		{
			public struct ConfigurationManager
			{
				public readonly static Message ValueNotFound;

				public readonly static Message IncorrectResolutionValue;

				public readonly static Message SectionNotFound;

				static ConfigurationManager()
				{
					LogMessages.Configuration.ConfigurationManager.ValueNotFound = new Message(2010101, "Value '{0}' has not been found in config file.");
					LogMessages.Configuration.ConfigurationManager.IncorrectResolutionValue = new Message(2010102, "Incorrect resolution value '{0}' in config file.");
					LogMessages.Configuration.ConfigurationManager.SectionNotFound = new Message(2010103, "Section '{0}' has not been found in config file.");
				}
			}
		}

		public struct FileSystemCleaner
		{
			public struct Cleaner
			{
				public readonly static Message CleaningError;

				public readonly static Message StartTempImagesCleaning;

				public readonly static Message FinishTempImagesCleaning;

				public readonly static Message StartLogsCleaning;

				public readonly static Message FinishLogsCleaning;

				public readonly static Message StartRemovingInactiveImages;

				public readonly static Message RemovingFileError;

				public readonly static Message FinishRemovingInactiveImages;

				public readonly static Message StartCleaningImages;

				public readonly static Message MovingImageFileError;

				public readonly static Message FinishCleaningImages;

				public readonly static Message StartCleaning;

				public readonly static Message MissingLogsDirectoryError;

				public readonly static Message RemovingLogFileError;

				public readonly static Message FinishCleaning;

				public readonly static Message CleaningFolderError;

				static Cleaner()
				{
					LogMessages.FileSystemCleaner.Cleaner.CleaningError = new Message(8020101, "Error cleaning.");
					LogMessages.FileSystemCleaner.Cleaner.StartTempImagesCleaning = new Message(8020102, "Start cleaning temp images folder.");
					LogMessages.FileSystemCleaner.Cleaner.FinishTempImagesCleaning = new Message(8020103, "Finish cleaning temp images folder.");
					LogMessages.FileSystemCleaner.Cleaner.StartLogsCleaning = new Message(8020104, "Start logs cleaning.");
					LogMessages.FileSystemCleaner.Cleaner.FinishLogsCleaning = new Message(8020105, "Finish logs cleaning.");
					LogMessages.FileSystemCleaner.Cleaner.StartRemovingInactiveImages = new Message(8020106, "Start removing inactive images.");
					LogMessages.FileSystemCleaner.Cleaner.RemovingFileError = new Message(8020107, "Error removing file {0}.");
					LogMessages.FileSystemCleaner.Cleaner.FinishRemovingInactiveImages = new Message(8020108, "Finish removing inactive images. Moved {0} files. Marked as deleted {1} files.");
					LogMessages.FileSystemCleaner.Cleaner.StartCleaningImages = new Message(8020109, "Start cleaning images.");
					LogMessages.FileSystemCleaner.Cleaner.MovingImageFileError = new Message(8020110, "Error moving image file: {0}.");
					LogMessages.FileSystemCleaner.Cleaner.FinishCleaningImages = new Message(8020111, "Finish cleaning images. Images for removing {0}. Move to temp folder {1} files.");
					LogMessages.FileSystemCleaner.Cleaner.StartCleaning = new Message(8020112, "Start cleaning {0}.");
					LogMessages.FileSystemCleaner.Cleaner.MissingLogsDirectoryError = new Message(8020113, "Missing logs directory: {0}.");
					LogMessages.FileSystemCleaner.Cleaner.RemovingLogFileError = new Message(8020114, "Error removing log file: {0}.");
					LogMessages.FileSystemCleaner.Cleaner.FinishCleaning = new Message(8020115, "Finish cleaning {0}. Founded {1} files. Removed {2} files.");
					LogMessages.FileSystemCleaner.Cleaner.CleaningFolderError = new Message(8020116, "Error cleaning {0} folder.");
				}
			}

			public struct Database
			{
				public readonly static Message DatabaseUpdatingError;

				public readonly static Message StartGettingImageInfo;

				public readonly static Message DataFetchError;

				public readonly static Message FindFiles;

				public readonly static Message FinishGettingImageInfo;

				static Database()
				{
					LogMessages.FileSystemCleaner.Database.DatabaseUpdatingError = new Message(8020201, "Error database updating.");
					LogMessages.FileSystemCleaner.Database.StartGettingImageInfo = new Message(8020202, "Start getting image info.");
					LogMessages.FileSystemCleaner.Database.DataFetchError = new Message(8020203, "Error data fetch.");
					LogMessages.FileSystemCleaner.Database.FindFiles = new Message(8020204, "Find {0} files.");
					LogMessages.FileSystemCleaner.Database.FinishGettingImageInfo = new Message(8020205, "Finish getting image info.");
				}
			}

			public struct Program
			{
				public readonly static Message StartProcessing;

				public readonly static Message FinishProcessing;

				static Program()
				{
					LogMessages.FileSystemCleaner.Program.StartProcessing = new Message(8020301, "Start processing.");
					LogMessages.FileSystemCleaner.Program.FinishProcessing = new Message(8020302, "Finish processing.");
				}
			}
		}

		public struct ImageProcessing
		{
			public struct Core
			{
				public readonly static Message UnableProcessImageError;

				public readonly static Message UnableUpdateImageError;

				public readonly static Message UnableOptimizeImageError;

				public readonly static Message StartProcessingDebug;

				public readonly static Message FinishProcessingDebug;

				public readonly static Message StartImageUpdatingDebug;

				public readonly static Message FinishImageUpdatingDebug;

				public readonly static Message StartBackupDebug;

				public readonly static Message FinishBackupDebug;

				public readonly static Message StartLargeDebug;

				public readonly static Message FinishLargeDebug;

				public readonly static Message StartThumbnailDebug;

				public readonly static Message FinishThumbnailDebug;

				public readonly static Message StartOptimizationDebug;

				public readonly static Message FinishOptimizationDebug;

				static Core()
				{
					LogMessages.ImageProcessing.Core.UnableProcessImageError = new Message(6010101, "Unable to process image.");
					LogMessages.ImageProcessing.Core.UnableUpdateImageError = new Message(6010102, "Unable to update image.");
					LogMessages.ImageProcessing.Core.UnableOptimizeImageError = new Message(6010103, "Unable to optimize image ({0}).");
					LogMessages.ImageProcessing.Core.StartProcessingDebug = new Message(6010104, "Start processing image: {0}");
					LogMessages.ImageProcessing.Core.FinishProcessingDebug = new Message(6010105, "Finish processing image: {0}");
					LogMessages.ImageProcessing.Core.StartImageUpdatingDebug = new Message(6010106, "Start image updating: {0}");
					LogMessages.ImageProcessing.Core.FinishImageUpdatingDebug = new Message(6010107, "Finish image updating: {0}");
					LogMessages.ImageProcessing.Core.StartBackupDebug = new Message(6010108, "Start backup image creating: {0}");
					LogMessages.ImageProcessing.Core.FinishBackupDebug = new Message(6010109, "Finish backup image creating: {0}");
					LogMessages.ImageProcessing.Core.StartLargeDebug = new Message(6010110, "Start large image creating: {0}");
					LogMessages.ImageProcessing.Core.FinishLargeDebug = new Message(6010111, "Finish large image creating: {0}");
					LogMessages.ImageProcessing.Core.StartThumbnailDebug = new Message(6010112, "Start thumbnail image creating: {0}");
					LogMessages.ImageProcessing.Core.FinishThumbnailDebug = new Message(6010112, "Finish thumbnail image creating: {0}");
					LogMessages.ImageProcessing.Core.StartOptimizationDebug = new Message(6010114, "Start image optimization: {0}");
					LogMessages.ImageProcessing.Core.FinishOptimizationDebug = new Message(6010115, "Finish image optimization: {0}");
				}
			}

			public struct ProcessingService
			{
				public readonly static Message StartEventOccured;

				public readonly static Message UnableStartListenError;

				public readonly static Message QueueListeningStarted;

				public readonly static Message StopEventOccured;

				public readonly static Message QueueListeningStopped;

				public readonly static Message ShutdownEventOccured;

				public readonly static Message Error;

				static ProcessingService()
				{
					LogMessages.ImageProcessing.ProcessingService.StartEventOccured = new Message(6010201, "Service start event occured.");
					LogMessages.ImageProcessing.ProcessingService.UnableStartListenError = new Message(6010202, "Unable to start listen.");
					LogMessages.ImageProcessing.ProcessingService.QueueListeningStarted = new Message(6010203, "Queue listening started.");
					LogMessages.ImageProcessing.ProcessingService.StopEventOccured = new Message(6010204, "Service stop event occured.");
					LogMessages.ImageProcessing.ProcessingService.QueueListeningStopped = new Message(6010205, "Queue listening stopped.");
					LogMessages.ImageProcessing.ProcessingService.ShutdownEventOccured = new Message(6010206, "System shutdown event occured.");
					LogMessages.ImageProcessing.ProcessingService.Error = new Message(6010207, "Error occured.");
				}
			}
		}

		public struct Localization
		{
			public struct LocalizationExtensions
			{
				public readonly static Message RetrievingKeyValueException;

				static LocalizationExtensions()
				{
					LogMessages.Localization.LocalizationExtensions.RetrievingKeyValueException = new Message(2020101, "Exception during retrieving '{0}' key value from resources.");
				}
			}
		}

		private struct Logging
		{
			public struct Messages
			{
				public readonly static Message DuplicateMessageKeyError;

				static Messages()
				{
					LogMessages.Logging.Messages.DuplicateMessageKeyError = new Message(2030101, "Log Messages: Duplicate '{0}' message key. Location: '{1}'.");
				}
			}
		}

		public struct MarchexService
		{
			public struct MarchexBc
			{
				public readonly static Message CommonCallTrackingError;

				public readonly static Message CommonCommunityError;

				public readonly static Message CommonServiceProviderError;

				public readonly static Message CommunityAccountCreateError;

				public readonly static Message ServiceProviderAccountCreateError;

				public readonly static Message CreateCampaignError;

				public readonly static Message UpdateCampaignError;

				static MarchexBc()
				{
					LogMessages.MarchexService.MarchexBc.CommonCallTrackingError = new Message(5020101, "Marchex service client. Common error for callTrackingPhoneId: '{0}';");
					LogMessages.MarchexService.MarchexBc.CommonCommunityError = new Message(5020102, "Marchex service client. Common error for communityId: '{0}'.");
					LogMessages.MarchexService.MarchexBc.CommonServiceProviderError = new Message(5020103, "Marchex service client. Common error for serviceProviderId: '{0}'.");
					LogMessages.MarchexService.MarchexBc.CommunityAccountCreateError = new Message(5020104, "Marchex service client. Unable to create Marchex account for communityId: '{0}'.");
					LogMessages.MarchexService.MarchexBc.ServiceProviderAccountCreateError = new Message(5020105, "Marchex service client. Unable to create Marchex account for serviceProviderId: '{0}'.");
					LogMessages.MarchexService.MarchexBc.CreateCampaignError = new Message(5020106, "Marchex service client. Unable to create campaign for listing id: '{0}'; callTrackingPhoneId: '{1}'.");
					LogMessages.MarchexService.MarchexBc.UpdateCampaignError = new Message(5020107, "Marchex service client. Unable to update campaign for listing id: '{0}'; callTrackingPhoneId: '{1}'.");
				}
			}
		}

		public struct MvcUi
		{
			public struct Controllers
			{
				public readonly static Message LeadProcessingError;

				static Controllers()
				{
					LogMessages.MvcUi.Controllers.LeadProcessingError = new Message(4010101, "Lead processing error.");
				}
			}

			public struct GlobalAsax
			{
				public readonly static Message WebApplicationError;

				static GlobalAsax()
				{
					LogMessages.MvcUi.GlobalAsax.WebApplicationError = new Message(4010201, "Web application error.");
				}
			}
		}

		public struct MvcUipc
		{
			public struct Legacy
			{
				public readonly static Message ImageProcessingError;

				static Legacy()
				{
					LogMessages.MvcUipc.Legacy.ImageProcessingError = new Message(4020101, "Error during image processing for '{0}' URL.");
				}
			}
		}

		public struct MvcUipcClient
		{
			public struct Custom
			{
				public readonly static Message ServerExceptionError;

				public readonly static Message UrlProcessingError;

				static Custom()
				{
					LogMessages.MvcUipcClient.Custom.ServerExceptionError = new Message(4030101, "Server exception.");
					LogMessages.MvcUipcClient.Custom.UrlProcessingError = new Message(4030102, "Url processing error.");
				}
			}

			public struct ViewModelsProviders
			{
				public readonly static Message LeadProcessingError;

				public readonly static Message UnableSaveCustomerCookieError;

				static ViewModelsProviders()
				{
					LogMessages.MvcUipcClient.ViewModelsProviders.LeadProcessingError = new Message(4030201, "Lead processing error.");
					LogMessages.MvcUipcClient.ViewModelsProviders.UnableSaveCustomerCookieError = new Message(4030202, "Unable to save customer info cookie.");
				}
			}
		}

		public struct SitemapCore
		{
			public struct MslcSitemapBuilder
			{
				public readonly static Message SitemapGenerationStarted;

				public readonly static Message SitemapGenerationError;

				public readonly static Message SitemapGenerationCompleted;

				public readonly static Message StateUrlsAdded;

				public readonly static Message CityUrlsAdded;

				public readonly static Message CommunityUrlsAdded;

				public readonly static Message ServiceUrlsAdded;

				public readonly static Message UrlsAdded;

				static MslcSitemapBuilder()
				{
					LogMessages.SitemapCore.MslcSitemapBuilder.SitemapGenerationStarted = new Message(7010101, "Sitemap generation started.");
					LogMessages.SitemapCore.MslcSitemapBuilder.SitemapGenerationError = new Message(7010102, "Error during sitemap generation.");
					LogMessages.SitemapCore.MslcSitemapBuilder.SitemapGenerationCompleted = new Message(7010103, "Sitemap generation completed. '{0}' urls added.");
					LogMessages.SitemapCore.MslcSitemapBuilder.StateUrlsAdded = new Message(7010104, "State urls added. State urls count: '{0}'; Total urls count: '{1}'.");
					LogMessages.SitemapCore.MslcSitemapBuilder.CityUrlsAdded = new Message(7010105, "City urls added. City urls count: '{0}'; Total urls count: '{1}'.");
					LogMessages.SitemapCore.MslcSitemapBuilder.CommunityUrlsAdded = new Message(7010106, "Community urls added. Community urls count: '{0}'; Total urls count: '{1}'.");
					LogMessages.SitemapCore.MslcSitemapBuilder.ServiceUrlsAdded = new Message(7010107, "Service urls added. Service urls count: '{0}'; Total urls count: '{1}'.");
					LogMessages.SitemapCore.MslcSitemapBuilder.UrlsAdded = new Message(7010108, "{0} urls added. {1:0.00} MB RAM used.");
				}
			}
		}

		public struct SqlDacs
		{
			public struct Caching
			{
				public readonly static Message ExtractingItemError;

				public readonly static Message InsertItemError;

				public readonly static Message RemoveItemsError;

				public readonly static Message CacheClearedSuccessfully;

				public readonly static Message CacheClearingError;

				public readonly static Message KeyLockingError;

				public readonly static Message KeyUnlockingError;

				public readonly static Message DeepCloningError;

				static Caching()
				{
					LogMessages.SqlDacs.Caching.ExtractingItemError = new Message(3010101, "MSLC CACHE: Error during extracting item with '{0}' key from cache.");
					LogMessages.SqlDacs.Caching.InsertItemError = new Message(3010102, "MSLC CACHE: Error during insert item with '{0}' key to cache.");
					LogMessages.SqlDacs.Caching.RemoveItemsError = new Message(3010103, "MSLC CACHE: Error during remove items with '{0}' prefixes from cache.");
					LogMessages.SqlDacs.Caching.CacheClearedSuccessfully = new Message(3010104, "MSLC CACHE: Token: '{0}'. Local cache has been cleared successfully.");
					LogMessages.SqlDacs.Caching.CacheClearingError = new Message(3010105, "MSLC CACHE: Token: '{0}'. Error during cache clearing.");
					LogMessages.SqlDacs.Caching.KeyLockingError = new Message(3010106, "MSLC CACHE: Error during '{0}' cache key locking.");
					LogMessages.SqlDacs.Caching.KeyUnlockingError = new Message(3010107, "MSLC CACHE: Error during '{0}' cache key unlocking.");
					LogMessages.SqlDacs.Caching.DeepCloningError = new Message(3010108, "MSLC CACHE: Error during a deep cloning of a cache item.");
				}
			}

			public struct SqlCommands
			{
				public readonly static Message CommandExecutionError;

				public readonly static Message CacheDependencyNotFound;

				public readonly static Message FreeCacheDependencyNotFound;

				static SqlCommands()
				{
					LogMessages.SqlDacs.SqlCommands.CommandExecutionError = new Message(3010201, "Error during sql command execution.");
					LogMessages.SqlDacs.SqlCommands.CacheDependencyNotFound = new Message(3010202, "MSLC CACHE: Cached data dependency map for '{0}' stored procedure was not found. Command result was not put to the cache.");
					LogMessages.SqlDacs.SqlCommands.FreeCacheDependencyNotFound = new Message(3010203, "MSLC CACHE: Free cache dependency map was not found for '{0}' stored procedure. Dependent data was not removed directly.");
				}
			}
		}

		public struct Utilities
		{
			public struct AesCryptoService
			{
				public readonly static Message NullEmptyEncryptionString;

				public readonly static Message StringEncryptionError;

				public readonly static Message NullEmptyDecryptionString;

				public readonly static Message StringDecryptionError;

				static AesCryptoService()
				{
					LogMessages.Utilities.AesCryptoService.NullEmptyEncryptionString = new Message(8030101, "AES CRYPTO SERVICE: String for encryption is null or empty. Encrypted value was set to NULL.");
					LogMessages.Utilities.AesCryptoService.StringEncryptionError = new Message(8030102, "AES CRYPTO SERVICE: Error during '{0}' string encryption.");
					LogMessages.Utilities.AesCryptoService.NullEmptyDecryptionString = new Message(8030103, "AES CRYPTO SERVICE: String for decryption is null or empty. Decrypted value was set to NULL.");
					LogMessages.Utilities.AesCryptoService.StringDecryptionError = new Message(8030104, "AES CRYPTO SERVICE: Error during '{0}' string decryption.");
				}
			}

			public struct JsonSerializer
			{
				public readonly static Message ObjectSerializationError;

				public readonly static Message ObjectDeserializationError;

				static JsonSerializer()
				{
					LogMessages.Utilities.JsonSerializer.ObjectSerializationError = new Message(8030201, "Error during '{0}' object serialization. Object data: '{1}'.");
					LogMessages.Utilities.JsonSerializer.ObjectDeserializationError = new Message(8030202, "Error during '{0}' object deserialization. Json string: '{1}'.");
				}
			}
		}

		public struct UtilitiesExternalImgDownloader
		{
			public struct Core
			{
				public readonly static Message SqlCommandExecutionError;

				public readonly static Message StartDownloadingImage;

				public readonly static Message DownloadCompleted;

				public readonly static Message RestoringImageExtension;

				public readonly static Message RenamingFileInfo;

				public readonly static Message GetImageExtensionProblem;

				public readonly static Message ProcessingImageError;

				public readonly static Message DeleteFileAttempt;

				public readonly static Message DeleteSucceed;

				public readonly static Message DeleteFailedError;

				static Core()
				{
					LogMessages.UtilitiesExternalImgDownloader.Core.SqlCommandExecutionError = new Message(8050101, "Error during sql command execution.");
					LogMessages.UtilitiesExternalImgDownloader.Core.StartDownloadingImage = new Message(8050102, "Start downloading image from \"{0}\" url to \"{1}\" file.");
					LogMessages.UtilitiesExternalImgDownloader.Core.DownloadCompleted = new Message(8050103, "Download completed.");
					LogMessages.UtilitiesExternalImgDownloader.Core.RestoringImageExtension = new Message(8050104, "Restoring image extension from \"{0}\" content type.");
					LogMessages.UtilitiesExternalImgDownloader.Core.RenamingFileInfo = new Message(8050105, "Image extension is \"{0}\", renaming file from \"{1}\" to \"{2}\".");
					LogMessages.UtilitiesExternalImgDownloader.Core.GetImageExtensionProblem = new Message(8050106, "Can't get image extension, file not supposed to be image. Deleting downloaded \"{0}\" file.");
					LogMessages.UtilitiesExternalImgDownloader.Core.ProcessingImageError = new Message(8050107, "Error during processing image from \"{0}\" url.");
					LogMessages.UtilitiesExternalImgDownloader.Core.DeleteFileAttempt = new Message(8050108, "Trying to delete downloaded \"{0}\" file.");
					LogMessages.UtilitiesExternalImgDownloader.Core.DeleteSucceed = new Message(8050109, "Delete succeed.");
					LogMessages.UtilitiesExternalImgDownloader.Core.DeleteFailedError = new Message(8050110, "Delete failed.");
				}
			}

			public struct DownloadManager
			{
				public readonly static Message ImagesDirectoryAccessError;

				public readonly static Message GettingImagesInfo;

				public readonly static Message ImagesInfoRetrieved;

				public readonly static Message StartProcessingImage;

				public readonly static Message ProcessingImageCompleted;

				public readonly static Message ProcessingImageCompletedWithIssues;

				public readonly static Message StartUpdatingImages;

				public readonly static Message UpdatingImagesCompleted;

				public readonly static Message ProcessingImagesCompleted;

				public readonly static Message UpdatingImagesCompletedWithIssues;

				public readonly static Message UploadedFileSuccessfullyDeleted;

				public readonly static Message FileDeletingError;

				static DownloadManager()
				{
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.ImagesDirectoryAccessError = new Message(8050201, "Target images directory \"{0}\" does not exist or inaccessible.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.GettingImagesInfo = new Message(8050202, "Getting images info from database.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.ImagesInfoRetrieved = new Message(8050203, "Images info retrieved, count to download is \"{0}\".");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.StartProcessingImage = new Message(8050204, "Start processing image with \"{0}\" Id from \"{1}\" url.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.ProcessingImageCompleted = new Message(8050205, "Processing image from \"{0}\" url completed.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.ProcessingImageCompletedWithIssues = new Message(8050206, "Processing image from \"{0}\" url completed with issues.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.StartUpdatingImages = new Message(8050207, "Start updating images info in database.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.UpdatingImagesCompleted = new Message(8050208, "Updating images info in database completed.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.ProcessingImagesCompleted = new Message(8050209, "Processing images completed. Totally processed \"{0}\" images: \"{1}\" - successfully; \"{2}\" - failed.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.UpdatingImagesCompletedWithIssues = new Message(8050210, "Updating images info in database completed with issues, trying to delete all uploaded files because of error.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.UploadedFileSuccessfullyDeleted = new Message(8050211, "Uploaded file \"{0}\" successfully deleted from \"{1}\" path.");
					LogMessages.UtilitiesExternalImgDownloader.DownloadManager.FileDeletingError = new Message(8050212, "Error during \"{0}\" file deleting from \"{1}\" path.");
				}
			}

			public struct Program
			{
				public readonly static Message StartDownloadingProcess;

				public readonly static Message StartDownloadingCommunityImages;

				public readonly static Message DownloadingCommunityImagesCompleted;

				public readonly static Message StartDownloadingServiceImages;

				public readonly static Message DownloadingServiceImagesCompleted;

				public readonly static Message DownloadingProcessCompleted;

				static Program()
				{
					LogMessages.UtilitiesExternalImgDownloader.Program.StartDownloadingProcess = new Message(8050301, "Start downloading process.");
					LogMessages.UtilitiesExternalImgDownloader.Program.StartDownloadingCommunityImages = new Message(8050302, "Start downloading community images.");
					LogMessages.UtilitiesExternalImgDownloader.Program.DownloadingCommunityImagesCompleted = new Message(8050303, "Downloading community images completed.");
					LogMessages.UtilitiesExternalImgDownloader.Program.StartDownloadingServiceImages = new Message(8050304, "Start downloading service images.");
					LogMessages.UtilitiesExternalImgDownloader.Program.DownloadingServiceImagesCompleted = new Message(8050305, "Downloading service images completed.");
					LogMessages.UtilitiesExternalImgDownloader.Program.DownloadingProcessCompleted = new Message(8050306, "Downloading process completed.");
				}
			}
		}

		public struct UtilitiesImageMigration
		{
			public struct Program
			{
				public readonly static Message SqlError;

				static Program()
				{
					LogMessages.UtilitiesImageMigration.Program.SqlError = new Message(8060101, "Error during sql command execution.");
				}
			}
		}

		public struct UtilitiesImageProcessing
		{
			public struct ImageProcessor
			{
				public readonly static Message ImageSavingError;

				static ImageProcessor()
				{
					LogMessages.UtilitiesImageProcessing.ImageProcessor.ImageSavingError = new Message(8040101, "Error during image saving.");
				}
			}
		}
	}
}