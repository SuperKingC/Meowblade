using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_DailySupply : GComponent
{
	public Controller Type;

	public GImage n12;

	public GImage n13;

	public GImage n10;

	public GImage n15;

	public GTextField n11;

	public GLoader TalentIcon;

	public UI_btn_Receive Receive;

	public GTextField n4;

	public UI_btn_GotoActivate Activate;

	public GLoader BoxIcon;

	public GTextField n6;

	public GTextField Countdown;

	public GTextField n9;

	public GGraph GetDaukyBonusSfxEndPos;

	public const string URL = "ui://pobej4q7mo53l";

	public static string Name = "UI_com_DailySupply";

	public static string GetURL()
	{
		return "ui://pobej4q7mo53l";
	}

	public static UI_com_DailySupply CreateInstance()
	{
		return (UI_com_DailySupply)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_DailySupply");
	}

	public static UI_com_DailySupply CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DailySupply).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mo53l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://pobej4q7mo53l".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		TalentIcon = (GLoader)((GComponent)this).GetChild("TalentIcon");
		Receive = (UI_btn_Receive)(object)((GComponent)this).GetChild("Receive");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://pobej4q7mo53l".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		Activate = (UI_btn_GotoActivate)(object)((GComponent)this).GetChild("Activate");
		BoxIcon = (GLoader)((GComponent)this).GetChild("BoxIcon");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id3 = "ui://pobej4q7mo53l".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id3);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id4 = "ui://pobej4q7mo53l".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id4);
		GetDaukyBonusSfxEndPos = (GGraph)((GComponent)this).GetChild("GetDaukyBonusSfxEndPos");
	}
}
