using System;
using System.Runtime.Serialization;

namespace UserManagementSystem.Business.Enums
{
	[DataContract]
	public enum ChangePasswordResult
	{
		[EnumMember]
		Success,
		[EnumMember]
		Fail,
		[EnumMember]
		InvalidNewPasswordLength,
		[EnumMember]
		InvalidNewPasswordNonAlphanumericCharacters,
		[EnumMember]
		InvalidNewPasswordFormat,
		[EnumMember]
		CurrentPasswordIncorrect,
		[EnumMember]
		NoSuchUser
	}
}