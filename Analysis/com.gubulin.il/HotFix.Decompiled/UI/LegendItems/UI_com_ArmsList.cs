using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItems;

public class UI_com_ArmsList : GComponent
{
	public Controller Status;

	public GList armsList;

	public const string URL = "ui://l6qef30pv5cz4";

	public static string Name = "UI_com_ArmsList";

	public static string GetURL()
	{
		return "ui://l6qef30pv5cz4";
	}

	public static UI_com_ArmsList CreateInstance()
	{
		return (UI_com_ArmsList)(object)UIPackage.CreateObject("LegendItems", "com_ArmsList");
	}

	public static UI_com_ArmsList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ArmsList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pv5cz4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		armsList = (GList)((GComponent)this).GetChild("armsList");
	}
}
