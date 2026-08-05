using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_CampRank : GComponent
{
	public Controller Camp;

	public Controller Rank;

	public GImage n3;

	public GLoader Camp_2;

	public GImage n1;

	public GImage n2;

	public GImage n4;

	public GImage n5;

	public Transition t0;

	public const string URL = "ui://hozu168rhd0n9c";

	public static string Name = "UI_com_CampRank";

	public static string GetURL()
	{
		return "ui://hozu168rhd0n9c";
	}

	public static UI_com_CampRank CreateInstance()
	{
		return (UI_com_CampRank)(object)UIPackage.CreateObject("GvGBrawlFight", "com_CampRank");
	}

	public static UI_com_CampRank CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampRank).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rhd0n9c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Camp = ((GComponent)this).GetController("Camp");
		Rank = ((GComponent)this).GetController("Rank");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Camp_2 = (GLoader)((GComponent)this).GetChild("Camp");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
