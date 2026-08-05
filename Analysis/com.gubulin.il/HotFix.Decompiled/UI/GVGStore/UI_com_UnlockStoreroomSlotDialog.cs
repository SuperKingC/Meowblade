using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_UnlockStoreroomSlotDialog : GComponent
{
	public GImage back;

	public UI_btn_confirm3 Confirm;

	public GTextField Tip;

	public UI_com_RefreshContent DialogMiddleContent;

	public const string URL = "ui://fvc33k3gv6i710";

	public static string Name = "UI_com_UnlockStoreroomSlotDialog";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i710";
	}

	public static UI_com_UnlockStoreroomSlotDialog CreateInstance()
	{
		return (UI_com_UnlockStoreroomSlotDialog)(object)UIPackage.CreateObject("GVGStore", "com_UnlockStoreroomSlotDialog");
	}

	public static UI_com_UnlockStoreroomSlotDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_UnlockStoreroomSlotDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i710", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Confirm = (UI_btn_confirm3)(object)((GComponent)this).GetChild("Confirm");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		DialogMiddleContent = (UI_com_RefreshContent)(object)((GComponent)this).GetChild("DialogMiddleContent");
	}
}
