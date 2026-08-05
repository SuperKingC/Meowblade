using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_Medal : GComponent
{
	public GLoader MedalIcon;

	public GTextField MedalLevel;

	public const string URL = "ui://kt6rg65owckov4m0";

	public static string Name = "UI_com_Medal";

	public static string GetURL()
	{
		return "ui://kt6rg65owckov4m0";
	}

	public static UI_com_Medal CreateInstance()
	{
		return (UI_com_Medal)(object)UIPackage.CreateObject("PublicResources", "com_Medal");
	}

	public static UI_com_Medal CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Medal).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65owckov4m0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		MedalIcon = (GLoader)((GComponent)this).GetChild("MedalIcon");
		MedalLevel = (GTextField)((GComponent)this).GetChild("MedalLevel");
	}
}
