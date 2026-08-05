using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_LordUpgradeTipDialog : GComponent
{
	public GImage back;

	public GGraph n8;

	public GLoader icon;

	public GLoader title;

	public GTextField tip1;

	public GTextField tip2;

	public GImage n5;

	public GTextField tip3;

	public UI_RepairBtn ConfirmBtn;

	public const string URL = "ui://7ca77a3fcg2k3g";

	public static string Name = "UI_LordUpgradeTipDialog";

	public void SetButtonTitle()
	{
		((GObject)ConfirmBtn.title).text = LanguagesManager.GetDesc("Technology-LordUpgradeTipDialog-ConfirmBtn-title");
	}

	public static string GetURL()
	{
		return "ui://7ca77a3fcg2k3g";
	}

	public static UI_LordUpgradeTipDialog CreateInstance()
	{
		return (UI_LordUpgradeTipDialog)(object)UIPackage.CreateObject("Technology", "LordUpgradeTipDialog");
	}

	public static UI_LordUpgradeTipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LordUpgradeTipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fcg2k3g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GLoader)((GComponent)this).GetChild("title");
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id = "ui://7ca77a3fcg2k3g".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id);
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		tip3 = (GTextField)((GComponent)this).GetChild("tip3");
		ConfirmBtn = (UI_RepairBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}
