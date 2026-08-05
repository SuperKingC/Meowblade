using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_SilenceBuyConfirmDialog : GComponent
{
	public GImage back;

	public GButton Exit;

	public GTextField n3;

	public UI_btn_DoNotShowAgain DoNotShowAgain;

	public UI_btn_Cancel Cancel;

	public UI_btn_confirm3 Confirm;

	public const string URL = "ui://fvc33k3gxwkg3g";

	public static string Name = "UI_com_SilenceBuyConfirmDialog";

	public static string GetURL()
	{
		return "ui://fvc33k3gxwkg3g";
	}

	public static UI_com_SilenceBuyConfirmDialog CreateInstance()
	{
		return (UI_com_SilenceBuyConfirmDialog)(object)UIPackage.CreateObject("GVGStore", "com_SilenceBuyConfirmDialog");
	}

	public static UI_com_SilenceBuyConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SilenceBuyConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gxwkg3g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Exit = (GButton)((GComponent)this).GetChild("Exit");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://fvc33k3gxwkg3g".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		DoNotShowAgain = (UI_btn_DoNotShowAgain)(object)((GComponent)this).GetChild("DoNotShowAgain");
		Cancel = (UI_btn_Cancel)(object)((GComponent)this).GetChild("Cancel");
		Confirm = (UI_btn_confirm3)(object)((GComponent)this).GetChild("Confirm");
	}
}
