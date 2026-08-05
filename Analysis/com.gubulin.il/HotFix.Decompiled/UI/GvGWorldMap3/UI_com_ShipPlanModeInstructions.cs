using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ShipPlanModeInstructions : GComponent
{
	public GImage n0;

	public GTextField n2;

	public GTextField Tip;

	public const string URL = "ui://4eq8fgd2102lb6sd8";

	public static string Name = "UI_com_ShipPlanModeInstructions";

	public static string GetURL()
	{
		return "ui://4eq8fgd2102lb6sd8";
	}

	public static UI_com_ShipPlanModeInstructions CreateInstance()
	{
		return (UI_com_ShipPlanModeInstructions)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ShipPlanModeInstructions");
	}

	public static UI_com_ShipPlanModeInstructions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipPlanModeInstructions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2102lb6sd8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://4eq8fgd2102lb6sd8".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id2 = "ui://4eq8fgd2102lb6sd8".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id2);
	}
}
