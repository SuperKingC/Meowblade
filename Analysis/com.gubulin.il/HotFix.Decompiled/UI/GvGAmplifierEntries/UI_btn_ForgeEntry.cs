using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierEntries;

public class UI_btn_ForgeEntry : GButton
{
	public GImage n118;

	public GImage n119;

	public UI_dec_Particleeffect n120;

	public GImage n117;

	public UI_dec_Particleeffect2 n121;

	public GImage RedDot;

	public const string URL = "ui://f1wmtifub4va14";

	public static string Name = "UI_btn_ForgeEntry";

	public static string GetURL()
	{
		return "ui://f1wmtifub4va14";
	}

	public static UI_btn_ForgeEntry CreateInstance()
	{
		return (UI_btn_ForgeEntry)(object)UIPackage.CreateObject("GvGAmplifierEntries", "btn_ForgeEntry");
	}

	public static UI_btn_ForgeEntry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ForgeEntry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifub4va14", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n119 = (GImage)((GComponent)this).GetChild("n119");
		n120 = (UI_dec_Particleeffect)(object)((GComponent)this).GetChild("n120");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n121 = (UI_dec_Particleeffect2)(object)((GComponent)this).GetChild("n121");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
	}
}
