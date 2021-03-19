using EasyNetQ;
using MSLivingChoices.Bcs.Admin;
using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.Logging;
using MSLivingChoices.Logging.Messages;
using MSLivingChoices.Utilities.ImageProcessing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSLivingChoices.Bcs.Admin.Components
{
	public class ImageBc
	{
		private static ImageBc _imageBc;

		private readonly IBus _queueBus;

		private readonly IProcessingDac _processingDac;

		private readonly static object Locker;

		public static ImageBc Instance
		{
			get
			{
				if (ImageBc._imageBc == null)
				{
					lock (ImageBc.Locker)
					{
						if (ImageBc._imageBc == null)
						{
							ImageBc._imageBc = new ImageBc();
						}
					}
				}
				return ImageBc._imageBc;
			}
		}

		static ImageBc()
		{
			ImageBc.Locker = new object();
		}

		private ImageBc()
		{
			this._queueBus = RabbitHutch.CreateBus(ConfigurationManager.Instance.ImageQueueConnectionString);
			this._processingDac = AdminDacFactoryClient.GetConcreteFactory().GetProcessingDac();
		}

		public static Image CropAndSave(byte[] image, int x, int y, int width, int height)
		{
			Image image1;
			try
			{
				image1 = ImageProcessor.Crop(image, x, y, width, height);
			}
			catch (Exception exception)
			{
				Logger.Error(LogMessages.BcsAdmin.Components.CroppingImageError, exception);
				image1 = null;
			}
			return image1;
		}

		public void EnqueueImage(Image image)
		{
			Task task = this._queueBus.PublishAsync<Image>(image).ContinueWith(new Action<Task>(ImageBc.HandleResponse));
			Logger.DebugFormat(LogMessages.BcsAdmin.Components.EnqueueImageDebug, new object[] { image.Name, task.Id });
		}

		private static void HandleResponse(Task task)
		{
			if (task.IsCompleted)
			{
				Logger.DebugFormat(LogMessages.BcsAdmin.Components.ImageConsumedDebug, new object[] { task.Id });
			}
			if (task.IsFaulted)
			{
				Logger.ErrorFormat(LogMessages.BcsAdmin.Components.ImageProcessingConsumingFailed, task.Exception, new object[] { task.Id });
			}
		}

		public void ProcessCommunityImages(long communityId)
		{
			this.ProcessImages(this._processingDac.GetUnprocessedCommunityImages(communityId));
		}

		public void ProcessImages(ImageOwner owner, long ownerId)
		{
			this.ProcessImages(this._processingDac.GetUnprocessedImages(owner, ownerId));
		}

		public void ProcessImages(IEnumerable<Image> images)
		{
			foreach (Image image in images)
			{
				try
				{
					this.EnqueueImage(image);
				}
				catch (Exception exception)
				{
					Logger.Error(LogMessages.BcsAdmin.Components.EnqueueImageError, exception);
				}
			}
		}

		public static Image ResizeAndSave(byte[] image, int x, int y, int width, int height)
		{
			Image image1;
			try
			{
				image1 = ImageProcessor.Resize(image, x, y, width, height);
			}
			catch (Exception exception)
			{
				Logger.Error(LogMessages.BcsAdmin.Components.ResizeImageError, exception);
				image1 = null;
			}
			return image1;
		}

		public void UpdateImage(Image image)
		{
			this._processingDac.UpdateImage(image);
		}
	}
}