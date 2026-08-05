using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ExclamationMarkDialog : GComponent
{
	public GImage back;

	public GRichTextField title;

	public const string URL = "ui://4eq8fgd2bbvd4y";

	public static string Name = "UI_com_ExclamationMarkDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2bbvd4y";
	}

	public static UI_com_ExclamationMarkDialog CreateInstance()
	{
		return (UI_com_ExclamationMarkDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ExclamationMarkDialog");
	}

	public static UI_com_ExclamationMarkDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ExclamationMarkDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bbvd4y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GRichTextField)((GComponent)this).GetChild("title");
	}
}
