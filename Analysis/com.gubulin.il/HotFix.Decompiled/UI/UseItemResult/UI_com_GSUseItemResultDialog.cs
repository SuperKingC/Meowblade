using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_com_GSUseItemResultDialog : GComponent
{
	public GImage OfflineEarningWindow;

	public GButton ExitBtn;

	public GTextField Title;

	public UI_com_Content Content;

	public UI_btn_ConfirmBtn ConfirmBtn;

	public const string URL = "ui://800w3r8rgv8ui";

	public static string Name = "UI_com_GSUseItemResultDialog";

	public static string GetURL()
	{
		return "ui://800w3r8rgv8ui";
	}

	public static UI_com_GSUseItemResultDialog CreateInstance()
	{
		return (UI_com_GSUseItemResultDialog)(object)UIPackage.CreateObject("UseItemResult", "com_GSUseItemResultDialog");
	}

	public static UI_com_GSUseItemResultDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GSUseItemResultDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rgv8ui", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		OfflineEarningWindow = (GImage)((GComponent)this).GetChild("OfflineEarningWindow");
		ExitBtn = (GButton)((GComponent)this).GetChild("ExitBtn");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://800w3r8rgv8ui".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		Content = (UI_com_Content)(object)((GComponent)this).GetChild("Content");
		ConfirmBtn = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}
