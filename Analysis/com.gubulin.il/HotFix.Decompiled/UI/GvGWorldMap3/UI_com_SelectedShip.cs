using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_SelectedShip : GComponent
{
	public Controller State;

	public GImage n1;

	public GImage n0;

	public GImage n12;

	public GLoader ShipIcon;

	public GTextField ShipName;

	public GTextField n4;

	public GTextField Amplifiers;

	public GGroup n8;

	public UI_btn_SetInsuranceShip SetInsurance;

	public GImage n9;

	public GTextField n10;

	public GGroup n11;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2aibkb6sdo";

	public static string Name = "UI_com_SelectedShip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2aibkb6sdo";
	}

	public static UI_com_SelectedShip CreateInstance()
	{
		return (UI_com_SelectedShip)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SelectedShip");
	}

	public static UI_com_SelectedShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectedShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2aibkb6sdo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		ShipIcon = (GLoader)((GComponent)this).GetChild("ShipIcon");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://4eq8fgd2aibkb6sdo".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		Amplifiers = (GTextField)((GComponent)this).GetChild("Amplifiers");
		n8 = (GGroup)((GComponent)this).GetChild("n8");
		SetInsurance = (UI_btn_SetInsuranceShip)(object)((GComponent)this).GetChild("SetInsurance");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id2 = "ui://4eq8fgd2aibkb6sdo".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id2);
		n11 = (GGroup)((GComponent)this).GetChild("n11");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
