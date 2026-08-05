using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_LegendItemTitle : GComponent
{
	public Controller Type;

	public Controller TitleController;

	public GImage n0;

	public GImage n2;

	public GImage n3;

	public GImage n5;

	public GImage n4;

	public GImage n7;

	public GGraph sfxBack;

	public GTextField LegendItemName;

	public const string URL = "ui://b9wlonaqlofp10";

	public static string Name = "UI_LegendItemTitle";

	public static string GetURL()
	{
		return "ui://b9wlonaqlofp10";
	}

	public static UI_LegendItemTitle CreateInstance()
	{
		return (UI_LegendItemTitle)(object)UIPackage.CreateObject("LegendItemCultivation", "LegendItemTitle");
	}

	public static UI_LegendItemTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqlofp10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		TitleController = ((GComponent)this).GetController("TitleController");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		sfxBack = (GGraph)((GComponent)this).GetChild("sfxBack");
		LegendItemName = (GTextField)((GComponent)this).GetChild("LegendItemName");
	}
}
