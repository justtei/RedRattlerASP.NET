using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Bcs.Components;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.Helpers;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModelsProviders;
using MSLivingChoices.Mvc.Uipc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.MappingExtentions
{
	public static class RepopulateExtentions
	{
		public static NewCommunityVm Repopulate(this NewCommunityVm viewModel)
		{
			viewModel.Books = AccountBc.Instance.GetBooks().ToSelectListItemList();
			viewModel.Address = viewModel.Address.Repopulate();
			viewModel.Contacts = viewModel.Contacts.Repopulate(CommunityType.Community);
			viewModel.EmailList = viewModel.EmailList.Repopulate(CommunityType.Community);
			viewModel.PhoneList = viewModel.PhoneList.Repopulate(CommunityType.Community);
			viewModel.PhoneList.AdditionalPhones.ForEach((PhoneVm ph) => ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.get_Text().Contains("Provision")));
			viewModel.CommunityDetails.Repopulate();
			viewModel.ListingDetails.Repopulate();
			return viewModel;
		}

		public static CommunityDetailsVm Repopulate(this CommunityDetailsVm viewModel)
		{
			List<SelectListItem> bedrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBedrooms().ToSelectListItemList();
			List<SelectListItem> bathrooms = MSLivingChoices.Bcs.Components.ItemTypeBc.Instance.GetBathrooms().ToSelectListItemList();
			viewModel.AvailableBathroomsFromQuantity = bathrooms;
			viewModel.AvailableBathroomsToQuantity = bathrooms;
			viewModel.AvailableBedroomsFromQuantity = bedrooms;
			viewModel.AvailableBedroomsToQuantity = bedrooms;
			foreach (FloorPlanVm floorPlan in viewModel.FloorPlans)
			{
				floorPlan.Images = floorPlan.Images ?? new ImageListVm(DisplayNames.FloorPlanImages);
				floorPlan.AvailableBathroomsFromQuantity = bathrooms;
				floorPlan.AvailableBathroomsToQuantity = bathrooms;
				floorPlan.AvailableBedroomsFromQuantity = bedrooms;
				floorPlan.AvailableBedroomsToQuantity = bedrooms;
			}
			foreach (SpecHomeVm specHome in viewModel.SpecHomes)
			{
				specHome.Images = specHome.Images ?? new ImageListVm(DisplayNames.SpecHomeImages);
				specHome.AvailableBathroomsFromQuantity = bathrooms;
				specHome.AvailableBathroomsToQuantity = bathrooms;
				specHome.AvailableBedroomsFromQuantity = bedrooms;
				specHome.AvailableBedroomsToQuantity = bedrooms;
			}
			foreach (HouseVm house in viewModel.Houses)
			{
				house.Images = house.Images ?? new ImageListVm(DisplayNames.HouseImages);
				house.AvailableBathroomsFromQuantity = bathrooms;
				house.AvailableBathroomsToQuantity = bathrooms;
				house.AvailableBedroomsFromQuantity = bedrooms;
				house.AvailableBedroomsToQuantity = bedrooms;
				house.Address = house.Address.Repopulate();
			}
			return viewModel;
		}

		public static ListingDetailsVm Repopulate(this ListingDetailsVm viewModel)
		{
			viewModel.PropertyManager.Owners = OwnerBc.Instance.GetAllByOwnerType(OwnerType.PropertyManager).Select<Owner, SelectListItem>((Owner m) => {
				SelectListItem selectListItem = new SelectListItem();
				selectListItem.set_Value(m.Id.ToString());
				selectListItem.set_Text(m.Name);
				return selectListItem;
			}).ToList<SelectListItem>();
			viewModel.Builder.Owners = OwnerBc.Instance.GetAllByOwnerType(OwnerType.Builder).Select<Owner, SelectListItem>((Owner m) => {
				SelectListItem selectListItem = new SelectListItem();
				selectListItem.set_Value(m.Id.ToString());
				selectListItem.set_Text(m.Name);
				return selectListItem;
			}).ToList<SelectListItem>();
			viewModel.PropertyManager.NewOwner = viewModel.PropertyManager.NewOwner.Repopulate();
			viewModel.Builder.NewOwner = viewModel.Builder.NewOwner.Repopulate();
			return viewModel;
		}

		public static EditCommunityVm Repopulate(this EditCommunityVm viewModel)
		{
			((NewCommunityVm)viewModel).Repopulate();
			return viewModel;
		}

		public static List<ContactVm> Repopulate(this IEnumerable<ContactVm> contacts, CommunityType type)
		{
			List<ContactVm> result;
			if (contacts == null || !contacts.Any<ContactVm>())
			{
				result = new List<ContactVm>()
				{
					AdminViewModelsProvider.GetContactVm(type)
				};
			}
			else
			{
				result = contacts.ToList<ContactVm>();
				List<SelectListItem> contactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(type).ToSelectListItemList();
				foreach (ContactVm contactVm in result)
				{
					contactVm.ContactTypes = contactTypes;
				}
			}
			return result;
		}

		public static List<ContactVm> Repopulate(this IEnumerable<ContactVm> contacts, OwnerType type)
		{
			List<ContactVm> result;
			if (contacts == null || !contacts.Any<ContactVm>())
			{
				result = new List<ContactVm>()
				{
					AdminViewModelsProvider.GetContactVm(type)
				};
			}
			else
			{
				result = contacts.ToList<ContactVm>();
				List<SelectListItem> contactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(type).ToSelectListItemList();
				foreach (ContactVm contactVm in result)
				{
					contactVm.ContactTypes = contactTypes;
				}
			}
			return result;
		}

		public static List<ContactVm> Repopulate(this IEnumerable<ContactVm> contacts, ServiceType serviceType)
		{
			List<ContactVm> result;
			if (contacts == null || !contacts.Any<ContactVm>())
			{
				result = new List<ContactVm>()
				{
					AdminViewModelsProvider.GetContactVm(serviceType)
				};
			}
			else
			{
				result = contacts.ToList<ContactVm>();
				List<SelectListItem> contactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(serviceType).ToSelectListItemList();
				foreach (ContactVm contactVm in result)
				{
					contactVm.ContactTypes = contactTypes;
				}
			}
			return result;
		}

		public static EmailListVm Repopulate(this EmailListVm model, CommunityType type)
		{
			if (model == null)
			{
				return AdminViewModelsProvider.GetEmailListVm(type);
			}
			if (model.AdditionalEmails == null || !model.AdditionalEmails.Any<EmailVm>())
			{
				model.AdditionalEmails = new List<EmailVm>()
				{
					new EmailVm()
				};
			}
			List<SelectListItem> emailTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetEmailTypes(type).ToSelectListItemList();
			foreach (EmailVm additionalEmail in model.AdditionalEmails)
			{
				additionalEmail.EmailTypes = emailTypes;
			}
			return model;
		}

		public static EmailListVm Repopulate(this EmailListVm model, OwnerType type)
		{
			if (model == null)
			{
				return AdminViewModelsProvider.GetEmailListVm(type);
			}
			if (model.AdditionalEmails == null || !model.AdditionalEmails.Any<EmailVm>())
			{
				model.AdditionalEmails = new List<EmailVm>()
				{
					new EmailVm()
				};
			}
			List<SelectListItem> emailTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetEmailTypes(type).ToSelectListItemList();
			foreach (EmailVm additionalEmail in model.AdditionalEmails)
			{
				additionalEmail.EmailTypes = emailTypes;
			}
			return model;
		}

		public static EmailListVm Repopulate(this EmailListVm model, ServiceType serviceType)
		{
			if (model == null)
			{
				return AdminViewModelsProvider.GetEmailListVm(serviceType);
			}
			if (model.AdditionalEmails == null || !model.AdditionalEmails.Any<EmailVm>())
			{
				model.AdditionalEmails = new List<EmailVm>()
				{
					new EmailVm()
				};
			}
			List<SelectListItem> emailTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetEmailTypes(serviceType).ToSelectListItemList();
			foreach (EmailVm additionalEmail in model.AdditionalEmails)
			{
				additionalEmail.EmailTypes = emailTypes;
			}
			return model;
		}

		public static NewOwnerVm Repopulate(this NewOwnerVm viewModel)
		{
			NewOwnerVm result = new NewOwnerVm();
			viewModel.Address = viewModel.Address.Repopulate();
			List<SelectListItem> phoneTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPhoneTypes(viewModel.OwnerType).ToSelectListItemList();
			List<SelectListItem> emailsTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetEmailTypes(viewModel.OwnerType).ToSelectListItemList();
			List<SelectListItem> contactTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetContactTypes(viewModel.OwnerType).ToSelectListItemList();
			foreach (PhoneVm additionalPhone in viewModel.PhoneList.AdditionalPhones)
			{
				additionalPhone.PhoneTypes = phoneTypes;
			}
			foreach (EmailVm additionalEmail in viewModel.EmailList.AdditionalEmails)
			{
				additionalEmail.EmailTypes = emailsTypes;
			}
			foreach (ContactVm contact in viewModel.Contacts)
			{
				contact.ContactTypes = contactTypes;
			}
			viewModel.LogoImages = new ImageListVm(viewModel.OwnerType.MapToDisplayName());
			return result;
		}

		public static PhoneListVm Repopulate(this PhoneListVm model, CommunityType type)
		{
			if (model == null)
			{
				return AdminViewModelsProvider.GetPhoneList(type);
			}
			if (model.AdditionalPhones == null || !model.AdditionalPhones.Any<PhoneVm>())
			{
				model.AdditionalPhones = new List<PhoneVm>()
				{
					new PhoneVm()
				};
			}
			List<SelectListItem> phoneTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPhoneTypes(type).ToSelectListItemList();
			foreach (PhoneVm additionalPhone in model.AdditionalPhones)
			{
				additionalPhone.PhoneTypes = phoneTypes;
			}
			return model;
		}

		public static PhoneListVm Repopulate(this PhoneListVm model, OwnerType type)
		{
			if (model == null)
			{
				return AdminViewModelsProvider.GetPhoneList(type);
			}
			if (model.AdditionalPhones == null || !model.AdditionalPhones.Any<PhoneVm>())
			{
				model.AdditionalPhones = new List<PhoneVm>()
				{
					new PhoneVm()
				};
			}
			List<SelectListItem> phoneTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPhoneTypes(type).ToSelectListItemList();
			foreach (PhoneVm additionalPhone in model.AdditionalPhones)
			{
				additionalPhone.PhoneTypes = phoneTypes;
			}
			return model;
		}

		public static PhoneListVm Repopulate(this PhoneListVm model, ServiceType serviceType)
		{
			if (model == null)
			{
				return AdminViewModelsProvider.GetPhoneList(serviceType);
			}
			if (model.AdditionalPhones == null || !model.AdditionalPhones.Any<PhoneVm>())
			{
				model.AdditionalPhones = new List<PhoneVm>()
				{
					new PhoneVm()
				};
			}
			List<SelectListItem> phoneTypes = MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPhoneTypes(serviceType).ToSelectListItemList();
			foreach (PhoneVm additionalPhone in model.AdditionalPhones)
			{
				additionalPhone.PhoneTypes = phoneTypes;
			}
			return model;
		}

		public static NewServiceProviderVm Repopulate(this NewServiceProviderVm model)
		{
			model.PhoneList = model.PhoneList.Repopulate(ServiceType.ProductsAndServices);
			model.PhoneList.AdditionalPhones.ForEach((PhoneVm ph) => ph.PhoneTypes.RemoveAll((SelectListItem pt) => pt.get_Text().Contains("Provision")));
			model.EmailList = model.EmailList.Repopulate(ServiceType.ProductsAndServices);
			model.Contacts = model.Contacts.Repopulate(ServiceType.ProductsAndServices);
			model.PaymentTypes = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPaymentTypes());
			return model;
		}

		public static EditServiceProviderVm Repopulate(this EditServiceProviderVm model)
		{
			model.PhoneList = model.PhoneList.Repopulate(ServiceType.ProductsAndServices);
			model.EmailList = model.EmailList.Repopulate(ServiceType.ProductsAndServices);
			model.Contacts = model.Contacts.Repopulate(ServiceType.ProductsAndServices);
			model.PaymentTypes = ConverterHelpers.DictionaryToCheckBoxList(MSLivingChoices.Bcs.Admin.Components.ItemTypeBc.Instance.GetPaymentTypes());
			return model;
		}

		public static AddressVm Repopulate(this AddressVm address)
		{
			if (!address.Country.Id.HasValue)
			{
				address.Country.Id = LocationBc.Instance.DefaultCountry.Id;
			}
			List<Country> countries = LocationBc.Instance.GetAllCountries();
			address.Country.AvailableCountries = countries.ConvertAll<SelectListItem>((Country m) => {
				SelectListItem selectListItem = new SelectListItem();
				long? id = m.Id;
				selectListItem.set_Value(id.ToString());
				selectListItem.set_Text(m.Name);
				id = m.Id;
				long? nullable = address.Country.Id;
				selectListItem.set_Selected(id.GetValueOrDefault() == nullable.GetValueOrDefault() & id.HasValue == nullable.HasValue);
				return selectListItem;
			});
			List<State> states = LocationBc.Instance.GetStates(address.Country.Id);
			address.State.AvailableStates = states.ConvertAll<SelectListItem>((State m) => {
				SelectListItem selectListItem = new SelectListItem();
				long? id = m.Id;
				selectListItem.set_Value(id.ToString());
				selectListItem.set_Text(m.Name);
				id = m.Id;
				long? nullable = address.State.Id;
				selectListItem.set_Selected(id.GetValueOrDefault() == nullable.GetValueOrDefault() & id.HasValue == nullable.HasValue);
				return selectListItem;
			});
			if (address.State.Id.HasValue)
			{
				List<City> cities = LocationBc.Instance.GetCities(address.State.Id);
				address.City.AvailableCities = cities.ConvertAll<SelectListItem>((City m) => {
					SelectListItem selectListItem = new SelectListItem();
					long? id = m.Id;
					selectListItem.set_Value(id.ToString());
					selectListItem.set_Text(m.Name);
					id = m.Id;
					long? nullable = address.City.Id;
					selectListItem.set_Selected(id.GetValueOrDefault() == nullable.GetValueOrDefault() & id.HasValue == nullable.HasValue);
					return selectListItem;
				});
			}
			else
			{
				address.City.AvailableCities = new List<SelectListItem>();
			}
			return address;
		}
	}
}