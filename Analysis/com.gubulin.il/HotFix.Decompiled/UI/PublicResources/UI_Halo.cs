using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_Halo : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph back0;

	public GGraph back1;

	public GGraph back2;

	public GGraph back3;

	public GGraph back4;

	public GGraph back5;

	public GGraph back6;

	public GGraph back7;

	public GGraph back8;

	public const string URL = "ui://kt6rg65oqfz83s";

	public static string Name = "UI_Halo";

	public static string GetURL()
	{
		return "ui://kt6rg65oqfz83s";
	}

	public static UI_Halo CreateInstance()
	{
		return (UI_Halo)(object)UIPackage.CreateObject("PublicResources", "Halo");
	}

	public static UI_Halo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Halo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oqfz83s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		back0 = (GGraph)((GComponent)this).GetChild("back0");
		back1 = (GGraph)((GComponent)this).GetChild("back1");
		back2 = (GGraph)((GComponent)this).GetChild("back2");
		back3 = (GGraph)((GComponent)this).GetChild("back3");
		back4 = (GGraph)((GComponent)this).GetChild("back4");
		back5 = (GGraph)((GComponent)this).GetChild("back5");
		back6 = (GGraph)((GComponent)this).GetChild("back6");
		back7 = (GGraph)((GComponent)this).GetChild("back7");
		back8 = (GGraph)((GComponent)this).GetChild("back8");
	}
}
