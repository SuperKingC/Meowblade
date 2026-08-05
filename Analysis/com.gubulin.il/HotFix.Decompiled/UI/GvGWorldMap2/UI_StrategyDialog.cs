using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_StrategyDialog : GComponent
{
	public GGraph n0;

	public GList Selections;

	public const string URL = "ui://hd2s9kukcqf74f";

	public static string Name = "UI_StrategyDialog";

	public static string GetURL()
	{
		return "ui://hd2s9kukcqf74f";
	}

	public static UI_StrategyDialog CreateInstance()
	{
		return (UI_StrategyDialog)(object)UIPackage.CreateObject("GvGWorldMap2", "StrategyDialog");
	}

	public static UI_StrategyDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StrategyDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukcqf74f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		Selections = (GList)((GComponent)this).GetChild("Selections");
	}
}
