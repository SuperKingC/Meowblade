using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_dec_BG01 : GComponent
{
	public GImage n18;

	public GImage n19;

	public GImage n20;

	public GImage n21;

	public GImage n22;

	public GImage n23;

	public GImage n24;

	public GImage n25;

	public const string URL = "ui://4r1llhd8tchc32";

	public static string Name = "UI_dec_BG01";

	public static string GetURL()
	{
		return "ui://4r1llhd8tchc32";
	}

	public static UI_dec_BG01 CreateInstance()
	{
		return (UI_dec_BG01)(object)UIPackage.CreateObject("GvGTalent", "dec_BG01");
	}

	public static UI_dec_BG01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_BG01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8tchc32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
	}
}
