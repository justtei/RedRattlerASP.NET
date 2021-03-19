using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using UserManagementSystem.DAL;

[assembly: AssemblyCompany("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCopyright("Copyright ©  2012")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyProduct("UserManagementSystem.DAL")]
[assembly: AssemblyTitle("UserManagementSystem.DAL")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: CompilationRelaxations(8)]
[assembly: ComVisible(false)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: EdmRelationship("UMSModel", "FK_Address_City", "City", RelationshipMultiplicity.One, typeof(City), "Address", RelationshipMultiplicity.Many, typeof(Address), true)]
[assembly: EdmRelationship("UMSModel", "FK_Address_User", "User", RelationshipMultiplicity.One, typeof(User), "Address", RelationshipMultiplicity.Many, typeof(Address), true)]
[assembly: EdmRelationship("UMSModel", "FK_Book_Brand", "Brand", RelationshipMultiplicity.One, typeof(Brand), "Book", RelationshipMultiplicity.Many, typeof(Book), true)]
[assembly: EdmRelationship("UMSModel", "FK_City_State", "State", RelationshipMultiplicity.One, typeof(State), "City", RelationshipMultiplicity.Many, typeof(City), true)]
[assembly: EdmRelationship("UMSModel", "FK_Email_EmailType", "EmailType", RelationshipMultiplicity.One, typeof(EmailType), "Email", RelationshipMultiplicity.Many, typeof(Email), true)]
[assembly: EdmRelationship("UMSModel", "FK_Email_User", "User", RelationshipMultiplicity.One, typeof(User), "Email", RelationshipMultiplicity.Many, typeof(Email), true)]
[assembly: EdmRelationship("UMSModel", "FK_Phone_PhoneType", "PhoneType", RelationshipMultiplicity.One, typeof(PhoneType), "Phone", RelationshipMultiplicity.Many, typeof(Phone), true)]
[assembly: EdmRelationship("UMSModel", "FK_Phone_User", "User", RelationshipMultiplicity.One, typeof(User), "Phone", RelationshipMultiplicity.Many, typeof(Phone), true)]
[assembly: EdmRelationship("UMSModel", "FK_State_Country", "Country", RelationshipMultiplicity.One, typeof(Country), "State", RelationshipMultiplicity.Many, typeof(State), true)]
[assembly: EdmRelationship("UMSModel", "FK_UserToBook_Book", "Book", RelationshipMultiplicity.One, typeof(Book), "UserToBook", RelationshipMultiplicity.Many, typeof(UserToBook), true)]
[assembly: EdmRelationship("UMSModel", "FK_UserToBook_User", "User", RelationshipMultiplicity.One, typeof(User), "UserToBook", RelationshipMultiplicity.Many, typeof(UserToBook), true)]
[assembly: EdmSchema]
[assembly: Guid("9eb7b078-fb2f-4414-ba76-437fb9c898bd")]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows=true)]
