using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_LevelOptionTip : GComponent
{
	public GImage n4;

	public GTextField tipContent;

	public const string URL = "ui://8x5gc8j2ihxkv4v2";

	public static string Name = "UI_com_LevelOptionTip";

	public static string GetURL()
	{
		return "ui://8x5gc8j2ihxkv4v2";
	}

	public static UI_com_LevelOptionTip CreateInstance()
	{
		return (UI_com_LevelOptionTip)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_LevelOptionTip");
	}

	public static UI_com_LevelOptionTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelOptionTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2ihxkv4v2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		tipContent = (GTextField)((GComponent)this).GetChild("tipContent");
	}
}
