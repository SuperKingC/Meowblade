using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_IslandIcon : GComponent
{
	public Controller IsLastStep;

	public Controller Camp;

	public GLoader IslandIcon;

	public GImage n9;

	public const string URL = "ui://4eq8fgd2qtz69x";

	public static string Name = "UI_IslandIcon";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qtz69x";
	}

	public static UI_IslandIcon CreateInstance()
	{
		return (UI_IslandIcon)(object)UIPackage.CreateObject("GvGWorldMap3", "IslandIcon");
	}

	public static UI_IslandIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qtz69x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsLastStep = ((GComponent)this).GetController("IsLastStep");
		Camp = ((GComponent)this).GetController("Camp");
		IslandIcon = (GLoader)((GComponent)this).GetChild("IslandIcon");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
