using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_GvGBonusDialog : GComponent
{
	public Controller PageController;

	public Controller Type;

	public UI_PageItemBack n73;

	public UI_PageItemBack n75;

	public UI_PageItemBack n77;

	public GImage Back;

	public GList DamageRewardList;

	public GImage FakeBack;

	public UI_PageItem n74;

	public UI_PageItem n76;

	public UI_PageItem n78;

	public GTextField CurScoreText;

	public GTextField n84;

	public GTextField n85;

	public GTextField n72;

	public GImage n87;

	public GList ScoreBonusList;

	public GList MissionBonusList;

	public GTextField Time;

	public UI_KillBossBonusTip KillBossTip;

	public UI_GvGBossIconSmall BossIcon;

	public GTextField n91;

	public GTextField n92;

	public const string URL = "ui://0i520nzmtajuo8t";

	public static string Name = "UI_GvGBonusDialog";

	public static string GetURL()
	{
		return "ui://0i520nzmtajuo8t";
	}

	public static UI_GvGBonusDialog CreateInstance()
	{
		return (UI_GvGBonusDialog)(object)UIPackage.CreateObject("LordOfDreams", "GvGBonusDialog");
	}

	public static UI_GvGBonusDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBonusDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtajuo8t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Type = ((GComponent)this).GetController("Type");
		n73 = (UI_PageItemBack)(object)((GComponent)this).GetChild("n73");
		n75 = (UI_PageItemBack)(object)((GComponent)this).GetChild("n75");
		n77 = (UI_PageItemBack)(object)((GComponent)this).GetChild("n77");
		Back = (GImage)((GComponent)this).GetChild("Back");
		DamageRewardList = (GList)((GComponent)this).GetChild("DamageRewardList");
		FakeBack = (GImage)((GComponent)this).GetChild("FakeBack");
		n74 = (UI_PageItem)(object)((GComponent)this).GetChild("n74");
		n76 = (UI_PageItem)(object)((GComponent)this).GetChild("n76");
		n78 = (UI_PageItem)(object)((GComponent)this).GetChild("n78");
		CurScoreText = (GTextField)((GComponent)this).GetChild("CurScoreText");
		string id = "ui://0i520nzmtajuo8t".Replace("ui://", "") + "-" + ((GObject)CurScoreText).id;
		((GObject)CurScoreText).text = LanguagesManager.GetDesc(id);
		n84 = (GTextField)((GComponent)this).GetChild("n84");
		string id2 = "ui://0i520nzmtajuo8t".Replace("ui://", "") + "-" + ((GObject)n84).id;
		((GObject)n84).text = LanguagesManager.GetDesc(id2);
		n85 = (GTextField)((GComponent)this).GetChild("n85");
		string id3 = "ui://0i520nzmtajuo8t".Replace("ui://", "") + "-" + ((GObject)n85).id;
		((GObject)n85).text = LanguagesManager.GetDesc(id3);
		n72 = (GTextField)((GComponent)this).GetChild("n72");
		string id4 = "ui://0i520nzmtajuo8t".Replace("ui://", "") + "-" + ((GObject)n72).id;
		((GObject)n72).text = LanguagesManager.GetDesc(id4);
		n87 = (GImage)((GComponent)this).GetChild("n87");
		ScoreBonusList = (GList)((GComponent)this).GetChild("ScoreBonusList");
		MissionBonusList = (GList)((GComponent)this).GetChild("MissionBonusList");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id5 = "ui://0i520nzmtajuo8t".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id5);
		KillBossTip = (UI_KillBossBonusTip)(object)((GComponent)this).GetChild("KillBossTip");
		BossIcon = (UI_GvGBossIconSmall)(object)((GComponent)this).GetChild("BossIcon");
		n91 = (GTextField)((GComponent)this).GetChild("n91");
		string id6 = "ui://0i520nzmtajuo8t".Replace("ui://", "") + "-" + ((GObject)n91).id;
		((GObject)n91).text = LanguagesManager.GetDesc(id6);
		n92 = (GTextField)((GComponent)this).GetChild("n92");
		string id7 = "ui://0i520nzmtajuo8t".Replace("ui://", "") + "-" + ((GObject)n92).id;
		((GObject)n92).text = LanguagesManager.GetDesc(id7);
	}
}
