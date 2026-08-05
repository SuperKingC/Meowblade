using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_RareStoreItemRefreshConfirmDialog : GComponent
{
	public GImage back;

	public GButton Exit;

	public GTextField Tip;

	public GTextField n3;

	public UI_btn_Cancel2 Cancel;

	public UI_btn_confirm4 Confirm;

	public const string URL = "ui://fvc33k3gpql423";

	public static string Name = "UI_com_RareStoreItemRefreshConfirmDialog";

	public static string GetURL()
	{
		return "ui://fvc33k3gpql423";
	}

	public static UI_com_RareStoreItemRefreshConfirmDialog CreateInstance()
	{
		return (UI_com_RareStoreItemRefreshConfirmDialog)(object)UIPackage.CreateObject("GVGStore", "com_RareStoreItemRefreshConfirmDialog");
	}

	public static UI_com_RareStoreItemRefreshConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RareStoreItemRefreshConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gpql423", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Exit = (GButton)((GComponent)this).GetChild("Exit");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://fvc33k3gpql423".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://fvc33k3gpql423".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		Cancel = (UI_btn_Cancel2)(object)((GComponent)this).GetChild("Cancel");
		Confirm = (UI_btn_confirm4)(object)((GComponent)this).GetChild("Confirm");
	}
}
