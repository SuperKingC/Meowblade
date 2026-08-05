using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_ShipInfo : GComponent
{
	public Controller State;

	public Controller isSelectStrategy;

	public Controller isSelect;

	public GImage n62;

	public GImage n57;

	public GLoader n54;

	public GImage n64;

	public UI_btn_05 dragArea;

	public GImage n55;

	public GLoader Icon;

	public GTextField n60;

	public GTextField State3;

	public GTextField State2;

	public GTextField State1;

	public GTextField ShipName;

	public GImage n58;

	public GImage n59;

	public UI_btn_03 cancelEnroll;

	public UI_btn_Strategy CurStrategyBtn;

	public UI_com_StrategyMenu StrategyMenu;

	public const string URL = "ui://hozu168rzbfu2y";

	public static string Name = "UI_com_ShipInfo";

	public static string GetURL()
	{
		return "ui://hozu168rzbfu2y";
	}

	public static UI_com_ShipInfo CreateInstance()
	{
		return (UI_com_ShipInfo)(object)UIPackage.CreateObject("GvGBrawlFight", "com_ShipInfo");
	}

	public static UI_com_ShipInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rzbfu2y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		isSelectStrategy = ((GComponent)this).GetController("isSelectStrategy");
		isSelect = ((GComponent)this).GetController("isSelect");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n54 = (GLoader)((GComponent)this).GetChild("n54");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		dragArea = (UI_btn_05)(object)((GComponent)this).GetChild("dragArea");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n60 = (GTextField)((GComponent)this).GetChild("n60");
		string id = "ui://hozu168rzbfu2y".Replace("ui://", "") + "-" + ((GObject)n60).id;
		((GObject)n60).text = LanguagesManager.GetDesc(id);
		State3 = (GTextField)((GComponent)this).GetChild("State3");
		string id2 = "ui://hozu168rzbfu2y".Replace("ui://", "") + "-" + ((GObject)State3).id;
		((GObject)State3).text = LanguagesManager.GetDesc(id2);
		State2 = (GTextField)((GComponent)this).GetChild("State2");
		string id3 = "ui://hozu168rzbfu2y".Replace("ui://", "") + "-" + ((GObject)State2).id;
		((GObject)State2).text = LanguagesManager.GetDesc(id3);
		State1 = (GTextField)((GComponent)this).GetChild("State1");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		cancelEnroll = (UI_btn_03)(object)((GComponent)this).GetChild("cancelEnroll");
		CurStrategyBtn = (UI_btn_Strategy)(object)((GComponent)this).GetChild("CurStrategyBtn");
		StrategyMenu = (UI_com_StrategyMenu)(object)((GComponent)this).GetChild("StrategyMenu");
	}
}
