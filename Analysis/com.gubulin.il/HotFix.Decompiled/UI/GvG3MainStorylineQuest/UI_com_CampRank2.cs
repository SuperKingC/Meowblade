using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_CampRank2 : GComponent
{
	public Controller Rank;

	public GImage n8;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public GImage n7;

	public const string URL = "ui://249h3k3diqtgs5y";

	public static string Name = "UI_com_CampRank2";

	public static string GetURL()
	{
		return "ui://249h3k3diqtgs5y";
	}

	public static UI_com_CampRank2 CreateInstance()
	{
		return (UI_com_CampRank2)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_CampRank2");
	}

	public static UI_com_CampRank2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampRank2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3diqtgs5y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rank = ((GComponent)this).GetController("Rank");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
