using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawBattleRankInfo : GComponent
{
	public GImage Background;

	public UI_btn_Close Close;

	public GList RankInfos;

	public GTextField n1;

	public GTextField Date;

	public GGroup n6;

	public const string URL = "ui://hozu168rhd0n9a";

	public static string Name = "UI_com_BrawBattleRankInfo";

	public static string GetURL()
	{
		return "ui://hozu168rhd0n9a";
	}

	public static UI_com_BrawBattleRankInfo CreateInstance()
	{
		return (UI_com_BrawBattleRankInfo)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawBattleRankInfo");
	}

	public static UI_com_BrawBattleRankInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawBattleRankInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rhd0n9a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		Close = (UI_btn_Close)(object)((GComponent)this).GetChild("Close");
		RankInfos = (GList)((GComponent)this).GetChild("RankInfos");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://hozu168rhd0n9a".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		Date = (GTextField)((GComponent)this).GetChild("Date");
		n6 = (GGroup)((GComponent)this).GetChild("n6");
	}
}
