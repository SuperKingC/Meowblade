using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_BuildShipDialog : GComponent
{
	public Controller IsNotAvailable;

	public Controller State;

	public GImage n111;

	public UI_dec_GearRotation1 n131;

	public UI_dec_GearRotation2 n132;

	public UI_dec_04 n143;

	public UI_dec_02 n140;

	public UI_dec_01 n139;

	public GImage n129;

	public GTextField n113;

	public GTextField n126;

	public GTextField AvailableCount;

	public UI_RaceName RaceName;

	public UI_ConfirmBuildBtn ConfirmBuildBtn;

	public GGraph SpineLoader;

	public GImage n138;

	public GImage n142;

	public UI_ShipRaceInfo ShipRaceInfo;

	public GTextField n135;

	public GImage n115;

	public GImage n136;

	public GImage n137;

	public GImage n116;

	public GTextField n114;

	public GList RaceList;

	public UI_CloseBtn CloseBtn;

	public Transition t1;

	public const string URL = "ui://pwrbvhpvoktw0";

	public static string Name = "UI_BuildShipDialog";

	public static string GetURL()
	{
		return "ui://pwrbvhpvoktw0";
	}

	public static UI_BuildShipDialog CreateInstance()
	{
		return (UI_BuildShipDialog)(object)UIPackage.CreateObject("GvGShipPopup", "BuildShipDialog");
	}

	public static UI_BuildShipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuildShipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvoktw0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsNotAvailable = ((GComponent)this).GetController("IsNotAvailable");
		State = ((GComponent)this).GetController("State");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		n131 = (UI_dec_GearRotation1)(object)((GComponent)this).GetChild("n131");
		n132 = (UI_dec_GearRotation2)(object)((GComponent)this).GetChild("n132");
		n143 = (UI_dec_04)(object)((GComponent)this).GetChild("n143");
		n140 = (UI_dec_02)(object)((GComponent)this).GetChild("n140");
		n139 = (UI_dec_01)(object)((GComponent)this).GetChild("n139");
		n129 = (GImage)((GComponent)this).GetChild("n129");
		n113 = (GTextField)((GComponent)this).GetChild("n113");
		string id = "ui://pwrbvhpvoktw0".Replace("ui://", "") + "-" + ((GObject)n113).id;
		((GObject)n113).text = LanguagesManager.GetDesc(id);
		n126 = (GTextField)((GComponent)this).GetChild("n126");
		string id2 = "ui://pwrbvhpvoktw0".Replace("ui://", "") + "-" + ((GObject)n126).id;
		((GObject)n126).text = LanguagesManager.GetDesc(id2);
		AvailableCount = (GTextField)((GComponent)this).GetChild("AvailableCount");
		RaceName = (UI_RaceName)(object)((GComponent)this).GetChild("RaceName");
		ConfirmBuildBtn = (UI_ConfirmBuildBtn)(object)((GComponent)this).GetChild("ConfirmBuildBtn");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n142 = (GImage)((GComponent)this).GetChild("n142");
		ShipRaceInfo = (UI_ShipRaceInfo)(object)((GComponent)this).GetChild("ShipRaceInfo");
		n135 = (GTextField)((GComponent)this).GetChild("n135");
		string id3 = "ui://pwrbvhpvoktw0".Replace("ui://", "") + "-" + ((GObject)n135).id;
		((GObject)n135).text = LanguagesManager.GetDesc(id3);
		n115 = (GImage)((GComponent)this).GetChild("n115");
		n136 = (GImage)((GComponent)this).GetChild("n136");
		n137 = (GImage)((GComponent)this).GetChild("n137");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		n114 = (GTextField)((GComponent)this).GetChild("n114");
		string id4 = "ui://pwrbvhpvoktw0".Replace("ui://", "") + "-" + ((GObject)n114).id;
		((GObject)n114).text = LanguagesManager.GetDesc(id4);
		RaceList = (GList)((GComponent)this).GetChild("RaceList");
		CloseBtn = (UI_CloseBtn)(object)((GComponent)this).GetChild("CloseBtn");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
