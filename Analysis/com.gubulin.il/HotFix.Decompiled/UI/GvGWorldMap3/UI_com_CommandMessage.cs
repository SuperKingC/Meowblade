using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_CommandMessage : GComponent
{
	public GTextField Text1;

	public GTextField Text2;

	public const string URL = "ui://4eq8fgd2jxsodt";

	public static string Name = "UI_com_CommandMessage";

	public static string GetURL()
	{
		return "ui://4eq8fgd2jxsodt";
	}

	public static UI_com_CommandMessage CreateInstance()
	{
		return (UI_com_CommandMessage)(object)UIPackage.CreateObject("GvGWorldMap3", "com_CommandMessage");
	}

	public static UI_com_CommandMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CommandMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jxsodt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Text1 = (GTextField)((GComponent)this).GetChild("Text1");
		Text2 = (GTextField)((GComponent)this).GetChild("Text2");
	}
}
