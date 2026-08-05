using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_com_EffectSwitch : GComponent
{
	public GImage arrow;

	public GImage n15;

	public GImage n16;

	public GTextField leftTitle;

	public GList originAtt;

	public GGroup LeftDialog;

	public GImage n17;

	public GImage n18;

	public GTextField rightTitle;

	public GList switchList;

	public GButton ConfirmBtn;

	public GGroup RightDialog;

	public Transition ShowDialog;

	public const string URL = "ui://b9wlonaqcl001";

	public static string Name = "UI_com_EffectSwitch";

	public static string GetURL()
	{
		return "ui://b9wlonaqcl001";
	}

	public static UI_com_EffectSwitch CreateInstance()
	{
		return (UI_com_EffectSwitch)(object)UIPackage.CreateObject("LegendItemCultivation", "com_EffectSwitch");
	}

	public static UI_com_EffectSwitch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_EffectSwitch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqcl001", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		leftTitle = (GTextField)((GComponent)this).GetChild("leftTitle");
		string id = "ui://b9wlonaqcl001".Replace("ui://", "") + "-" + ((GObject)leftTitle).id;
		((GObject)leftTitle).text = LanguagesManager.GetDesc(id);
		originAtt = (GList)((GComponent)this).GetChild("originAtt");
		LeftDialog = (GGroup)((GComponent)this).GetChild("LeftDialog");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		rightTitle = (GTextField)((GComponent)this).GetChild("rightTitle");
		string id2 = "ui://b9wlonaqcl001".Replace("ui://", "") + "-" + ((GObject)rightTitle).id;
		((GObject)rightTitle).text = LanguagesManager.GetDesc(id2);
		switchList = (GList)((GComponent)this).GetChild("switchList");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
		RightDialog = (GGroup)((GComponent)this).GetChild("RightDialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}
