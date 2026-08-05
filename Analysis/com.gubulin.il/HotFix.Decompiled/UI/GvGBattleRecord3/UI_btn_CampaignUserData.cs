using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_CampaignUserData : GButton
{
	public Controller Rank;

	public Controller Winner;

	public Controller IsMe;

	public GLoader n13;

	public GImage n14;

	public GTextField ShipNum;

	public GTextField n2;

	public GTextField TotalScore;

	public GTextField Kill;

	public GTextField Loss;

	public GTextField Occupy;

	public GComponent ProfileDisplay;

	public GLoader n16;

	public GTextField Ranking;

	public GImage n19;

	public GImage n21;

	public UI_com_Component3 n24;

	public const string URL = "ui://b3fc6085owu56";

	public static string Name = "UI_btn_CampaignUserData";

	public static string GetURL()
	{
		return "ui://b3fc6085owu56";
	}

	public static UI_btn_CampaignUserData CreateInstance()
	{
		return (UI_btn_CampaignUserData)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_CampaignUserData");
	}

	public static UI_btn_CampaignUserData CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CampaignUserData).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085owu56", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rank = ((GComponent)this).GetController("Rank");
		Winner = ((GComponent)this).GetController("Winner");
		IsMe = ((GComponent)this).GetController("IsMe");
		n13 = (GLoader)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		ShipNum = (GTextField)((GComponent)this).GetChild("ShipNum");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://b3fc6085owu56".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		TotalScore = (GTextField)((GComponent)this).GetChild("TotalScore");
		Kill = (GTextField)((GComponent)this).GetChild("Kill");
		Loss = (GTextField)((GComponent)this).GetChild("Loss");
		Occupy = (GTextField)((GComponent)this).GetChild("Occupy");
		ProfileDisplay = (GComponent)((GComponent)this).GetChild("ProfileDisplay");
		n16 = (GLoader)((GComponent)this).GetChild("n16");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n24 = (UI_com_Component3)(object)((GComponent)this).GetChild("n24");
	}
}
