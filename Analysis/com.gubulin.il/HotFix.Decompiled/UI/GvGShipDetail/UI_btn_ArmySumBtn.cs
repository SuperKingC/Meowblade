using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_ArmySumBtn : GButton
{
	public Controller SoldierStatus;

	public Controller button;

	public GImage back;

	public GImage n120;

	public GImage n118;

	public GTextField n119;

	public GTextField n115;

	public GTextField SelectedSoldiersTotalPower;

	public GGroup SelectedPowerGroup;

	public GList CurSelectedSoldiers;

	public GImage n124;

	public GImage n121;

	public GTextField n103;

	public GTextField n105;

	public GLoader SoldierStatusIcon;

	public GTextField SodierGroupsCount;

	public GTextField n122;

	public GImage dark;

	public const string URL = "ui://u6x0b1gnbvnu36";

	public static string Name = "UI_btn_ArmySumBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnbvnu36";
	}

	public static UI_btn_ArmySumBtn CreateInstance()
	{
		return (UI_btn_ArmySumBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_ArmySumBtn");
	}

	public static UI_btn_ArmySumBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ArmySumBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnbvnu36", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
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
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SoldierStatus = ((GComponent)this).GetController("SoldierStatus");
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		n120 = (GImage)((GComponent)this).GetChild("n120");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n119 = (GTextField)((GComponent)this).GetChild("n119");
		string id = "ui://u6x0b1gnbvnu36".Replace("ui://", "") + "-" + ((GObject)n119).id;
		((GObject)n119).text = LanguagesManager.GetDesc(id);
		n115 = (GTextField)((GComponent)this).GetChild("n115");
		string id2 = "ui://u6x0b1gnbvnu36".Replace("ui://", "") + "-" + ((GObject)n115).id;
		((GObject)n115).text = LanguagesManager.GetDesc(id2);
		SelectedSoldiersTotalPower = (GTextField)((GComponent)this).GetChild("SelectedSoldiersTotalPower");
		SelectedPowerGroup = (GGroup)((GComponent)this).GetChild("SelectedPowerGroup");
		CurSelectedSoldiers = (GList)((GComponent)this).GetChild("CurSelectedSoldiers");
		n124 = (GImage)((GComponent)this).GetChild("n124");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		n103 = (GTextField)((GComponent)this).GetChild("n103");
		string id3 = "ui://u6x0b1gnbvnu36".Replace("ui://", "") + "-" + ((GObject)n103).id;
		((GObject)n103).text = LanguagesManager.GetDesc(id3);
		n105 = (GTextField)((GComponent)this).GetChild("n105");
		string id4 = "ui://u6x0b1gnbvnu36".Replace("ui://", "") + "-" + ((GObject)n105).id;
		((GObject)n105).text = LanguagesManager.GetDesc(id4);
		SoldierStatusIcon = (GLoader)((GComponent)this).GetChild("SoldierStatusIcon");
		SodierGroupsCount = (GTextField)((GComponent)this).GetChild("SodierGroupsCount");
		n122 = (GTextField)((GComponent)this).GetChild("n122");
		string id5 = "ui://u6x0b1gnbvnu36".Replace("ui://", "") + "-" + ((GObject)n122).id;
		((GObject)n122).text = LanguagesManager.GetDesc(id5);
		dark = (GImage)((GComponent)this).GetChild("dark");
	}
}
