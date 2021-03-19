using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Mvc.Uipc.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace MSLivingChoices.Mvc.Uipc.Admin.ViewModels
{
	public class EmailListVm
	{
		public List<EmailVm> AdditionalEmails
		{
			get;
			set;
		}

		[AllowHtml]
		[Email]
		[Required]
		public string DefaultEmail
		{
			get;
			set;
		}

		public long? DefaultEmailId
		{
			get;
			set;
		}

		public long? DefaultEmailTypeId
		{
			get;
			set;
		}

		public string DefaultEmailTypeName
		{
			get;
			set;
		}

		public EmailListVm()
		{
		}

		public List<Email> ToEntity()
		{
			List<Email> result = new List<Email>()
			{
				new Email()
				{
					Id = this.DefaultEmailId,
					EmailTypeId = this.DefaultEmailTypeId,
					Value = this.DefaultEmail
				}
			};
			foreach (EmailVm email in 
				from m in this.AdditionalEmails
				where !string.IsNullOrWhiteSpace(m.Email)
				select m)
			{
				result.Add(email.ToEntity());
			}
			return result;
		}
	}
}