using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprintTemplate;

public class UI_com_CostContent : GComponent
{
	public GImage n1;

	public GTextField n2;

	public GTextField CostText;

	public const string URL = "ui://se4hok01wrnfc";

	public static string Name = "UI_com_CostContent";

	public static string GetURL()
	{
		return "ui://se4hok01wrnfc";
	}

	public static UI_com_CostContent CreateInstance()
	{
		return (UI_com_CostContent)(object)UIPackage.CreateObject("LegendItemBlueprintTemplate", "com_CostContent");
	}

	public static UI_com_CostContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CostContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnfc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://se4hok01wrnfc".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		CostText = (GTextField)((GComponent)this).GetChild("CostText");
	}
}
