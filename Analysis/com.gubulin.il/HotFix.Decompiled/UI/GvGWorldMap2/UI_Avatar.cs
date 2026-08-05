using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_Avatar : GComponent
{
	public Controller CampId;

	public GLoader Icon;

	public UI_HeadPortrait HeadPortrait;

	public const string URL = "ui://hd2s9kukfu2634";

	public static string Name = "UI_Avatar";

	public static string GetURL()
	{
		return "ui://hd2s9kukfu2634";
	}

	public static UI_Avatar CreateInstance()
	{
		return (UI_Avatar)(object)UIPackage.CreateObject("GvGWorldMap2", "Avatar");
	}

	public static UI_Avatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Avatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukfu2634", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		HeadPortrait = (UI_HeadPortrait)(object)((GComponent)this).GetChild("HeadPortrait");
	}
}
