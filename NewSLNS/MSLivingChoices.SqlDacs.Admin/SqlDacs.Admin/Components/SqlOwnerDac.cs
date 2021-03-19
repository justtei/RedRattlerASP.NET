using MSLivingChoices.Entities.Admin;
using MSLivingChoices.Entities.Admin.Enums;
using MSLivingChoices.IDacs.Admin.Components;
using MSLivingChoices.SqlDacs.Admin.SqlCommands;
using MSLivingChoices.SqlDacs.SqlCommands;
using System;
using System.Collections.Generic;

namespace MSLivingChoices.SqlDacs.Admin.Components
{
	public class SqlOwnerDac : IOwnerDac
	{
		private readonly List<Owner> _owners;

		public SqlOwnerDac()
		{
			this._owners = new List<Owner>();
			for (int i = 1; i <= 5; i++)
			{
				Owner owner = new Owner()
				{
					Id = new long?((long)i),
					OwnerType = OwnerType.PropertyManager,
					Name = string.Concat("Name", i),
					Address = new Address(),
					Emails = new List<Email>()
					{
						new Email()
						{
							EmailTypeId = new long?((long)i),
							Value = string.Format("email{0}@mail.ru", i)
						}
					},
					Contacts = new List<Contact>()
					{
						new Contact()
						{
							FirstName = string.Concat("FirstName", i),
							LastName = string.Concat("LastName", i)
						}
					}
				};
				this._owners.Add(owner);
			}
			for (int i = 6; i <= 10; i++)
			{
				Owner owner1 = new Owner()
				{
					Id = new long?((long)i),
					OwnerType = OwnerType.Builder,
					Name = string.Concat("Name", i),
					Address = new Address(),
					Emails = new List<Email>()
					{
						new Email()
						{
							EmailTypeId = new long?((long)i),
							Value = string.Format("email{0}@mail.ru", i)
						}
					},
					Contacts = new List<Contact>()
					{
						new Contact()
						{
							FirstName = string.Concat("FirstName", i),
							LastName = string.Concat("LastName", i)
						}
					}
				};
				this._owners.Add(owner1);
			}
			for (int i = 11; i <= 15; i++)
			{
				Owner owner2 = new Owner()
				{
					Id = new long?((long)i),
					OwnerType = OwnerType.Advertiser,
					Name = string.Concat("Name", i),
					Address = new Address(),
					Emails = new List<Email>()
					{
						new Email()
						{
							EmailTypeId = new long?((long)i),
							Value = string.Format("email{0}@mail.ru", i)
						}
					},
					Contacts = new List<Contact>()
					{
						new Contact()
						{
							FirstName = string.Concat("FirstName", i),
							LastName = string.Concat("LastName", i)
						}
					}
				};
				this._owners.Add(owner2);
			}
		}

		public List<Owner> GetAll()
		{
			return this._owners;
		}

		public List<Owner> GetAllByOwnerType(OwnerType ownerType, int? pageNumber, int? pageSize, out int totalCount)
		{
			// 
			// Current member / type: System.Collections.Generic.List`1<MSLivingChoices.Entities.Admin.Owner> MSLivingChoices.SqlDacs.Admin.Components.SqlOwnerDac::GetAllByOwnerType(MSLivingChoices.Entities.Admin.Enums.OwnerType,System.Nullable`1<System.Int32>,System.Nullable`1<System.Int32>,System.Int32&)
			// File path: C:\Users\sra_r\Desktop\SeniorLiving1\Main\bin\MSLivingChoices.SqlDacs.Admin.dll
			// 
			// Product version: 2019.1.118.0
			// Exception in: System.Collections.Generic.List<MSLivingChoices.Entities.Admin.Owner> GetAllByOwnerType(MSLivingChoices.Entities.Admin.Enums.OwnerType,System.Nullable<System.Int32>,System.Nullable<System.Int32>,System.Int32&)
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

		public List<Owner> GetAllByOwnerType(OwnerType ownerType)
		{
			GetAllByOwnerTypeCommand getAllByOwnerTypeCommand = new GetAllByOwnerTypeCommand(ownerType);
			getAllByOwnerTypeCommand.Execute();
			return getAllByOwnerTypeCommand.CommandResult;
		}

		public Owner GetById(long id)
		{
			GetOwnerByIdCommand getOwnerByIdCommand = new GetOwnerByIdCommand(id);
			getOwnerByIdCommand.Execute();
			return getOwnerByIdCommand.CommandResult;
		}

		public Owner SaveNewOwner(Owner entity)
		{
			SaveOwnerCommand saveOwnerCommand = new SaveOwnerCommand(entity);
			saveOwnerCommand.Execute();
			return saveOwnerCommand.CommandResult;
		}
	}
}