using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using MSLivingChoices.Mvc.Uipc.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Admin.MappingExtentions
{
	internal static class CommonExtentions
	{
		private static KeyValuePairVm<TK, TV> GetKeyValuePairVm<TK, TV>(TK key, TV value)
		{
			return new KeyValuePairVm<TK, TV>()
			{
				Key = key,
				Value = value
			};
		}

		internal static AddressValidationVm MapToAddressValidationVm(this AddressValidation addressValidation)
		{
			AddressValidationVm result = new AddressValidationVm()
			{
				ValidationItems = new List<AddressValidationItemVm>(),
				SelectedValidationItem = 0,
				AddressId = addressValidation.AddressId,
				IsAddressValid = addressValidation.IsValid
			};
			if (!addressValidation.IsValid)
			{
				for (int i = 0; i <= addressValidation.Condidates.Count - 1; i++)
				{
					AddressValidationItemVm addressValidationItem = new AddressValidationItemVm()
					{
						AddressLine1 = addressValidation.Condidates[i].AddressLine1,
						AddressLine2 = addressValidation.Condidates[i].AddressLine2,
						CityId = addressValidation.Condidates[i].CityId,
						CountryId = addressValidation.Condidates[i].CountryId,
						Id = i,
						Latitude = addressValidation.Condidates[i].Location.Latitude,
						Longitude = addressValidation.Condidates[i].Location.Longitude,
						PostalCode = addressValidation.Condidates[i].PostalCode,
						StateId = addressValidation.Condidates[i].StateId
					};
					result.ValidationItems.Add(addressValidationItem);
				}
			}
			else
			{
				AddressValidationItemVm addressValidationItem = new AddressValidationItemVm()
				{
					AddressLine1 = addressValidation.ValidAddress.AddressLine1,
					AddressLine2 = addressValidation.ValidAddress.AddressLine2,
					CityId = addressValidation.ValidAddress.CityId,
					CountryId = addressValidation.ValidAddress.CountryId,
					Id = 0,
					Latitude = addressValidation.ValidAddress.Location.Latitude,
					Longitude = addressValidation.ValidAddress.Location.Longitude,
					PostalCode = addressValidation.ValidAddress.PostalCode,
					StateId = addressValidation.ValidAddress.StateId
				};
				result.ValidationItems.Add(addressValidationItem);
				result.SelectedLatitude = addressValidation.ValidAddress.Location.Latitude;
				result.SelectedLongitude = addressValidation.ValidAddress.Location.Longitude;
			}
			return result;
		}

		internal static AddressVm MapToAddressVm(this Address address)
		{
			return (new AddressVm()
			{
				Id = address.Id,
				Location = address.Location.MapToLocationVm(),
				StreetAddress = address.StreetAddress,
				Country = address.Country.MapToCountryVm(),
				State = address.State.MapToStateVm(),
				City = address.City.MapToCityVm(),
				PostalCode = address.PostalCode
			}).Repopulate();
		}

		internal static List<AmenityVm> MapToAmenityVmList(this IEnumerable<Amenity> allAmenities, List<Amenity> defaultAmenities)
		{
			List<AmenityVm> customAmenities = new List<AmenityVm>();
			foreach (Amenity allAmenity in allAmenities)
			{
				if (!defaultAmenities.All<Amenity>((Amenity m) => {
					int? classId = m.ClassId;
					int? nullable = allAmenity.ClassId;
					return !(classId.GetValueOrDefault() == nullable.GetValueOrDefault() & classId.HasValue == nullable.HasValue);
				}))
				{
					continue;
				}
				customAmenities.Add(new AmenityVm(allAmenity));
			}
			if (!customAmenities.Any<AmenityVm>())
			{
				customAmenities.Add(new AmenityVm());
			}
			return customAmenities;
		}

		internal static List<CheckBoxVm> MapToCheckBoxVmList(this List<Amenity> allAmenities, IEnumerable<long> chosenAmenities)
		{
			return allAmenities.ConvertAll<CheckBoxVm>((Amenity x) => new CheckBoxVm()
			{
				Value = (x.ClassId.HasValue ? x.ClassId.Value.ToString() : string.Empty),
				Text = x.Name,
				IsChecked = (!x.ClassId.HasValue ? false : chosenAmenities.Any<long>((long m) => m == (long)x.ClassId.Value))
			});
		}

		internal static List<CheckBoxVm> MapToCheckBoxVmList(this IEnumerable<Amenity> allAmenities, List<Amenity> defaultAmenities)
		{
			return defaultAmenities.ConvertAll<CheckBoxVm>((Amenity m) => new CheckBoxVm()
			{
				Value = m.ClassId.ToString(),
				Text = m.Name,
				IsChecked = allAmenities.Any<Amenity>((Amenity amenity) => {
					int? classId = amenity.ClassId;
					int? nullable = m.ClassId;
					return classId.GetValueOrDefault() == nullable.GetValueOrDefault() & classId.HasValue == nullable.HasValue;
				})
			});
		}

		internal static CityVm MapToCityVm(this City city)
		{
			return new CityVm()
			{
				Id = city.Id,
				Name = city.Name
			};
		}

		internal static CountryVm MapToCountryVm(this Country country)
		{
			return new CountryVm()
			{
				Id = country.Id,
				Code = country.Code,
				Name = country.Name
			};
		}

		internal static CouponVm MapToCouponVm(this Coupon coupon)
		{
			if (coupon == null)
			{
				return null;
			}
			return new CouponVm()
			{
				Id = coupon.Id,
				Name = coupon.Name,
				Description = coupon.Description,
				PublishDate = coupon.PublishDate,
				ExpirationDate = coupon.ExpirationDate
			};
		}

		internal static ImageVm MapToImageVm(this Image image)
		{
			ImageVm result = new ImageVm();
			if (image != null)
			{
				result.Id = image.Id;
				result.Name = image.Name;
				result.Url = image.Url;
			}
			return result;
		}

		internal static List<KeyValuePairVm<int, string>> MapToKeyValuePairVm(this List<Amenity> list)
		{
			return list.ConvertAll<KeyValuePairVm<int, string>>((Amenity i) => CommonExtentions.GetKeyValuePairVm<int, string>(i.ClassId.Value, i.Name));
		}

		internal static List<KeyValuePairVm<TK, TV>> MapToKeyValuePairVm<TK, TV>(this List<KeyValuePair<TK, TV>> list)
		{
			return list.ConvertAll<KeyValuePairVm<TK, TV>>((KeyValuePair<TK, TV> i) => CommonExtentions.GetKeyValuePairVm<TK, TV>(i.Key, i.Value));
		}

		internal static LocationVm MapToLocationVm(this Location location)
		{
			double? nullable;
			double? nullable1;
			double? nullable2;
			LocationVm locationVm = new LocationVm();
			if (location.Latitude.CompareTo(0) == 0)
			{
				nullable = null;
				nullable1 = nullable;
			}
			else
			{
				nullable1 = new double?(location.Latitude);
			}
			locationVm.Latitude = nullable1;
			if (location.Longitude.CompareTo(0) == 0)
			{
				nullable = null;
				nullable2 = nullable;
			}
			else
			{
				nullable2 = new double?(location.Longitude);
			}
			locationVm.Longitude = nullable2;
			return locationVm;
		}

		internal static MeasureBoundaryVm<T, M> MapToMeasureBoundaryVm<T, M>(this MeasureBoundary<T, M> measureBoundary)
		where T : struct
		where M : struct
		{
			return new MeasureBoundaryVm<T, M>()
			{
				Min = measureBoundary.Min,
				Max = measureBoundary.Max,
				Measure = measureBoundary.Measure
			};
		}

		internal static List<SearchSelectListItemVm> MapToSearchSelectListItemVmList(this List<Country> list, string selected)
		{
			return (
				from x in list
				select new SearchSelectListItemVm()
				{
					Value = x.Id.ToString(),
					Text = x.Name,
					UrlValue = x.Code.ToLower(),
					Selected = x.Code.Equals(selected)
				}).ToList<SearchSelectListItemVm>();
		}

		internal static List<SearchSelectListItemVm> MapToSearchSelectListItemVmList(this List<State> list, string selected)
		{
			List<SearchSelectListItemVm> result = new List<SearchSelectListItemVm>()
			{
				new SearchSelectListItemVm()
				{
					Text = StaticContent.WtrMrk_SelectState
				}
			};
			if (list != null)
			{
				result.AddRange((
					from x in list
					select new SearchSelectListItemVm()
					{
						Value = x.Id.ToString(),
						Text = x.Name,
						UrlValue = x.Code.ToLower(),
						Selected = x.Code.Equals(selected)
					}).ToList<SearchSelectListItemVm>());
			}
			return result;
		}

		internal static List<SearchSelectListItemVm> MapToSearchSelectListItemVmList(this List<City> list, string selected)
		{
			List<SearchSelectListItemVm> result = new List<SearchSelectListItemVm>()
			{
				new SearchSelectListItemVm()
				{
					Text = StaticContent.WtrMrk_SelectCity
				}
			};
			if (list != null)
			{
				result.AddRange((
					from x in list
					select new SearchSelectListItemVm()
					{
						Value = x.Id.ToString(),
						Text = x.Name,
						UrlValue = x.Name.ToUrlString(),
						Selected = x.Name.Equals(selected)
					}).ToList<SearchSelectListItemVm>());
			}
			return result;
		}

		internal static StateVm MapToStateVm(this State state)
		{
			return new StateVm()
			{
				Id = state.Id,
				Code = state.Code,
				Name = state.Name
			};
		}
	}
}