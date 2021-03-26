using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Mvc.Uipc.Client.ViewModels
{
	public class ResultSetSearchVm<TResult, TSort> : SearchVm<List<TResult>>
	{
		public LeadFormVm LeadForm
		{
			get;
			set;
		}

		public int PageNumber
		{
			get;
			set;
		}

		public int PageSize
		{
			get;
			set;
		}

		public PagingVm Paging
		{
			get;
			set;
		}

		public TSort SortType
		{
			get;
			set;
		}

		public int TotalCount
		{
			get;
			set;
		}

		public LookupLocationValidationVm ValidationResult
		{
			get;
			set;
		}

		public ResultSetSearchVm()
		{
		}
	}
}