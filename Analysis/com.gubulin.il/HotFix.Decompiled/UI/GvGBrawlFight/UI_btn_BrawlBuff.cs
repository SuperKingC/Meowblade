using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_BrawlBuff : GButton
{
	public GComponent icon;

	public GImage n1;

	public GTextField LvNum;

	public GImage n4;

	public const string URL = "ui://hozu168rk7me4u";

	public static string Name = "UI_btn_BrawlBuff";

	public static string GetURL()
	{
		return "ui://hozu168rk7me4u";
	}

	public static UI_btn_BrawlBuff CreateInstance()
	{
		return (UI_btn_BrawlBuff)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_BrawlBuff");
	}

	public static UI_btn_BrawlBuff CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BrawlBuff).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rk7me4u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GComponent)((GComponent)this).GetChild("icon");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		LvNum = (GTextField)((GComponent)this).GetChild("LvNum");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
