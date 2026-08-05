using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_ProductionNumStage : GComponent
{
	public GGraph line0;

	public GGraph line1;

	public const string URL = "ui://kt6rg65omol0ie";

	public static string Name = "UI_ProductionNumStage";

	public static string GetURL()
	{
		return "ui://kt6rg65omol0ie";
	}

	public static UI_ProductionNumStage CreateInstance()
	{
		return (UI_ProductionNumStage)(object)UIPackage.CreateObject("PublicResources", "ProductionNumStage");
	}

	public static UI_ProductionNumStage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProductionNumStage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omol0ie", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		line0 = (GGraph)((GComponent)this).GetChild("line0");
		line1 = (GGraph)((GComponent)this).GetChild("line1");
	}
}
