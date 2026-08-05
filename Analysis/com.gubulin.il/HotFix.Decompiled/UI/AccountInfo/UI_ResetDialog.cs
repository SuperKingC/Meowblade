using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ResetDialog : GComponent
{
	public GImage back;

	public GTextField title;

	public GImage n16;

	public GImage n17;

	public GGraph inputUsernameBack;

	public GTextInput inputUsername;

	public UI_ResetConfirmBtn yesBtn;

	public UI_DataBackUpBtn DataBackUp;

	public const string URL = "ui://b9yxt7u0ql5b11";

	public static string Name = "UI_ResetDialog";

	public static string GetURL()
	{
		return "ui://b9yxt7u0ql5b11";
	}

	public static UI_ResetDialog CreateInstance()
	{
		return (UI_ResetDialog)(object)UIPackage.CreateObject("AccountInfo", "ResetDialog");
	}

	public static UI_ResetDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ResetDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0ql5b11", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9yxt7u0ql5b11".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		inputUsernameBack = (GGraph)((GComponent)this).GetChild("inputUsernameBack");
		inputUsername = (GTextInput)((GComponent)this).GetChild("inputUsername");
		yesBtn = (UI_ResetConfirmBtn)(object)((GComponent)this).GetChild("yesBtn");
		DataBackUp = (UI_DataBackUpBtn)(object)((GComponent)this).GetChild("DataBackUp");
	}
}
