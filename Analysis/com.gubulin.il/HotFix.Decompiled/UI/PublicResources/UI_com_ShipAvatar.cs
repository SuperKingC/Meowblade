using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_ShipAvatar : GComponent
{
	public Controller CampId;

	public GLoader Icon;

	public UI_com_DefaultAvatar DefaultAvatar;

	public UI_com_HeadPortrait HeadPortrait;

	public const string URL = "ui://kt6rg65oigs2v4ns";

	public static string Name = "UI_com_ShipAvatar";

	public static string GetURL()
	{
		return "ui://kt6rg65oigs2v4ns";
	}

	public static UI_com_ShipAvatar CreateInstance()
	{
		return (UI_com_ShipAvatar)(object)UIPackage.CreateObject("PublicResources", "com_ShipAvatar");
	}

	public static UI_com_ShipAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oigs2v4ns", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		DefaultAvatar = (UI_com_DefaultAvatar)(object)((GComponent)this).GetChild("DefaultAvatar");
		HeadPortrait = (UI_com_HeadPortrait)(object)((GComponent)this).GetChild("HeadPortrait");
	}
}
