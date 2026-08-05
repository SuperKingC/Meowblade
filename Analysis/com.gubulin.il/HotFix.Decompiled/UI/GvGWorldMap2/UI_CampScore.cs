using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_CampScore : GComponent
{
	public GImage n2;

	public GList List;

	public const string URL = "ui://hd2s9kukt8zg4e";

	public static string Name = "UI_CampScore";

	public static string GetURL()
	{
		return "ui://hd2s9kukt8zg4e";
	}

	public static UI_CampScore CreateInstance()
	{
		return (UI_CampScore)(object)UIPackage.CreateObject("GvGWorldMap2", "CampScore");
	}

	public static UI_CampScore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CampScore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukt8zg4e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		List = (GList)((GComponent)this).GetChild("List");
	}
}
