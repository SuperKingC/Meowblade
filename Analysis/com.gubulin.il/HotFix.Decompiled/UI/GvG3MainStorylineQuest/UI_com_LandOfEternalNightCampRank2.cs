using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_LandOfEternalNightCampRank2 : GComponent
{
	public Controller Camp;

	public Controller IsMe;

	public GImage n12;

	public GLoader n0;

	public UI_com_CampRank2 Rank;

	public GTextField DataValue;

	public GTextField n11;

	public GTextField LastValue;

	public GTextField n13;

	public GTextField n15;

	public const string URL = "ui://249h3k3dm95us5v";

	public static string Name = "UI_com_LandOfEternalNightCampRank2";

	public static string GetURL()
	{
		return "ui://249h3k3dm95us5v";
	}

	public static UI_com_LandOfEternalNightCampRank2 CreateInstance()
	{
		return (UI_com_LandOfEternalNightCampRank2)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_LandOfEternalNightCampRank2");
	}

	public static UI_com_LandOfEternalNightCampRank2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfEternalNightCampRank2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dm95us5v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		IsMe = ((GComponent)this).GetController("IsMe");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		Rank = (UI_com_CampRank2)(object)((GComponent)this).GetChild("Rank");
		DataValue = (GTextField)((GComponent)this).GetChild("DataValue");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://249h3k3dm95us5v".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		LastValue = (GTextField)((GComponent)this).GetChild("LastValue");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id2 = "ui://249h3k3dm95us5v".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id2);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id3 = "ui://249h3k3dm95us5v".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id3);
	}
}
