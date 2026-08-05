using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_btn_RewardSlot : GButton
{
	public Controller button;

	public Controller IsCard;

	public UI_mc_Luckdraw01 Card;

	public const string URL = "ui://rx5ntv98u1ma1e";

	public static string Name = "UI_btn_RewardSlot";

	public static string GetURL()
	{
		return "ui://rx5ntv98u1ma1e";
	}

	public static UI_btn_RewardSlot CreateInstance()
	{
		return (UI_btn_RewardSlot)(object)UIPackage.CreateObject("ReturningRewards", "btn_RewardSlot");
	}

	public static UI_btn_RewardSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RewardSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98u1ma1e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsCard = ((GComponent)this).GetController("IsCard");
		Card = (UI_mc_Luckdraw01)(object)((GComponent)this).GetChild("Card");
	}
}
