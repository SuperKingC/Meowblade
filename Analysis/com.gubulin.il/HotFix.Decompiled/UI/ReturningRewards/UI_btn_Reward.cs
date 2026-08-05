using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_btn_Reward : GButton
{
	public Controller IsClaimed;

	public UI_mc_Slot Item;

	public GTextField ItemName;

	public GTextField Num;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://rx5ntv98win21";

	public static string Name = "UI_btn_Reward";

	public static string GetURL()
	{
		return "ui://rx5ntv98win21";
	}

	public static UI_btn_Reward CreateInstance()
	{
		return (UI_btn_Reward)(object)UIPackage.CreateObject("ReturningRewards", "btn_Reward");
	}

	public static UI_btn_Reward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Reward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win21", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsClaimed = ((GComponent)this).GetController("IsClaimed");
		Item = (UI_mc_Slot)(object)((GComponent)this).GetChild("Item");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
