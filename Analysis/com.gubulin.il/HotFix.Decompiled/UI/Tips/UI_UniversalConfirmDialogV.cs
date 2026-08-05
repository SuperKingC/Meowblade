using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_UniversalConfirmDialogV : GComponent
{
	public GImage back;

	public GTextField tip;

	public GTextField n27;

	public UI_boundBtn inviteBtn;

	public GTextField num;

	public const string URL = "ui://47lbpgx9hrru4v";

	public static string Name = "UI_UniversalConfirmDialogV";

	public static string GetURL()
	{
		return "ui://47lbpgx9hrru4v";
	}

	public static UI_UniversalConfirmDialogV CreateInstance()
	{
		return (UI_UniversalConfirmDialogV)(object)UIPackage.CreateObject("Tips", "UniversalConfirmDialogV");
	}

	public static UI_UniversalConfirmDialogV CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UniversalConfirmDialogV).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9hrru4v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://47lbpgx9hrru4v".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		inviteBtn = (UI_boundBtn)(object)((GComponent)this).GetChild("inviteBtn");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
