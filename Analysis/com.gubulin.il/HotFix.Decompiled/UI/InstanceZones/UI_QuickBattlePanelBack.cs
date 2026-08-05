using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_QuickBattlePanelBack : GComponent
{
	public GGraph Mask;

	public const string URL = "ui://f4wr270rc5l26l";

	public static string Name = "UI_QuickBattlePanelBack";

	public static string GetURL()
	{
		return "ui://f4wr270rc5l26l";
	}

	public static UI_QuickBattlePanelBack CreateInstance()
	{
		return (UI_QuickBattlePanelBack)(object)UIPackage.CreateObject("InstanceZones", "QuickBattlePanelBack");
	}

	public static UI_QuickBattlePanelBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QuickBattlePanelBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rc5l26l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
	}
}
