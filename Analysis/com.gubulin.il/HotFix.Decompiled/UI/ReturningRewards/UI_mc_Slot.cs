using FairyGUI;
using FairyGUI.Utils;

namespace UI.ReturningRewards;

public class UI_mc_Slot : GButton
{
	public Controller Rarity;

	public GImage n29;

	public GImage n33;

	public GLoader icon;

	public GTextField Qty;

	public const string URL = "ui://rx5ntv98win2q";

	public static string Name = "UI_mc_Slot";

	public static string GetURL()
	{
		return "ui://rx5ntv98win2q";
	}

	public static UI_mc_Slot CreateInstance()
	{
		return (UI_mc_Slot)(object)UIPackage.CreateObject("ReturningRewards", "mc_Slot");
	}

	public static UI_mc_Slot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Slot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Qty = (GTextField)((GComponent)this).GetChild("Qty");
	}
}
