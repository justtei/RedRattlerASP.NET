using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Mvc.Uipc.Admin.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class CommunityServiceVm
	{
		public int? AdditionInfoTypeId
		{
			get;
			set;
		}

		[AllowHtml]
		[StringLength(50)]
		public string Name
		{
			get;
			set;
		}

		public CommunityServiceVm()
		{
		}

		private CommunityService ToEntity()
		{
			return new CommunityService()
			{
				AdditionInfoTypeId = this.AdditionInfoTypeId,
				Name = this.Name
			};
		}

		public static List<CommunityService> ToEntityList(IEnumerable<CheckBoxVm> defaultCommunityServices, IEnumerable<CommunityServiceVm> communityServices)
		{
			int additionIntoTypeId;
			List<CommunityService> result = new List<CommunityService>();
			if (communityServices != null)
			{
				result = (
					from m in communityServices
					where !string.IsNullOrWhiteSpace(m.Name)
					select m.ToEntity()).ToList<CommunityService>();
			}
			if (defaultCommunityServices != null)
			{
				foreach (CheckBoxVm defaultCommunityService in 
					from m in defaultCommunityServices
					where m.IsChecked
					select m)
				{
					if (!int.TryParse(defaultCommunityService.Value, out additionIntoTypeId))
					{
						continue;
					}
					CommunityService communityService = new CommunityService()
					{
						AdditionInfoTypeId = new int?(additionIntoTypeId),
						Name = defaultCommunityService.Text
					};
					result.Add(communityService);
				}
			}
			return result;
		}
	}
}