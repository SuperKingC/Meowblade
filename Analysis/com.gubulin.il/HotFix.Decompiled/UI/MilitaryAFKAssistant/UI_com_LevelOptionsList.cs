using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_LevelOptionsList : GComponent
{
	public Controller enabled;

	public GImage n3;

	public GList LevelOptions;

	public GImage n4;

	public GTextField disableTips;

	public const string URL = "ui://8x5gc8j2ihxkv4v1";

	public static string Name = "UI_com_LevelOptionsList";

	public static string GetURL()
	{
		return "ui://8x5gc8j2ihxkv4v1";
	}

	public static UI_com_LevelOptionsList CreateInstance()
	{
		return (UI_com_LevelOptionsList)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_LevelOptionsList");
	}

	public static UI_com_LevelOptionsList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelOptionsList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2ihxkv4v1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		enabled = ((GComponent)this).GetController("enabled");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		LevelOptions = (GList)((GComponent)this).GetChild("LevelOptions");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		disableTips = (GTextField)((GComponent)this).GetChild("disableTips");
	}
}
