using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_ProfileDisplayCommand : GComponent
{
	public GList Medals;

	public UI_com_ShipAvatar Avatar;

	public GTextField PlayerName;

	public const string URL = "ui://kt6rg65owckov4lz";

	public static string Name = "UI_com_ProfileDisplayCommand";

	public static string GetURL()
	{
		return "ui://kt6rg65owckov4lz";
	}

	public static UI_com_ProfileDisplayCommand CreateInstance()
	{
		return (UI_com_ProfileDisplayCommand)(object)UIPackage.CreateObject("PublicResources", "com_ProfileDisplayCommand");
	}

	public static UI_com_ProfileDisplayCommand CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProfileDisplayCommand).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65owckov4lz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Medals = (GList)((GComponent)this).GetChild("Medals");
		Avatar = (UI_com_ShipAvatar)(object)((GComponent)this).GetChild("Avatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
	}
}
