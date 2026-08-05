using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_LoginTypeSelectDialog : GComponent
{
	public GImage windowBack;

	public GTextField title;

	public GList LoginTypeBtnList;

	public const string URL = "ui://47lbpgx9kcpqtb8";

	public static string Name = "UI_LoginTypeSelectDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9kcpqtb8";
	}

	public static UI_LoginTypeSelectDialog CreateInstance()
	{
		return (UI_LoginTypeSelectDialog)(object)UIPackage.CreateObject("Tips", "LoginTypeSelectDialog");
	}

	public static UI_LoginTypeSelectDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LoginTypeSelectDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9kcpqtb8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9kcpqtb8".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		LoginTypeBtnList = (GList)((GComponent)this).GetChild("LoginTypeBtnList");
	}
}
