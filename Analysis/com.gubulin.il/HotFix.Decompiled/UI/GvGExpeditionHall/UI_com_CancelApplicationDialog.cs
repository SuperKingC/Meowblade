using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_CancelApplicationDialog : GComponent
{
	public GImage back;

	public UI_btn_confirm3 Confirm;

	public UI_btn_Cancel Cancel;

	public GTextField Tip;

	public const string URL = "ui://k19peou7h7l7p5j";

	public static string Name = "UI_com_CancelApplicationDialog";

	public static string GetURL()
	{
		return "ui://k19peou7h7l7p5j";
	}

	public static UI_com_CancelApplicationDialog CreateInstance()
	{
		return (UI_com_CancelApplicationDialog)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_CancelApplicationDialog");
	}

	public static UI_com_CancelApplicationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CancelApplicationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7h7l7p5j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Confirm = (UI_btn_confirm3)(object)((GComponent)this).GetChild("Confirm");
		Cancel = (UI_btn_Cancel)(object)((GComponent)this).GetChild("Cancel");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
	}
}
