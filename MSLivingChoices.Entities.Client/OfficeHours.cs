using MSLivingChoices.Entities.Client.Enums;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace MSLivingChoices.Entities.Client
{
	[Serializable]
	public class OfficeHours
	{
		public EuropeanDayOfWeek? EndDay
		{
			get;
			set;
		}

		public DateTime? EndTime
		{
			get;
			set;
		}

		public string Note
		{
			get;
			set;
		}

		public EuropeanDayOfWeek? StartDay
		{
			get;
			set;
		}

		public DateTime? StartTime
		{
			get;
			set;
		}

		public OfficeHours()
		{
		}

		public override string ToString()
		{
			EuropeanDayOfWeek? startDay;
			DateTime value;
			StringBuilder stringBuilder = new StringBuilder();
			if (this.StartDay.HasValue)
			{
				startDay = this.StartDay;
				stringBuilder.Append(startDay.Value);
				if (this.EndDay.HasValue)
				{
					startDay = this.EndDay;
					stringBuilder.Append(string.Format(" - {0} ", startDay.Value));
				}
			}
			else if (this.EndDay.HasValue)
			{
				startDay = this.EndDay;
				stringBuilder.Append(string.Format("{0} ", startDay.Value));
			}
			if (this.StartTime.HasValue)
			{
				value = this.StartTime.Value;
				stringBuilder.Append(string.Format("from {0}", value.ToString("hh:mm tt", CultureInfo.InvariantCulture)));
				if (this.EndTime.HasValue)
				{
					value = this.EndTime.Value;
					stringBuilder.Append(string.Format(" to {0}", value.ToString("hh:mm tt", CultureInfo.InvariantCulture)));
				}
			}
			else if (this.EndTime.HasValue)
			{
				value = this.EndTime.Value;
				stringBuilder.Append(string.Format("{0}", value.ToString("hh:mm tt", CultureInfo.InvariantCulture)));
			}
			string str = stringBuilder.ToString().Trim();
			if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(this.Note))
			{
				str = string.Format("{0} ({1})", str, this.Note);
			}
			return str;
		}
	}
}