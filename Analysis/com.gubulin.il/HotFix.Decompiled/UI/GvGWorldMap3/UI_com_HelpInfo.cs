using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_HelpInfo : GComponent
{
	public GImage n1;

	public GTextField n7;

	public GImage n8;

	public const string URL = "ui://4eq8fgd2zit4ag";

	public static string Name = "UI_com_HelpInfo";

	public static string GetURL()
	{
		return "ui://4eq8fgd2zit4ag";
	}

	public static UI_com_HelpInfo CreateInstance()
	{
		return (UI_com_HelpInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_HelpInfo");
	}

	public static UI_com_HelpInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HelpInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2zit4ag", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://4eq8fgd2zit4ag".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
