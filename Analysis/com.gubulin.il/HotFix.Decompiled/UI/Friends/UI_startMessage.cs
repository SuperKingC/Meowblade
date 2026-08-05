using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_startMessage : GButton
{
	public Controller button;

	public GGraph n4;

	public GImage n3;

	public const string URL = "ui://3rz8gv6cewnakg";

	public static string Name = "UI_startMessage";

	public static string GetURL()
	{
		return "ui://3rz8gv6cewnakg";
	}

	public static UI_startMessage CreateInstance()
	{
		return (UI_startMessage)(object)UIPackage.CreateObject("Friends", "startMessage");
	}

	public static UI_startMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_startMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cewnakg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
