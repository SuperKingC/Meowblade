using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_Btn_NeutralLevelBtn : GButton
{
	public Controller button;

	public Controller SelecedtStatus;

	public GLoader icon;

	public GLoader light;

	public GImage bonusBack0;

	public GLoader bonusIcon0;

	public GTextField bonusNum0;

	public GGroup BonusDesc0;

	public GImage bonusBack1;

	public GLoader bonusIcon1;

	public GTextField bonusNum1;

	public GGroup BonusDesc1;

	public Transition showSelf;

	public const string URL = "ui://f4wr270rgq2l83";

	public static string Name = "UI_Btn_NeutralLevelBtn";

	public static string GetURL()
	{
		return "ui://f4wr270rgq2l83";
	}

	public static UI_Btn_NeutralLevelBtn CreateInstance()
	{
		return (UI_Btn_NeutralLevelBtn)(object)UIPackage.CreateObject("InstanceZones", "Btn_NeutralLevelBtn");
	}

	public static UI_Btn_NeutralLevelBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Btn_NeutralLevelBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rgq2l83", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SelecedtStatus = ((GComponent)this).GetController("SelecedtStatus");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		light = (GLoader)((GComponent)this).GetChild("light");
		bonusBack0 = (GImage)((GComponent)this).GetChild("bonusBack0");
		bonusIcon0 = (GLoader)((GComponent)this).GetChild("bonusIcon0");
		bonusNum0 = (GTextField)((GComponent)this).GetChild("bonusNum0");
		BonusDesc0 = (GGroup)((GComponent)this).GetChild("BonusDesc0");
		bonusBack1 = (GImage)((GComponent)this).GetChild("bonusBack1");
		bonusIcon1 = (GLoader)((GComponent)this).GetChild("bonusIcon1");
		bonusNum1 = (GTextField)((GComponent)this).GetChild("bonusNum1");
		BonusDesc1 = (GGroup)((GComponent)this).GetChild("BonusDesc1");
		showSelf = ((GComponent)this).GetTransition("showSelf");
	}
}
