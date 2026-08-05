using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_com_RightInfo : GComponent
{
	public GImage n81;

	public GComponent Race;

	public GRichTextField SoldierName;

	public GList SkillList;

	public UI_com_ConfirmBtn ConfirmBtn;

	public Transition t0;

	public const string URL = "ui://ia1am3ehbutlt22";

	public static string Name = "UI_com_RightInfo";

	public static string GetURL()
	{
		return "ui://ia1am3ehbutlt22";
	}

	public static UI_com_RightInfo CreateInstance()
	{
		return (UI_com_RightInfo)(object)UIPackage.CreateObject("UnlockSoldierShow", "com_RightInfo");
	}

	public static UI_com_RightInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RightInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehbutlt22", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n81 = (GImage)((GComponent)this).GetChild("n81");
		Race = (GComponent)((GComponent)this).GetChild("Race");
		SoldierName = (GRichTextField)((GComponent)this).GetChild("SoldierName");
		SkillList = (GList)((GComponent)this).GetChild("SkillList");
		ConfirmBtn = (UI_com_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
