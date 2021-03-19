using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Mvc.Uipc.Admin.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CouponVm
	{
		[AllowHtml]
		[StringLength(200)]
		[UIHint("RichTextEditor")]
		public string Description
		{
			get;
			set;
		}

		public DateTime? ExpirationDate
		{
			get;
			set;
		}

		public bool HasCoupon
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(this.Name) || !string.IsNullOrWhiteSpace(this.Description) || this.PublishDate.HasValue)
				{
					return true;
				}
				return this.ExpirationDate.HasValue;
			}
		}

		public long? Id
		{
			get;
			set;
		}

		[AllowHtml]
		[RequiredOnDemand("HasCoupon")]
		[StringLength(50)]
		public string Name
		{
			get;
			set;
		}

		[DateRange("ExpirationDate")]
		public DateTime? PublishDate
		{
			get;
			set;
		}

		public CouponVm()
		{
		}

		public Coupon ToEntity()
		{
			if (!this.HasCoupon)
			{
				return null;
			}
			return new Coupon()
			{
				Id = this.Id,
				Name = this.Name,
				Description = this.Description,
				PublishDate = this.PublishDate,
				ExpirationDate = this.ExpirationDate
			};
		}
	}
}