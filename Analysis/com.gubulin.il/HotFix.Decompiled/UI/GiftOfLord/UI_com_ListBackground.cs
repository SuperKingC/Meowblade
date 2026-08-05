using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftOfLord;

public class UI_com_ListBackground : GComponent
{
	public GImage n0;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GImage n5;

	public GImage n7;

	public GImage n8;

	public const string URL = "ui://nz2z1ab8t0xzd";

	public static string Name = "UI_com_ListBackground";

	public static string GetURL()
	{
		return "ui://nz2z1ab8t0xzd";
	}

	public static UI_com_ListBackground CreateInstance()
	{
		return (UI_com_ListBackground)(object)UIPackage.CreateObject("GiftOfLord", "com_ListBackground");
	}

	public static UI_com_ListBackground CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ListBackground).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xzd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
