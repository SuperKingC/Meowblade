using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_com_GvGUseItemResultDialog : GComponent
{
	public Controller HasTalent;

	public GImage OfflineEarningWindow;

	public GButton ExitBtn;

	public GTextField Title;

	public UI_com_Content Content;

	public UI_btn_ConfirmBtn ConfirmBtn;

	public GTextField Tips;

	public const string URL = "ui://800w3r8rez1cb";

	public static string Name = "UI_com_GvGUseItemResultDialog";

	public static string GetURL()
	{
		return "ui://800w3r8rez1cb";
	}

	public static UI_com_GvGUseItemResultDialog CreateInstance()
	{
		return (UI_com_GvGUseItemResultDialog)(object)UIPackage.CreateObject("UseItemResult", "com_GvGUseItemResultDialog");
	}

	public static UI_com_GvGUseItemResultDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GvGUseItemResultDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1cb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasTalent = ((GComponent)this).GetController("HasTalent");
		OfflineEarningWindow = (GImage)((GComponent)this).GetChild("OfflineEarningWindow");
		ExitBtn = (GButton)((GComponent)this).GetChild("ExitBtn");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://800w3r8rez1cb".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		Content = (UI_com_Content)(object)((GComponent)this).GetChild("Content");
		ConfirmBtn = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		Tips = (GTextField)((GComponent)this).GetChild("Tips");
		string id2 = "ui://800w3r8rez1cb".Replace("ui://", "") + "-" + ((GObject)Tips).id;
		((GObject)Tips).text = LanguagesManager.GetDesc(id2);
	}
}
