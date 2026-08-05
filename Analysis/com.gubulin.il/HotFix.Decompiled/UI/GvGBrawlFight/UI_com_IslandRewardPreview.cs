using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_IslandRewardPreview : GComponent
{
	public GTextField n0;

	public GTextField n1;

	public GList PlayerRankRewards;

	public GList CampRankRewards;

	public GTextField n4;

	public GTextField n6;

	public GImage n7;

	public GImage n8;

	public const string URL = "ui://hozu168rniiv6s";

	public static string Name = "UI_com_IslandRewardPreview";

	public static string GetURL()
	{
		return "ui://hozu168rniiv6s";
	}

	public static UI_com_IslandRewardPreview CreateInstance()
	{
		return (UI_com_IslandRewardPreview)(object)UIPackage.CreateObject("GvGBrawlFight", "com_IslandRewardPreview");
	}

	public static UI_com_IslandRewardPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandRewardPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv6s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://hozu168rniiv6s".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id2 = "ui://hozu168rniiv6s".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id2);
		PlayerRankRewards = (GList)((GComponent)this).GetChild("PlayerRankRewards");
		CampRankRewards = (GList)((GComponent)this).GetChild("CampRankRewards");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id3 = "ui://hozu168rniiv6s".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id3);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id4 = "ui://hozu168rniiv6s".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id4);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
