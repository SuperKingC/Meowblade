using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_deleteBtn : GButton
{
	public Controller button;

	public GImage background;

	public GImage title;

	public const string URL = "ui://3rz8gv6cc3w3e";

	public static string Name = "UI_deleteBtn";

	public static string GetURL()
	{
		return "ui://3rz8gv6cc3w3e";
	}

	public static UI_deleteBtn CreateInstance()
	{
		return (UI_deleteBtn)(object)UIPackage.CreateObject("Friends", "deleteBtn");
	}

	public static UI_deleteBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_deleteBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GImage)((GComponent)this).GetChild("title");
	}
}
