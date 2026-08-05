using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_Slot : GComponent
{
	public Controller Type;

	public Controller IconScale;

	public GImage n29;

	public GImage n30;

	public GLoader icon;

	public GTextField Qty;

	public const string URL = "ui://k2sprg26laau4y";

	public static string Name = "UI_mc_Slot";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4y";
	}

	public static UI_mc_Slot CreateInstance()
	{
		return (UI_mc_Slot)(object)UIPackage.CreateObject("IslandComeAgain", "mc_Slot");
	}

	public static UI_mc_Slot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_Slot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		IconScale = ((GComponent)this).GetController("IconScale");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Qty = (GTextField)((GComponent)this).GetChild("Qty");
	}
}
