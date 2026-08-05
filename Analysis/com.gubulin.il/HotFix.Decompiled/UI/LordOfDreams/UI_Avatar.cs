using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_Avatar : GButton
{
	public Controller button;

	public GImage n7;

	public UI_HeadPortrait HeadPortrait;

	public const string URL = "ui://0i520nzm121eo4d";

	public static string Name = "UI_Avatar";

	public static string GetURL()
	{
		return "ui://0i520nzm121eo4d";
	}

	public static UI_Avatar CreateInstance()
	{
		return (UI_Avatar)(object)UIPackage.CreateObject("LordOfDreams", "Avatar");
	}

	public static UI_Avatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Avatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm121eo4d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		HeadPortrait = (UI_HeadPortrait)(object)((GComponent)this).GetChild("HeadPortrait");
	}
}
