using MSLivingChoices.Entities.Admin;

namespace MSLivingChoices.IDacs.Admin.Components
{
	public interface ISeoDac
	{
		Seo GetSeoMetaData(Seo seo);

		Seo SaveSeoMetaData(Seo seo);
	}
}