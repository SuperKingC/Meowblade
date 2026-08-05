using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_IslandBuffIcon : GComponent
{
	public GImage n3;

	public GLoader Icon;

	public const string URL = "ui://kt6rg65onewqfn";

	public static string Name = "UI_com_IslandBuffIcon";

	public static string GetURL()
	{
		return "ui://kt6rg65onewqfn";
	}

	public static UI_com_IslandBuffIcon CreateInstance()
	{
		return (UI_com_IslandBuffIcon)(object)UIPackage.CreateObject("PublicResources", "com_IslandBuffIcon");
	}

	public static UI_com_IslandBuffIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandBuffIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65onewqfn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
	}
}
