using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_LevelCardPanel : GComponent
{
	public GGraph Mask;

	public UI_LevelCard Dailog;

	public const string URL = "ui://2eraz3j9j2ox10";

	public static string Name = "UI_LevelCardPanel";

	public static string GetURL()
	{
		return "ui://2eraz3j9j2ox10";
	}

	public static UI_LevelCardPanel CreateInstance()
	{
		return (UI_LevelCardPanel)(object)UIPackage.CreateObject("LegendItemDungeon", "LevelCardPanel");
	}

	public static UI_LevelCardPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelCardPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9j2ox10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dailog = (UI_LevelCard)(object)((GComponent)this).GetChild("Dailog");
	}
}
