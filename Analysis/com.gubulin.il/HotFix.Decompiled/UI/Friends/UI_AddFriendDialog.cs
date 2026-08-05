using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_AddFriendDialog : GComponent
{
	public GImage tipBackground;

	public GImage title;

	public GImage inputBackground;

	public GTextInput Input;

	public UI_SendBtn SendBtn;

	public const string URL = "ui://3rz8gv6cqtr6s";

	public static string Name = "UI_AddFriendDialog";

	public static string GetURL()
	{
		return "ui://3rz8gv6cqtr6s";
	}

	public static UI_AddFriendDialog CreateInstance()
	{
		return (UI_AddFriendDialog)(object)UIPackage.CreateObject("Friends", "AddFriendDialog");
	}

	public static UI_AddFriendDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddFriendDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		tipBackground = (GImage)((GComponent)this).GetChild("tipBackground");
		title = (GImage)((GComponent)this).GetChild("title");
		inputBackground = (GImage)((GComponent)this).GetChild("inputBackground");
		Input = (GTextInput)((GComponent)this).GetChild("Input");
		string id = "ui://3rz8gv6cqtr6s".Replace("ui://", "") + "-" + ((GObject)Input).id + "-prompt";
		Input.promptText = LanguagesManager.GetDesc(id);
		SendBtn = (UI_SendBtn)(object)((GComponent)this).GetChild("SendBtn");
	}
}
