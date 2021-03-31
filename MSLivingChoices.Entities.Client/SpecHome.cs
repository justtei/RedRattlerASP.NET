using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class SpecHome
	{
		public List<string> Amenities
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MSLivingChoices.Entities.Client.Enums.Currency> ApplicationFee
		{
			get;
			set;
		}

		public Boundary<long> Bathes
		{
			get;
			set;
		}

		public Boundary<long> Beds
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Client.Coupon Coupon
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MSLivingChoices.Entities.Client.Enums.Currency> Deposit
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public long Id
		{
			get;
			set;
		}

		public List<Image> Images
		{
			get;
			set;
		}

		public MeasureBoundary<int, Area> LivingSpace
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public long PackageId
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MSLivingChoices.Entities.Client.Enums.Currency> PetDeposit
		{
			get;
			set;
		}

		public MeasureBoundary<decimal, MSLivingChoices.Entities.Client.Enums.Currency> Price
		{
			get;
			set;
		}

		public MSLivingChoices.Entities.Client.Enums.SaleType SaleType
		{
			get;
			set;
		}

		public BuildStatus Status
		{
			get;
			set;
		}

		public SpecHome()
		{
			this.Amenities = new List<string>();
			this.Images = new List<Image>();
		}
	}
}