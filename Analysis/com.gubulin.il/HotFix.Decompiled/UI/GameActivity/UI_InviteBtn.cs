using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_InviteBtn : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://29q48tv6hkkt24";

	public static string Name = "UI_InviteBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6hkkt24";
	}

	public static UI_InviteBtn CreateInstance()
	{
		return (UI_InviteBtn)(object)UIPackage.CreateObject("GameActivity", "InviteBtn");
	}

	public static UI_InviteBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InviteBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hkkt24", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
