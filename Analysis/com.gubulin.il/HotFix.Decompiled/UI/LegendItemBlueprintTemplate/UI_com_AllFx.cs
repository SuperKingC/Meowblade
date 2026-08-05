using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprintTemplate;

public class UI_com_AllFx : GComponent
{
	public GList Fx;

	public const string URL = "ui://se4hok01wrnf7";

	public static string Name = "UI_com_AllFx";

	public static string GetURL()
	{
		return "ui://se4hok01wrnf7";
	}

	public static UI_com_AllFx CreateInstance()
	{
		return (UI_com_AllFx)(object)UIPackage.CreateObject("LegendItemBlueprintTemplate", "com_AllFx");
	}

	public static UI_com_AllFx CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AllFx).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Fx = (GList)((GComponent)this).GetChild("Fx");
	}
}
