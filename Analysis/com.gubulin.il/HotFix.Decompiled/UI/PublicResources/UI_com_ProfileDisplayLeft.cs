using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_ProfileDisplayLeft : GComponent
{
	public Controller Style;

	public GList Medals;

	public UI_com_ShipAvatar Avatar;

	public GTextField PlayerName;

	public const string URL = "ui://kt6rg65oigs2v4nx";

	public static string Name = "UI_com_ProfileDisplayLeft";

	public static string GetURL()
	{
		return "ui://kt6rg65oigs2v4nx";
	}

	public static UI_com_ProfileDisplayLeft CreateInstance()
	{
		return (UI_com_ProfileDisplayLeft)(object)UIPackage.CreateObject("PublicResources", "com_ProfileDisplayLeft");
	}

	public static UI_com_ProfileDisplayLeft CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProfileDisplayLeft).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oigs2v4nx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Style = ((GComponent)this).GetController("Style");
		Medals = (GList)((GComponent)this).GetChild("Medals");
		Avatar = (UI_com_ShipAvatar)(object)((GComponent)this).GetChild("Avatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
	}
}
