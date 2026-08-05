using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_BoxItemTipDialog : GComponent
{
	public Controller PageController;

	public GGraph interceptBack;

	public GImage windowBack;

	public UI_RepairBtn checkBtn;

	public UI_Content Content;

	public UI_consumption consumption;

	public const string URL = "ui://47lbpgx9gb5159";

	public static string Name = "UI_BoxItemTipDialog";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://47lbpgx9gb5159".Replace("ui://", ""), ((GObject)checkBtn).id, PageController.selectedIndex);
		((GObject)checkBtn).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9gb5159";
	}

	public static UI_BoxItemTipDialog CreateInstance()
	{
		return (UI_BoxItemTipDialog)(object)UIPackage.CreateObject("Tips", "BoxItemTipDialog");
	}

	public static UI_BoxItemTipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BoxItemTipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9gb5159", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		interceptBack = (GGraph)((GComponent)this).GetChild("interceptBack");
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		checkBtn = (UI_RepairBtn)(object)((GComponent)this).GetChild("checkBtn");
		Content = (UI_Content)(object)((GComponent)this).GetChild("Content");
		consumption = (UI_consumption)(object)((GComponent)this).GetChild("consumption");
	}
}
