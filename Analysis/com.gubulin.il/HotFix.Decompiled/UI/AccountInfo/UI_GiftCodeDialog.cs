using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_GiftCodeDialog : GComponent
{
	public GImage back;

	public GTextField title;

	public GGraph codeBack;

	public GTextInput code;

	public UI_confirmBtn confirmBtn;

	public const string URL = "ui://b9yxt7u0jc5a6z";

	public static string Name = "UI_GiftCodeDialog";

	public static string GetURL()
	{
		return "ui://b9yxt7u0jc5a6z";
	}

	public static UI_GiftCodeDialog CreateInstance()
	{
		return (UI_GiftCodeDialog)(object)UIPackage.CreateObject("AccountInfo", "GiftCodeDialog");
	}

	public static UI_GiftCodeDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GiftCodeDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0jc5a6z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9yxt7u0jc5a6z".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		codeBack = (GGraph)((GComponent)this).GetChild("codeBack");
		code = (GTextInput)((GComponent)this).GetChild("code");
		string id2 = "ui://b9yxt7u0jc5a6z".Replace("ui://", "") + "-" + ((GObject)code).id + "-prompt";
		code.promptText = LanguagesManager.GetDesc(id2);
		confirmBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("confirmBtn");
	}
}
