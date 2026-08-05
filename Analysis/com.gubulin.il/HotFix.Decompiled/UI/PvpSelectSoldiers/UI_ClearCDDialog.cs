using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ClearCDDialog : GComponent
{
	public GImage back;

	public GTextField tip;

	public GButton exitBtn;

	public UI_RefreshCardConfirmBtn RefreshCardBtn;

	public UI_DialogMiddleContent DialogMiddleContent;

	public GLoader icon;

	public GLoader compoundNumBack;

	public GTextField compoundNum;

	public GGroup n35;

	public const string URL = "ui://82mo10n5qxbi8p";

	public static string Name = "UI_ClearCDDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5qxbi8p";
	}

	public static UI_ClearCDDialog CreateInstance()
	{
		return (UI_ClearCDDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ClearCDDialog");
	}

	public static UI_ClearCDDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClearCDDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5qxbi8p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://82mo10n5qxbi8p".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		RefreshCardBtn = (UI_RefreshCardConfirmBtn)(object)((GComponent)this).GetChild("RefreshCardBtn");
		DialogMiddleContent = (UI_DialogMiddleContent)(object)((GComponent)this).GetChild("DialogMiddleContent");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		compoundNumBack = (GLoader)((GComponent)this).GetChild("compoundNumBack");
		compoundNum = (GTextField)((GComponent)this).GetChild("compoundNum");
		n35 = (GGroup)((GComponent)this).GetChild("n35");
	}
}
