using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_CampaignShipData : GComponent
{
	public Controller Type;

	public GImage n8;

	public GTextField Kill;

	public GTextField Loss;

	public GTextField Occupy;

	public GComponent ShipIcon;

	public GImage n5;

	public GTextField TotalScore;

	public GImage n7;

	public const string URL = "ui://b3fc6085stwva";

	public static string Name = "UI_com_CampaignShipData";

	public static string GetURL()
	{
		return "ui://b3fc6085stwva";
	}

	public static UI_com_CampaignShipData CreateInstance()
	{
		return (UI_com_CampaignShipData)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_CampaignShipData");
	}

	public static UI_com_CampaignShipData CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampaignShipData).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwva", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		Kill = (GTextField)((GComponent)this).GetChild("Kill");
		Loss = (GTextField)((GComponent)this).GetChild("Loss");
		Occupy = (GTextField)((GComponent)this).GetChild("Occupy");
		ShipIcon = (GComponent)((GComponent)this).GetChild("ShipIcon");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		TotalScore = (GTextField)((GComponent)this).GetChild("TotalScore");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
