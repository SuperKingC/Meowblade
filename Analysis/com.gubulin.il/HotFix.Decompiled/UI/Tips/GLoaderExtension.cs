using FairyGUI;

namespace UI.Tips;

public static class GLoaderExtension
{
	public static void InitMaterialIntroductionBtn(this GLoader self, string itemId)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		((GObject)self).onClick.Set((EventCallback1)delegate(EventContext x)
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)self).sortingOrder);
			x.StopPropagation();
		});
	}
}
