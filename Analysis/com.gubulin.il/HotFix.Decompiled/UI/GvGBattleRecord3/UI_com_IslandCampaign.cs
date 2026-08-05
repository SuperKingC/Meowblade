using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_IslandCampaign : GComponent
{
	public Controller IsNew;

	public Controller HasRandomEvent;

	public Controller BattleState;

	public GImage n8;

	public GTextField EndTime;

	public GTextField StartTime;

	public UI_com_Camp CampOccupy;

	public UI_com_Camp CampAttack;

	public GTextField n5;

	public GTextField n6;

	public GTextField n13;

	public GTextField n12;

	public UI_btn_IslandCampaign CheckRecords;

	public GImage n9;

	public GImage n10;

	public GImage n11;

	public GTextField n15;

	public GTextField n16;

	public const string URL = "ui://b3fc6085owu52";

	public static string Name = "UI_com_IslandCampaign";

	public static string GetURL()
	{
		return "ui://b3fc6085owu52";
	}

	public static UI_com_IslandCampaign CreateInstance()
	{
		return (UI_com_IslandCampaign)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_IslandCampaign");
	}

	public static UI_com_IslandCampaign CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandCampaign).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085owu52", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsNew = ((GComponent)this).GetController("IsNew");
		HasRandomEvent = ((GComponent)this).GetController("HasRandomEvent");
		BattleState = ((GComponent)this).GetController("BattleState");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		EndTime = (GTextField)((GComponent)this).GetChild("EndTime");
		StartTime = (GTextField)((GComponent)this).GetChild("StartTime");
		CampOccupy = (UI_com_Camp)(object)((GComponent)this).GetChild("CampOccupy");
		CampAttack = (UI_com_Camp)(object)((GComponent)this).GetChild("CampAttack");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://b3fc6085owu52".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://b3fc6085owu52".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id3 = "ui://b3fc6085owu52".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id3);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id4 = "ui://b3fc6085owu52".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id4);
		CheckRecords = (UI_btn_IslandCampaign)(object)((GComponent)this).GetChild("CheckRecords");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id5 = "ui://b3fc6085owu52".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id5);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id6 = "ui://b3fc6085owu52".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id6);
	}
}
