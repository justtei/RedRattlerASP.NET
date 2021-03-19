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
	public class AmenityVm
	{
		public int? ClassId
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		[AllowHtml]
		[StringLength(100)]
		public string Name
		{
			get;
			set;
		}

		public AmenityVm()
		{
		}

		public AmenityVm(Amenity amenity)
		{
			this.Id = amenity.Id;
			this.ClassId = amenity.ClassId;
			this.Name = amenity.Name;
		}

		public Amenity ToEntity()
		{
			return new Amenity()
			{
				Name = this.Name.Trim(),
				Id = this.Id,
				ClassId = this.ClassId
			};
		}

		public static List<Amenity> ToEntityList(List<CheckBoxVm> defaultAmenities, List<AmenityVm> amenities)
		{
			int id;
			List<Amenity> result = new List<Amenity>();
			if (amenities != null)
			{
				result = (
					from m in amenities
					where !string.IsNullOrWhiteSpace(m.Name)
					select m.ToEntity()).ToList<Amenity>();
				foreach (Amenity amenity in result)
				{
					if (amenity.ClassId.HasValue)
					{
						continue;
					}
					amenity.ClassId = new int?(0);
				}
			}
			if (defaultAmenities != null)
			{
				foreach (CheckBoxVm defaultAmenity in 
					from m in defaultAmenities
					where m.IsChecked
					select m)
				{
					if (!int.TryParse(defaultAmenity.Value, out id))
					{
						continue;
					}
					Amenity amenity = new Amenity()
					{
						ClassId = new int?(id),
						Name = defaultAmenity.Text
					};
					result.Add(amenity);
				}
			}
			return result;
		}
	}
}