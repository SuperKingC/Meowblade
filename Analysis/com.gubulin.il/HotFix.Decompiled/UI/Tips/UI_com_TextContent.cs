using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_com_TextContent : GComponent
{
	public GImage tipTextBack;

	public GTextField tipText;

	public const string URL = "ui://47lbpgx9gxl45ltdb";

	public static string Name = "UI_com_TextContent";

	public static string GetURL()
	{
		return "ui://47lbpgx9gxl45ltdb";
	}

	public static UI_com_TextContent CreateInstance()
	{
		return (UI_com_TextContent)(object)UIPackage.CreateObject("Tips", "com_TextContent");
	}

	public static UI_com_TextContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TextContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9gxl45ltdb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		tipTextBack = (GImage)((GComponent)this).GetChild("tipTextBack");
		tipText = (GTextField)((GComponent)this).GetChild("tipText");
		string id = "ui://47lbpgx9gxl45ltdb".Replace("ui://", "") + "-" + ((GObject)tipText).id;
		((GObject)tipText).text = LanguagesManager.GetDesc(id);
	}
}
