using MSLivingChoices.Entities.Admin.Enums;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace MSLivingChoices.Entities.Admin
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

		public long? Id
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
			StringBuilder sb = new StringBuilder();
			if (this.StartDay.HasValue)
			{
				startDay = this.StartDay;
				sb.Append(startDay.Value);
				if (this.EndDay.HasValue)
				{
					startDay = this.EndDay;
					sb.Append(string.Format(" - {0} ", startDay.Value));
				}
			}
			else if (this.EndDay.HasValue)
			{
				startDay = this.EndDay;
				sb.Append(string.Format("{0} ", startDay.Value));
			}
			if (this.StartTime.HasValue)
			{
				value = this.StartTime.Value;
				sb.Append(string.Format("from {0}", value.ToString("hh:mm tt", CultureInfo.InvariantCulture)));
				if (this.EndTime.HasValue)
				{
					value = this.EndTime.Value;
					sb.Append(string.Format(" to {0}", value.ToString("hh:mm tt", CultureInfo.InvariantCulture)));
				}
			}
			else if (this.EndTime.HasValue)
			{
				value = this.EndTime.Value;
				sb.Append(string.Format("{0}", value.ToString("hh:mm tt", CultureInfo.InvariantCulture)));
			}
			string result = sb.ToString().Trim();
			if (!string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(this.Note))
			{
				result = string.Format("{0} ({1})", result, this.Note);
			}
			return result;
		}
	}
}