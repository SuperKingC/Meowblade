using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_AddButton : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://hd2s9kukursm2t";

	public static string Name = "UI_AddButton";

	public static string GetURL()
	{
		return "ui://hd2s9kukursm2t";
	}

	public static UI_AddButton CreateInstance()
	{
		return (UI_AddButton)(object)UIPackage.CreateObject("GvGWorldMap2", "AddButton");
	}

	public static UI_AddButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukursm2t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
	}
}
