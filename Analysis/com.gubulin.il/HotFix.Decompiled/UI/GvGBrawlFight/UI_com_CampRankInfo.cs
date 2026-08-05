using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_CampRankInfo : GComponent
{
	public GImage back;

	public GImage n7;

	public GImage n8;

	public UI_com_CampRank CampRank;

	public GTextField n2;

	public GTextField IslandCnt;

	public GTextField n4;

	public GTextField Energy;

	public GList PlayerRankInfos;

	public const string URL = "ui://hozu168rhd0n9b";

	public static string Name = "UI_com_CampRankInfo";

	public static string GetURL()
	{
		return "ui://hozu168rhd0n9b";
	}

	public static UI_com_CampRankInfo CreateInstance()
	{
		return (UI_com_CampRankInfo)(object)UIPackage.CreateObject("GvGBrawlFight", "com_CampRankInfo");
	}

	public static UI_com_CampRankInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampRankInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rhd0n9b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		CampRank = (UI_com_CampRank)(object)((GComponent)this).GetChild("CampRank");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://hozu168rhd0n9b".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		IslandCnt = (GTextField)((GComponent)this).GetChild("IslandCnt");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://hozu168rhd0n9b".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		Energy = (GTextField)((GComponent)this).GetChild("Energy");
		PlayerRankInfos = (GList)((GComponent)this).GetChild("PlayerRankInfos");
	}
}
