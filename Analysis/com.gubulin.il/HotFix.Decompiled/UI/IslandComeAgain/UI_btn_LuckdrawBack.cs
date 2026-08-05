using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_btn_LuckdrawBack : GButton
{
	public GImage n28;

	public GImage n29;

	public const string URL = "ui://k2sprg26laau52";

	public static string Name = "UI_btn_LuckdrawBack";

	public static string GetURL()
	{
		return "ui://k2sprg26laau52";
	}

	public static UI_btn_LuckdrawBack CreateInstance()
	{
		return (UI_btn_LuckdrawBack)(object)UIPackage.CreateObject("IslandComeAgain", "btn_LuckdrawBack");
	}

	public static UI_btn_LuckdrawBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_LuckdrawBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau52", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GImage)((GComponent)this).GetChild("n29");
	}
}
