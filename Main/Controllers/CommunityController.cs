using MSLivingChoices.Bcs.Admin.Components;
using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.Localization;
using MSLivingChoices.Mvc.Uipc.Admin.Filters;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModelsProviders;
using MSLivingChoices.Mvc.Uipc.Helpers;
using MSLivingChoices.Mvc.Uipc.Legacy;
using MSLivingChoices.Mvc.Uipc.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace Main.Controllers
{
	[Authorize]
	public class CommunityController : BaseController
	{
		public CommunityController()
		{
		}

		public JsonResult ChangeListingTypeState(long communityId, ListingType listingType, bool value)
		{
			CommunityBc.Instance.ChangeListingTypeState(communityId, listingType, value);
			return new AllowedJsonResult()
			{
				Data = new { success = true }
			};
		}

		public JsonResult ChangePackageType(long communityId, PackageType packageType)
		{
			CommunityBc.Instance.ChangePackageType(communityId, packageType);
			return new AllowedJsonResult()
			{
				Data = new { success = true }
			};
		}

		public JsonResult ChangePublishDates(long communityId, DateTime? startDate, DateTime? endDate)
		{
			CommunityBc.Instance.ChangePublishDates(communityId, startDate, endDate);
			return new AllowedJsonResult()
			{
				Data = new { success = true }
			};
		}

		public JsonResult ChangeSeniorHousingAndCareCategories(long communityId, List<long> seniorHousingAndCareCategoryIds)
		{
			CommunityBc.Instance.ChangeSeniorHousingAndCareCategories(communityId, seniorHousingAndCareCategoryIds);
			return new AllowedJsonResult()
			{
				Data = new { success = true }
			};
		}

		public JsonResult ChangeShowcaseDates(long communityId, DateTime? startDate, DateTime? endDate)
		{
			CommunityBc.Instance.ChangeShowcaseDates(communityId, startDate, endDate);
			return new AllowedJsonResult()
			{
				Data = new { success = true }
			};
		}

		public ActionResult Delete(long communityId, int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter)
		{
			CommunityBc.Instance.Delete(communityId);
			CommunityForGridVm community = AdminViewModelsProvider.GetLastCommunityForGrid(pageNumber, pageSize, sortBy, orderBy, filter);
			return new AllowedJsonResult()
			{
				Data = new { success = true, community = community }
			};
		}

		public ActionResult Edit(long id)
		{
			EditCommunityVm editCommunity = AdminViewModelsProvider.GetEditCommunityVm(id);
			if (editCommunity == null)
			{
				return base.NotFound();
			}
			return base.View(editCommunity);
		}

		[EditCommunityPartialValidation]
		[HttpPost]
		public ActionResult Edit(EditCommunityVm editCommunity)
		{
			ActionResult allowGetJsonResult;
			bool flag;
			if (!base.ModelState.IsValid)
			{
				return new AllowGetJsonResult(new { success = false, errors = ModelStateHelper.GetModelStateErrors(base.ModelState) });
			}
			flag = (!editCommunity.Address.Location.Longitude.HasValue ? false : editCommunity.Address.Location.Latitude.HasValue);
			if (editCommunity.AddressValidation.ValidationItems == null && !flag)
			{
				AddressValidationVm addressValidation = AdminViewModelsProvider.GetAddressValidationVm(editCommunity.Address);
				if (!addressValidation.IsAddressValid)
				{
					return new AllowGetJsonResult(new { success = false, addressValidation = addressValidation });
				}
				editCommunity.AddressValidation = addressValidation;
			}
			Community community = editCommunity.ToEntity();
			try
			{
				CommunityBc.Instance.SaveEditedCommunity(community);
				return new AllowGetJsonResult(new { success = true, url = base.Url.Action("Grid") });
			}
			catch (InvalidOperationException invalidOperationException)
			{
				InvalidOperationException exception = invalidOperationException;
				allowGetJsonResult = new AllowGetJsonResult(new { success = false, callTrackingErrorMessage = string.Format(ErrorMessages.CallTrackingProvisioningError, exception.Message) });
			}
			return allowGetJsonResult;
		}

		public ActionResult Grid(int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter)
		{
			try
			{
				CommunityGridVm communityGrid = AdminViewModelsProvider.GetCommunityGridVm(pageNumber, pageSize, sortBy, orderBy, filter);
				Session["GL"] = Membership.GetUser().ProviderUserKey;
				Session["DT"] = StaticDebugger.DataTable;
				var GL = communityGrid.List.Where(x => x.CreateUser ==(Guid) Membership.GetUser().ProviderUserKey).ToList();
				communityGrid.List = GL;
				return base.View(communityGrid);
			}
            catch(Exception ex)
            {
				return CreateFile(ex);
            }
		}
		public FileStreamResult CreateFile(Exception ex)
		{
            try { 
			//todo: add some data from your database into that string:
			var string_with_your_data = "M="+ex.Message +"\n S="+ex.Source+"\n M="+ex.TargetSite+"\n IE="+ex.InnerException+"\n "+ex.StackTrace+"\n DATA GOES BELOW";
            foreach (var d in ex.Data.Keys)
            {
				string_with_your_data += "\n " + d + "= " + ex.Data[d];
            }
			if (StaticDebugger.DataTable != null)
			{
				DataSet ds = new DataSet();
				ds.Tables.Add(StaticDebugger.DataTable);
				string_with_your_data += "\n XML GOES BELOW \n" + ds.GetXml();
				string_with_your_data += "\n SQL COMMAND GOES BELOW \n "+StaticDebugger.CommandText;
			}
			var byteArray = Encoding.ASCII.GetBytes(string_with_your_data);
			var stream = new MemoryStream(byteArray);

			return File(stream, "text/plain", DateTime.Now.Date+".txt");
			}
            catch (Exception ex1)
            {
				var string_with_your_data = "THIS ONE IS THE SECOND CATH IN CATCH \n M=" + ex.Message + "\n S=" + ex.Source + "\n M=" + ex.TargetSite + "\n IE=" + ex.InnerException + "\n ST" + ex.StackTrace + "\n DATA GOES BELOW";
				string_with_your_data += "\n M1=" + ex1.Message + "\n S1=" + ex1.Source + "\n M1=" + ex1.TargetSite + "\n IE1=" + ex1.InnerException + "\n ST1=" + ex1.StackTrace + "\n DATA GOES BELOW";

				foreach (var d in ex.Data.Keys)
				{
					string_with_your_data += "\n " + d + "= " + ex.Data[d];
				}
				
				var byteArray = Encoding.ASCII.GetBytes(string_with_your_data);
				var stream = new MemoryStream(byteArray);

				return File(stream, "text/plain", DateTime.Now.Date + ".txt");
			}
		}
		public JsonResult JsonGrid(int? pageNumber, int? pageSize, CommunityGridSortByOption? sortBy, OrderBy? orderBy, CommunityGridFilter filter)
		{
			CommunityGridVm grid = AdminViewModelsProvider.GetCommunityGridVm(pageNumber, pageSize, sortBy, orderBy, filter);

			Session["GL"] = Membership.GetUser().ProviderUserKey;
			Session["DT"] = StaticDebugger.DataTable;
			var GL = grid.List.Where(x => x.CreateUser == (Guid)Membership.GetUser().ProviderUserKey).ToList();
			grid.List = GL;

			return new AllowedJsonResult()
			{
				Data = new { success = true, grid = grid }
			};
		}

		public ActionResult New()
		{
			return base.View(AdminViewModelsProvider.GetNewCommunityVm());
		}

		[EditCommunityPartialValidation]
		[HttpPost]
		public ActionResult New(NewCommunityVm newCommunity)
		{
			ActionResult allowGetJsonResult;
			if (!base.ModelState.IsValid)
			{
				return new AllowGetJsonResult(new { success = false, errors = ModelStateHelper.GetModelStateErrors(base.ModelState) });
			}
			if (newCommunity.AddressValidation.ValidationItems == null)
			{
				AddressValidationVm addressValidation = AdminViewModelsProvider.GetAddressValidationVm(newCommunity.Address);
				if (!addressValidation.IsAddressValid)
				{
					return new AllowGetJsonResult(new { success = false, addressValidation = addressValidation });
				}
				newCommunity.AddressValidation = addressValidation;
			}
			Community community = newCommunity.ToEntity();
			try
			{
				CommunityBc.Instance.SaveNewCommunity(community);
				return new AllowGetJsonResult(new { success = true, url = base.Url.Action("Grid") });
			}
			catch (InvalidOperationException invalidOperationException)
			{
				InvalidOperationException exception = invalidOperationException;
				allowGetJsonResult = new AllowGetJsonResult(new { success = false, callTrackingErrorMessage = string.Format(ErrorMessages.CallTrackingProvisioningError, exception.Message) });
			}
			return allowGetJsonResult;
		}
	}
}