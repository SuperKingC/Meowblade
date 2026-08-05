using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_LegendItemBack : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph SfxBack;

	public GImage n3;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public GImage n7;

	public const string URL = "ui://xogvri2hs2vzl";

	public static string Name = "UI_LegendItemBack";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vzl";
	}

	public static UI_LegendItemBack CreateInstance()
	{
		return (UI_LegendItemBack)(object)UIPackage.CreateObject("LegendItemsDraw", "LegendItemBack");
	}

	public static UI_LegendItemBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vzl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
