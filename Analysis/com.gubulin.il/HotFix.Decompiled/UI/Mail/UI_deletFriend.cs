using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_deletFriend : GButton
{
	public Controller button;

	public GGraph n4;

	public GImage n5;

	public const string URL = "ui://edr57v33gx8u44";

	public static string Name = "UI_deletFriend";

	public static string GetURL()
	{
		return "ui://edr57v33gx8u44";
	}

	public static UI_deletFriend CreateInstance()
	{
		return (UI_deletFriend)(object)UIPackage.CreateObject("Mail", "deletFriend");
	}

	public static UI_deletFriend CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_deletFriend).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33gx8u44", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
