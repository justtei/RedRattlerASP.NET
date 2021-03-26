using MSLivingChoices.Configuration;
using MSLivingChoices.Entities.Client;
using MSLivingChoices.Entities.Client.Enums;
using MSLivingChoices.Mvc.Uipc.Client.CompetitiveFormatters.OptionsResolver;
using MSLivingChoices.Mvc.Uipc.Client.Helpers;
using MSLivingChoices.Mvc.Uipc.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.MappingExtentions
{
	internal static class CommonExtensions
	{
		internal static PagingVm MapToPagingVm(this ServiceProvidersSearchVm searchVm)
		{
			PagingVm pagingVm = MapToCommonPagingVm(searchVm);
			foreach (PageLinkVm page in pagingVm.Pages)
			{
				page.Href = MslcUrlBuilder.PagingUrl(searchVm, page.PageNumber);
			}
			return pagingVm;
		}

		internal static PagingVm MapToPagingVm(this CommunitiesSearchVm searchVm)
		{
			PagingVm pagingVm = MapToCommonPagingVm(searchVm);
			foreach (PageLinkVm page in pagingVm.Pages)
			{
				page.Href = MslcUrlBuilder.PagingUrl(searchVm, page.PageNumber);
			}
			return pagingVm;
		}

		internal static ImageVm MapToImageVm(this Image image, ImageOwner owner, string alt)
		{
			ImageVm imageVm = new ImageVm();
			if (image != null)
			{
				imageVm.Src = image.Url;
				imageVm.ThumbnailSrc = image.ThumbnailUrl;
			}
			imageVm.Alt = alt;
			imageVm.Owner = owner;
			return imageVm;
		}

		internal static AddressVm MapToAddressVm(this Address address)
		{
			return new AddressVm
			{
				CountryCode = address.CountryCode,
				Line = address.Line,
				StateCode = address.StateCode,
				City = address.City,
				Zip = address.Zip,
				Latitude = address.Latitude,
				Longitude = address.Longitude
			};
		}

		internal static CouponVm MapToCouponVm(this Coupon coupon, string printUrl)
		{
			CouponVm couponVm = null;
			if ((coupon != null && coupon.ExpirationDate.HasValue && coupon.ExpirationDate.Value > DateTime.Now) || (coupon != null && !coupon.ExpirationDate.HasValue))
			{
				couponVm = new CouponVm();
				couponVm.Title = coupon.Title;
				couponVm.Description = coupon.Description;
				couponVm.ExpirationDate = (coupon.ExpirationDate.HasValue ? coupon.ExpirationDate.Value.ToString(ConfigurationManager.Instance.CouponDateFormat, CultureInfo.InvariantCulture) : string.Empty);
				couponVm.PrintUrl = printUrl;
			}
			return couponVm;
		}

		internal static OwnerVm MapToOwnerVm(this Owner owner, int package)
		{
			OwnerVm ownerVm = null;
			if (owner != null)
			{
				ownerVm = new OwnerVm();
				ownerVm.Name = owner.Name;
				ownerVm.Phone = owner.Phone;
				ownerVm.WebsiteUrl = owner.WebsiteUrl;
				ownerVm.Logo = MapToImageVm(owner.Logo, ImageOwner.Owner, $"{ownerVm.Name} Logo");
				ownerVm.Address = ((owner.Address != null) ? MapToAddressVm(owner.Address) : null);
				ownerVm.DisplayProperties = new OwnerDisplayProperties(owner.DisplayOptions);
				ownerVm.Package = package;
			}
			return ownerVm;
		}

		internal static Customer ToCustomer(this CustomerInfoVm customerInfo)
		{
			return new Customer
			{
				Name = customerInfo.Name,
				Email = customerInfo.Email,
				Phone = customerInfo.Phone
			};
		}

		private static PagingVm MapToCommonPagingVm<TResult, TSort>(this ResultSetSearchVm<TResult, TSort> result)
		{
			PagingVm pagingVm = new PagingVm();
			pagingVm.CurrentPage = result.PageNumber;
			pagingVm.PageSize = ConfigurationManager.Instance.DefaultPageSize;
			pagingVm.TotalCount = result.TotalCount;
			if (result.TotalCount > result.PageSize && pagingVm.CurrentPage <= pagingVm.TotalPages)
			{
				if (pagingVm.CurrentPage != 1)
				{
					pagingVm.Pages.Add(new PageLinkVm
					{
						Css = "first",
						PageNumber = 1
					});
					pagingVm.Pages.Add(new PageLinkVm
					{
						Css = "prev",
						PageNumber = ((pagingVm.CurrentPage <= 1) ? 1 : (pagingVm.CurrentPage - 1))
					});
				}
				int num = ((pagingVm.TotalPages > pagingVm.TotalDisplay) ? pagingVm.TotalDisplay : pagingVm.TotalPages);
				int num2 = ((pagingVm.CurrentPage <= pagingVm.TotalDisplay - pagingVm.DisplayVector || pagingVm.TotalPages <= pagingVm.TotalDisplay) ? 1 : ((pagingVm.CurrentPage < pagingVm.TotalPages - pagingVm.DisplayVector) ? (pagingVm.CurrentPage - pagingVm.DisplayVector) : (pagingVm.TotalPages - pagingVm.TotalDisplay + 1)));
				for (int i = 0; i < num; i++)
				{
					int num3 = i + num2;
					pagingVm.Pages.Add(new PageLinkVm
					{
						InnerText = num3.ToString(CultureInfo.InvariantCulture),
						PageNumber = num3,
						Css = ((num3 == pagingVm.CurrentPage) ? "active" : null)
					});
				}
				if (pagingVm.CurrentPage != pagingVm.TotalPages)
				{
					pagingVm.Pages.Add(new PageLinkVm
					{
						Css = "next",
						PageNumber = ((pagingVm.CurrentPage < pagingVm.TotalPages) ? (pagingVm.CurrentPage + 1) : pagingVm.TotalPages)
					});
					pagingVm.Pages.Add(new PageLinkVm
					{
						Css = "last",
						PageNumber = pagingVm.TotalPages
					});
				}
			}
			return pagingVm;
		}
	}

}