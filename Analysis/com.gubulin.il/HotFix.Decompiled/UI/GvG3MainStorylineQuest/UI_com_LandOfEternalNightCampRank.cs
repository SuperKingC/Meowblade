using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_LandOfEternalNightCampRank : GComponent
{
	public Controller Camp;

	public Controller IsMe;

	public Controller InCompetition;

	public GImage n12;

	public GLoader n0;

	public UI_com_CampRank Rank;

	public GTextField DataValue;

	public GImage n1;

	public GTextField n11;

	public GTextField n13;

	public const string URL = "ui://249h3k3dzit42y";

	public static string Name = "UI_com_LandOfEternalNightCampRank";

	public static string GetURL()
	{
		return "ui://249h3k3dzit42y";
	}

	public static UI_com_LandOfEternalNightCampRank CreateInstance()
	{
		return (UI_com_LandOfEternalNightCampRank)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_LandOfEternalNightCampRank");
	}

	public static UI_com_LandOfEternalNightCampRank CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfEternalNightCampRank).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dzit42y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		IsMe = ((GComponent)this).GetController("IsMe");
		InCompetition = ((GComponent)this).GetController("InCompetition");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		Rank = (UI_com_CampRank)(object)((GComponent)this).GetChild("Rank");
		DataValue = (GTextField)((GComponent)this).GetChild("DataValue");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://249h3k3dzit42y".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id2 = "ui://249h3k3dzit42y".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id2);
	}
}
