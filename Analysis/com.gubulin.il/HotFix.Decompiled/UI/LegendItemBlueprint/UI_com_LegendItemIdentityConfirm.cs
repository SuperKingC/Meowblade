using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_LegendItemIdentityConfirm : GComponent
{
	public Controller Type;

	public GImage back;

	public GTextField Tip0;

	public GTextField Tip1;

	public UI_btn_forge Confirm;

	public UI_btn_CancelForge Cancel;

	public const string URL = "ui://h09dvkcgpw044b";

	public static string Name = "UI_com_LegendItemIdentityConfirm";

	public static string GetURL()
	{
		return "ui://h09dvkcgpw044b";
	}

	public static UI_com_LegendItemIdentityConfirm CreateInstance()
	{
		return (UI_com_LegendItemIdentityConfirm)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_LegendItemIdentityConfirm");
	}

	public static UI_com_LegendItemIdentityConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LegendItemIdentityConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgpw044b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		Tip0 = (GTextField)((GComponent)this).GetChild("Tip0");
		string id = "ui://h09dvkcgpw044b".Replace("ui://", "") + "-" + ((GObject)Tip0).id;
		((GObject)Tip0).text = LanguagesManager.GetDesc(id);
		Tip1 = (GTextField)((GComponent)this).GetChild("Tip1");
		string id2 = "ui://h09dvkcgpw044b".Replace("ui://", "") + "-" + ((GObject)Tip1).id;
		((GObject)Tip1).text = LanguagesManager.GetDesc(id2);
		Confirm = (UI_btn_forge)(object)((GComponent)this).GetChild("Confirm");
		Cancel = (UI_btn_CancelForge)(object)((GComponent)this).GetChild("Cancel");
	}
}
