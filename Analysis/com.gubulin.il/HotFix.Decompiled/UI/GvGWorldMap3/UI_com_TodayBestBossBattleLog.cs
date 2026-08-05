using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_TodayBestBossBattleLog : GComponent
{
	public Controller IsNotEmpty;

	public UI_com_ShipIcon ShipIcon;

	public UI_com_CampRank Rank;

	public GTextField ShipName;

	public GImage n2;

	public GTextField Damage;

	public GTextField n5;

	public const string URL = "ui://4eq8fgd2zit4a1";

	public static string Name = "UI_com_TodayBestBossBattleLog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2zit4a1";
	}

	public static UI_com_TodayBestBossBattleLog CreateInstance()
	{
		return (UI_com_TodayBestBossBattleLog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_TodayBestBossBattleLog");
	}

	public static UI_com_TodayBestBossBattleLog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TodayBestBossBattleLog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2zit4a1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsNotEmpty = ((GComponent)this).GetController("IsNotEmpty");
		ShipIcon = (UI_com_ShipIcon)(object)((GComponent)this).GetChild("ShipIcon");
		Rank = (UI_com_CampRank)(object)((GComponent)this).GetChild("Rank");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Damage = (GTextField)((GComponent)this).GetChild("Damage");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://4eq8fgd2zit4a1".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
