using MSLivingChoices.Entities.Admin;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlCallTrackingDac : ICallTrackingDac
	{
		public SqlCallTrackingDac()
		{
		}

		public void DeleteCallTrackingPhones(Guid userId, List<CallTrackingPhone> phones)
		{
			(new DeleteCallTrackingPhonesCommand(userId, phones)).Execute();
		}

		public void DisconnectCallTrackingPhones(Guid userId, List<CallTrackingPhone> phones)
		{
			(new DisconnectCallTrackingPhonesCommand(userId, phones)).Execute();
		}

		public List<CallTrackingPhone> GetAll(List<Book> books)
		{
			GetAllCallTrackingPhonesCommand getAllCallTrackingPhonesCommand = new GetAllCallTrackingPhonesCommand(books);
			getAllCallTrackingPhonesCommand.Execute();
			return getAllCallTrackingPhonesCommand.CommandResult;
		}

		public List<CallTrackingPhone> GetAll(List<Book> books, int? pageNumber, int? pageSize, out int totalCount)
		{
			// 
			// Current member / type: System.Collections.Generic.List`1<MSLivingChoices.Entities.Admin.CallTrackingPhone> MSLivingChoices.SqlDacs.Admin.Components.SqlCallTrackingDac::GetAll(System.Collections.Generic.List`1<MSLivingChoices.Entities.Admin.Book>,System.Nullable`1<System.Int32>,System.Nullable`1<System.Int32>,System.Int32&)
			// File path: C:\Users\sra_r\Desktop\SeniorLiving1\Main\bin\MSLivingChoices.SqlDacs.Admin.dll
			// 
			// Product version: 2019.1.118.0
			// Exception in: System.Collections.Generic.List<MSLivingChoices.Entities.Admin.CallTrackingPhone> GetAll(System.Collections.Generic.List<MSLivingChoices.Entities.Admin.Book>,System.Nullable<System.Int32>,System.Nullable<System.Int32>,System.Int32&)
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

		public void SaveCallTrackingPhones(long communityId, List<CallTrackingPhone> phones)
		{
			(new SaveCallTrackingPhonesCommand(communityId, phones)).Execute();
		}

		public void SaveCallTrackingPhones(Community community)
		{
			(new SaveCallTrackingPhonesCommand(community)).Execute();
		}

		public void SaveCallTrackingPhones(ServiceProvider serviceProvider)
		{
			(new SaveCallTrackingPhonesCommand(serviceProvider)).Execute();
		}

		public void ValidateCallTrackingPhones(Guid userId)
		{
			(new ValidateCallTrackingPhonesCommand(userId)).Execute();
		}
	}
}