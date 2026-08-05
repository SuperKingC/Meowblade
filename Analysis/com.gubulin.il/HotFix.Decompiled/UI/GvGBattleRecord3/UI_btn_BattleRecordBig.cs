using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_BattleRecordBig : GButton
{
	public Controller button;

	public Controller HasBoss;

	public Controller Camp;

	public GLoader n60;

	public GImage n77;

	public GTextField Time;

	public GTextField TotalDamageValue;

	public GTextField n82;

	public GLoader n83;

	public GGroup TotalDamageTitle;

	public UI_com_ProfileDisplay RedProfile;

	public UI_com_ProfileDisplay BlueProfile;

	public UI_btn_RecordDetail RecordDetail;

	public GTextField n59;

	public GLoader n72;

	public GTextField IslandName;

	public GComponent ShipIconLeft;

	public GComponent ShipIconRight;

	public GImage n76;

	public GTextField Kill;

	public GLoader n78;

	public GGroup n84;

	public GLoader n79;

	public GTextField Loss;

	public GGroup n85;

	public GImage n89;

	public UI_com_BossAvatar BossIcon;

	public GImage n91;

	public GGroup n88;

	public const string URL = "ui://b3fc6085stwv1h";

	public static string Name = "UI_btn_BattleRecordBig";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv1h";
	}

	public static UI_btn_BattleRecordBig CreateInstance()
	{
		return (UI_btn_BattleRecordBig)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_BattleRecordBig");
	}

	public static UI_btn_BattleRecordBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BattleRecordBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv1h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		HasBoss = ((GComponent)this).GetController("HasBoss");
		Camp = ((GComponent)this).GetController("Camp");
		n60 = (GLoader)((GComponent)this).GetChild("n60");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		TotalDamageValue = (GTextField)((GComponent)this).GetChild("TotalDamageValue");
		n82 = (GTextField)((GComponent)this).GetChild("n82");
		string id = "ui://b3fc6085stwv1h".Replace("ui://", "") + "-" + ((GObject)n82).id;
		((GObject)n82).text = LanguagesManager.GetDesc(id);
		n83 = (GLoader)((GComponent)this).GetChild("n83");
		TotalDamageTitle = (GGroup)((GComponent)this).GetChild("TotalDamageTitle");
		RedProfile = (UI_com_ProfileDisplay)(object)((GComponent)this).GetChild("RedProfile");
		BlueProfile = (UI_com_ProfileDisplay)(object)((GComponent)this).GetChild("BlueProfile");
		RecordDetail = (UI_btn_RecordDetail)(object)((GComponent)this).GetChild("RecordDetail");
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id2 = "ui://b3fc6085stwv1h".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id2);
		n72 = (GLoader)((GComponent)this).GetChild("n72");
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		ShipIconLeft = (GComponent)((GComponent)this).GetChild("ShipIconLeft");
		ShipIconRight = (GComponent)((GComponent)this).GetChild("ShipIconRight");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		Kill = (GTextField)((GComponent)this).GetChild("Kill");
		n78 = (GLoader)((GComponent)this).GetChild("n78");
		n84 = (GGroup)((GComponent)this).GetChild("n84");
		n79 = (GLoader)((GComponent)this).GetChild("n79");
		Loss = (GTextField)((GComponent)this).GetChild("Loss");
		n85 = (GGroup)((GComponent)this).GetChild("n85");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		BossIcon = (UI_com_BossAvatar)(object)((GComponent)this).GetChild("BossIcon");
		n91 = (GImage)((GComponent)this).GetChild("n91");
		n88 = (GGroup)((GComponent)this).GetChild("n88");
	}
}
