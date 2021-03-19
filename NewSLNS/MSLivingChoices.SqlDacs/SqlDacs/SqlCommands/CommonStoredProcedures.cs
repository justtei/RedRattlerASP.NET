using System;

namespace MSLivingChoices.SqlDacs.SqlCommands
{
	public struct CommonStoredProcedures
	{
		public static string SpGetBathroom;

		public static string SpGetBedroom;

		public static string SpGetCommunityAmenityType;

		public static string SpGetStates;

		public static string SpGetAdditionalInformationType;

		static CommonStoredProcedures()
		{
			CommonStoredProcedures.SpGetBathroom = "spGetBathroom";
			CommonStoredProcedures.SpGetBedroom = "spGetBedroom";
			CommonStoredProcedures.SpGetCommunityAmenityType = "spGetCommunityAmenityType";
			CommonStoredProcedures.SpGetStates = "spGetStates";
			CommonStoredProcedures.SpGetAdditionalInformationType = "spGetAdditionalInformationType";
		}
	}
}