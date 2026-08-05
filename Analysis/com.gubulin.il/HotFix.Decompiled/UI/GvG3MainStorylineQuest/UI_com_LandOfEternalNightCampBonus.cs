using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_LandOfEternalNightCampBonus : GComponent
{
	public GImage n0;

	public GList RewardsConfig;

	public GTextField n2;

	public GTextField n3;

	public GTextField n4;

	public GTextField n6;

	public GGroup n10;

	public const string URL = "ui://249h3k3dzit42w";

	public static string Name = "UI_com_LandOfEternalNightCampBonus";

	public static string GetURL()
	{
		return "ui://249h3k3dzit42w";
	}

	public static UI_com_LandOfEternalNightCampBonus CreateInstance()
	{
		return (UI_com_LandOfEternalNightCampBonus)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_LandOfEternalNightCampBonus");
	}

	public static UI_com_LandOfEternalNightCampBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfEternalNightCampBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dzit42w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		RewardsConfig = (GList)((GComponent)this).GetChild("RewardsConfig");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://249h3k3dzit42w".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://249h3k3dzit42w".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id3 = "ui://249h3k3dzit42w".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id3);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id4 = "ui://249h3k3dzit42w".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id4);
		n10 = (GGroup)((GComponent)this).GetChild("n10");
	}
}
