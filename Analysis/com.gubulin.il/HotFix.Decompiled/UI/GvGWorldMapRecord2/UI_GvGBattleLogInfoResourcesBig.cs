using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMapRecord2;

public class UI_GvGBattleLogInfoResourcesBig : GComponent
{
	public Controller Type;

	public Controller Status;

	public Controller AttackAndDefense;

	public Controller SelectController;

	public GImage n22;

	public GTextField Day;

	public GGraph n52;

	public GLoader n60;

	public GTextField Kill;

	public GTextField KillValue;

	public GTextField Loss;

	public GTextField LossValue;

	public UI_RankingListAvatar MyAvatar;

	public GTextField EnemyName;

	public GTextField MyName;

	public UI_RankingListAvatar EnemyAvatar;

	public UI_RecordDetail RecordDetail;

	public GImage n30;

	public GImage n32;

	public GGroup n38;

	public GImage n31;

	public GImage n33;

	public GGroup n39;

	public GGroup n61;

	public GTextField n59;

	public GImage n65;

	public const string URL = "ui://5xc1njmujjrn2z";

	public static string Name = "UI_GvGBattleLogInfoResourcesBig";

	public static string GetURL()
	{
		return "ui://5xc1njmujjrn2z";
	}

	public static UI_GvGBattleLogInfoResourcesBig CreateInstance()
	{
		return (UI_GvGBattleLogInfoResourcesBig)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "GvGBattleLogInfoResourcesBig");
	}

	public static UI_GvGBattleLogInfoResourcesBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBattleLogInfoResourcesBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmujjrn2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Status = ((GComponent)this).GetController("Status");
		AttackAndDefense = ((GComponent)this).GetController("AttackAndDefense");
		SelectController = ((GComponent)this).GetController("SelectController");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		Day = (GTextField)((GComponent)this).GetChild("Day");
		string id = "ui://5xc1njmujjrn2z".Replace("ui://", "") + "-" + ((GObject)Day).id;
		((GObject)Day).text = LanguagesManager.GetDesc(id);
		n52 = (GGraph)((GComponent)this).GetChild("n52");
		n60 = (GLoader)((GComponent)this).GetChild("n60");
		Kill = (GTextField)((GComponent)this).GetChild("Kill");
		string id2 = "ui://5xc1njmujjrn2z".Replace("ui://", "") + "-" + ((GObject)Kill).id;
		((GObject)Kill).text = LanguagesManager.GetDesc(id2);
		KillValue = (GTextField)((GComponent)this).GetChild("KillValue");
		Loss = (GTextField)((GComponent)this).GetChild("Loss");
		string id3 = "ui://5xc1njmujjrn2z".Replace("ui://", "") + "-" + ((GObject)Loss).id;
		((GObject)Loss).text = LanguagesManager.GetDesc(id3);
		LossValue = (GTextField)((GComponent)this).GetChild("LossValue");
		MyAvatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("MyAvatar");
		EnemyName = (GTextField)((GComponent)this).GetChild("EnemyName");
		MyName = (GTextField)((GComponent)this).GetChild("MyName");
		EnemyAvatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("EnemyAvatar");
		RecordDetail = (UI_RecordDetail)(object)((GComponent)this).GetChild("RecordDetail");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		n61 = (GGroup)((GComponent)this).GetChild("n61");
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id4 = "ui://5xc1njmujjrn2z".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id4);
		n65 = (GImage)((GComponent)this).GetChild("n65");
	}
}
