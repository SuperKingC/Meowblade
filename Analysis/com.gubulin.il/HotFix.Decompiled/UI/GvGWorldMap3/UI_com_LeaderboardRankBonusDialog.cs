using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_LeaderboardRankBonusDialog : GComponent
{
	public GImage n191;

	public GImage n205;

	public GList RankBonusList;

	public GTextField n202;

	public GTextField n203;

	public GTextField n204;

	public const string URL = "ui://4eq8fgd2cj8is7d";

	public static string Name = "UI_com_LeaderboardRankBonusDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2cj8is7d";
	}

	public static UI_com_LeaderboardRankBonusDialog CreateInstance()
	{
		return (UI_com_LeaderboardRankBonusDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_LeaderboardRankBonusDialog");
	}

	public static UI_com_LeaderboardRankBonusDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LeaderboardRankBonusDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2cj8is7d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n205 = (GImage)((GComponent)this).GetChild("n205");
		RankBonusList = (GList)((GComponent)this).GetChild("RankBonusList");
		n202 = (GTextField)((GComponent)this).GetChild("n202");
		string id = "ui://4eq8fgd2cj8is7d".Replace("ui://", "") + "-" + ((GObject)n202).id;
		((GObject)n202).text = LanguagesManager.GetDesc(id);
		n203 = (GTextField)((GComponent)this).GetChild("n203");
		string id2 = "ui://4eq8fgd2cj8is7d".Replace("ui://", "") + "-" + ((GObject)n203).id;
		((GObject)n203).text = LanguagesManager.GetDesc(id2);
		n204 = (GTextField)((GComponent)this).GetChild("n204");
		string id3 = "ui://4eq8fgd2cj8is7d".Replace("ui://", "") + "-" + ((GObject)n204).id;
		((GObject)n204).text = LanguagesManager.GetDesc(id3);
	}
}
