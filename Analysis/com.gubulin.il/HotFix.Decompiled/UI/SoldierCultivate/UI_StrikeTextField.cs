using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_StrikeTextField : GComponent
{
	public GTextField content;

	public GGraph strikeLine;

	public const string URL = "ui://7dantnbin60rtc6";

	public static string Name = "UI_StrikeTextField";

	public static string GetURL()
	{
		return "ui://7dantnbin60rtc6";
	}

	public static UI_StrikeTextField CreateInstance()
	{
		return (UI_StrikeTextField)(object)UIPackage.CreateObject("SoldierCultivate", "StrikeTextField");
	}

	public static UI_StrikeTextField CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StrikeTextField).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbin60rtc6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		content = (GTextField)((GComponent)this).GetChild("content");
		strikeLine = (GGraph)((GComponent)this).GetChild("strikeLine");
	}
}
