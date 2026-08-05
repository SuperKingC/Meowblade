using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_RandomEvent : GComponent
{
	public Controller HasBonus;

	public Controller ButtonStatus;

	public Controller HasCountdown;

	public Controller AllowDestruction;

	public Controller TimerColor;

	public GImage n0;

	public GImage n14;

	public GImage n22;

	public GImage n15;

	public GTextField EventName;

	public UI_com_RandomEventsDesc EventDesc;

	public GImage n16;

	public UI_com_BigBonus BIgBonus;

	public GTextField n3;

	public GList Bonus;

	public GGroup n5;

	public GLoader ActionButton;

	public GTextField Countdown;

	public GTextField n12;

	public GGroup n13;

	public GImage n19;

	public GImage n20;

	public GTextField IslandTip;

	public GTextField ShipTip;

	public GTextField n9;

	public GGroup n18;

	public UI_btn_DeleteEvent DestroyEvent;

	public GImage n23;

	public const string URL = "ui://4eq8fgd2dc6m89";

	public static string Name = "UI_com_RandomEvent";

	public static string GetURL()
	{
		return "ui://4eq8fgd2dc6m89";
	}

	public static UI_com_RandomEvent CreateInstance()
	{
		return (UI_com_RandomEvent)(object)UIPackage.CreateObject("GvGWorldMap3", "com_RandomEvent");
	}

	public static UI_com_RandomEvent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RandomEvent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2dc6m89", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasBonus = ((GComponent)this).GetController("HasBonus");
		ButtonStatus = ((GComponent)this).GetController("ButtonStatus");
		HasCountdown = ((GComponent)this).GetController("HasCountdown");
		AllowDestruction = ((GComponent)this).GetController("AllowDestruction");
		TimerColor = ((GComponent)this).GetController("TimerColor");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		EventName = (GTextField)((GComponent)this).GetChild("EventName");
		EventDesc = (UI_com_RandomEventsDesc)(object)((GComponent)this).GetChild("EventDesc");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		BIgBonus = (UI_com_BigBonus)(object)((GComponent)this).GetChild("BIgBonus");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4eq8fgd2dc6m89".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		n5 = (GGroup)((GComponent)this).GetChild("n5");
		ActionButton = (GLoader)((GComponent)this).GetChild("ActionButton");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id2 = "ui://4eq8fgd2dc6m89".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id2);
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		IslandTip = (GTextField)((GComponent)this).GetChild("IslandTip");
		string id3 = "ui://4eq8fgd2dc6m89".Replace("ui://", "") + "-" + ((GObject)IslandTip).id;
		((GObject)IslandTip).text = LanguagesManager.GetDesc(id3);
		ShipTip = (GTextField)((GComponent)this).GetChild("ShipTip");
		string id4 = "ui://4eq8fgd2dc6m89".Replace("ui://", "") + "-" + ((GObject)ShipTip).id;
		((GObject)ShipTip).text = LanguagesManager.GetDesc(id4);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id5 = "ui://4eq8fgd2dc6m89".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id5);
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		DestroyEvent = (UI_btn_DeleteEvent)(object)((GComponent)this).GetChild("DestroyEvent");
		n23 = (GImage)((GComponent)this).GetChild("n23");
	}
}
