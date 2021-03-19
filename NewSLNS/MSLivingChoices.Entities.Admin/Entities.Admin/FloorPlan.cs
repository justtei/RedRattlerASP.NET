using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Admin
{
	[Serializable]
	public class FloorPlan
	{
		public List<Amenity> Amenities
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MoneyType> ApplicationFee
		{
			get;
			set;
		}

		public long? BathroomFromId
		{
			get;
			set;
		}

		public long? BathroomToId
		{
			get;
			set;
		}

		public long? BedroomFromId
		{
			get;
			set;
		}

		public long? BedroomToId
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Community Community
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Admin.Coupon Coupon
		{
			get;
			set;
		}

		public DateTime DateAdded
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MoneyType> Deposit
		{
			get;
			set;
		}

		public long? Id
		{
			get;
			set;
		}

		public List<Image> Images
		{
			get;
			set;
		}

		public MeasureBoundary<int, LivingSpaceMeasure> LivingSpace
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MoneyType> PetDeposit
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MoneyType> PriceRange
		{
			get;
			set;
		}

		public FloorPlan()
		{
			this.Images = new List<Image>();
		}
	}
}