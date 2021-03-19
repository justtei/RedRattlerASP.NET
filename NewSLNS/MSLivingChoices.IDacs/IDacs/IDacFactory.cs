using MSLivingChoices.IDacs.Components;

namespace MSLivingChoices.IDacs
{
	public interface IDacFactory
	{
		IItemTypeDac GetItemTypeDac();
	}
}