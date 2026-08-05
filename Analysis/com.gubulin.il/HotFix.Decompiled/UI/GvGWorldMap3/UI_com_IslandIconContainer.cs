using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_IslandIconContainer : GComponent
{
	public const string URL = "ui://4eq8fgd29ro9s56";

	public static string Name = "UI_com_IslandIconContainer";

	public static string GetURL()
	{
		return "ui://4eq8fgd29ro9s56";
	}

	public static UI_com_IslandIconContainer CreateInstance()
	{
		return (UI_com_IslandIconContainer)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandIconContainer");
	}

	public static UI_com_IslandIconContainer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandIconContainer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd29ro9s56", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
