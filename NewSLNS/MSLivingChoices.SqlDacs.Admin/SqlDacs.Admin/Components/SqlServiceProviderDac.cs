using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlServiceProviderDac : IServiceProviderDac
	{
		public SqlServiceProviderDac()
		{
		}

		public void ChangeFeatureDates(long serviceProviderId, DateTime? startDate, DateTime? endDate, int featureTypeId)
		{
			(new ChangeFeatureDatesCommand(serviceProviderId, startDate, endDate, featureTypeId)).Execute();
		}

		public void ChangePackageType(long serviceProviderId, PackageType packageType)
		{
			(new ChangePackageTypeForServiceProviderCommand(serviceProviderId, packageType)).Execute();
		}

		public void ChangePublishDates(long serviceProviderId, DateTime? startDate, DateTime? endDate, int publishTypeId)
		{
			(new ChangePublishDatesForServiceProviderCommand(serviceProviderId, startDate, endDate, publishTypeId)).Execute();
		}

		public void ChangeServiceCategories(long serviceProviderId, List<long> serviceCategoriesIds)
		{
			(new ChangeServiceCategoriesCommand(serviceProviderId, serviceCategoriesIds)).Execute();
		}

		public List<ServiceProvider> GetAll(List<Book> books, int? pageNumber, int? pageSize, ServiceProviderGridSortByOption? sortBy, OrderBy? orderBy, ServiceProviderGridFilter filter, out int totalCount)
		{
			// 
			// Current member / type: System.Collections.Generic.List`1<MSLivingChoices.Entities.Admin.ServiceProvider> MSLivingChoices.SqlDacs.Admin.Components.SqlServiceProviderDac::GetAll(System.Collections.Generic.List`1<MSLivingChoices.Entities.Admin.Book>,System.Nullable`1<System.Int32>,System.Nullable`1<System.Int32>,System.Nullable`1<MSLivingChoices.Entities.Admin.Enums.ServiceProviderGridSortByOption>,System.Nullable`1<MSLivingChoices.Entities.Admin.Enums.OrderBy>,MSLivingChoices.Entities.Admin.ServiceProviderGridFilter,System.Int32&)
			// File path: C:\Users\sra_r\Desktop\SeniorLiving1\Main\bin\MSLivingChoices.SqlDacs.Admin.dll
			// 
			// Product version: 2019.1.118.0
			// Exception in: System.Collections.Generic.List<MSLivingChoices.Entities.Admin.ServiceProvider> GetAll(System.Collections.Generic.List<MSLivingChoices.Entities.Admin.Book>,System.Nullable<System.Int32>,System.Nullable<System.Int32>,System.Nullable<MSLivingChoices.Entities.Admin.Enums.ServiceProviderGridSortByOption>,System.Nullable<MSLivingChoices.Entities.Admin.Enums.OrderBy>,MSLivingChoices.Entities.Admin.ServiceProviderGridFilter,System.Int32&)
			// 
			// Specified argument was out of the range of valid values.
			// Parameter name: Expression is not evaluated to any type.
			//    at ..(Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 102
			//    at ..(Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 94
			//    at ..(Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 94
			//    at ..(BinaryExpression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 182
			//    at ..(Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 75
			//    at ..(Instruction , Expression , VariableReference ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\UsedAsTypeHelper.cs:line 45
			//    at ..(VariableReference , TypeReference& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\GreedyTypeInferer.cs:line 60
			//    at ..() in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\GreedyTypeInferer.cs:line 35
			//    at Telerik.JustDecompiler.Decompiler.TypeInference.TypeInferer.() in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\TypeInference\TypeInferer.cs:line 300
			//    at Telerik.JustDecompiler.Decompiler.ExpressionDecompilerStep.(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\ExpressionDecompilerStep.cs:line 86
			//    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			//    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			//    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			//    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			//    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			// 
			// mailto: JustDecompilePublicFeedback@telerik.com

		}

		public ServiceProvider GetById(long id)
		{
			GetServiceProviderByIdCommand getServiceProviderByIdCommand = new GetServiceProviderByIdCommand(id);
			getServiceProviderByIdCommand.Execute();
			return getServiceProviderByIdCommand.CommandResult;
		}

		public List<County> GetCountiesServedById(long id)
		{
			GetCountiesServedByIdCommand getCountiesServedByIdCommand = new GetCountiesServedByIdCommand(id);
			getCountiesServedByIdCommand.Execute();
			return getCountiesServedByIdCommand.CommandResult;
		}

		public bool IsUsersService(List<Book> books, long serviceId)
		{
			IsUsersServiceCommand isUsersServiceCommand = new IsUsersServiceCommand(books, serviceId);
			isUsersServiceCommand.Execute();
			return isUsersServiceCommand.CommandResult.Value;
		}

		public ServiceProvider SaveEditedServiceProvider(ServiceProvider serviceProvider, int featureTypeId, int publishTypeId, int couponTypeId)
		{
			SaveServiceProviderCommand saveServiceProviderCommand = new SaveServiceProviderCommand(serviceProvider, featureTypeId, publishTypeId, couponTypeId);
			saveServiceProviderCommand.Execute();
			return saveServiceProviderCommand.CommandResult;
		}

		public ServiceProvider SaveNewServiceProvider(ServiceProvider serviceProvider, int featureTypeId, int publishTypeId, int couponTypeId)
		{
			SaveNewServiceProviderCommand saveNewServiceProviderCommand = new SaveNewServiceProviderCommand(serviceProvider, featureTypeId, publishTypeId, couponTypeId);
			saveNewServiceProviderCommand.Execute();
			return saveNewServiceProviderCommand.CommandResult;
		}
	}
}