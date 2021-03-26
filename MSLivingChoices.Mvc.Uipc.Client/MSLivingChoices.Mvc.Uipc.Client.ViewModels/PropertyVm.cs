using MSLivingChoices.Utilities;
using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class PropertyVm
	{
		public bool IsValued
		{
			get
			{
				return !this.Value.IsNullOrEmpty();
			}
		}

		public string Unit
		{
			get;
			set;
		}

		public string Value
		{
			get;
			set;
		}

		public PropertyVm()
		{
		}

		public PropertyVm(string value, string unit)
		{
			this.Value = value;
			this.Unit = unit;
		}

		public void Clear()
		{
			this.Value = null;
			this.Unit = null;
		}

		public string FormatNumValue()
		{
			double num;
			if (!double.TryParse(this.Value, out num))
			{
				return string.Empty;
			}
			return num.ToString("N0");
		}

		public string ToNumberString()
		{
			string str = this.FormatNumValue();
			if (!this.IsValued)
			{
				return string.Empty;
			}
			return string.Format("{0} {1}", str, this.Unit).Trim();
		}

		public override string ToString()
		{
			if (!this.IsValued)
			{
				return string.Empty;
			}
			return string.Format("{0} {1}", this.Value, this.Unit).Trim();
		}
	}
}