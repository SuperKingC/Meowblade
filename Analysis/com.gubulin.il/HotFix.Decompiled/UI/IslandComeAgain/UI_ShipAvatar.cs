using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ShipAvatar : GComponent
{
	public Controller CampId;

	public Controller IsMe;

	public GLoader Icon;

	public UI_HeadPortrait HeadPortrait;

	public UI_Component3 n2;

	public GTextField UserName;

	public const string URL = "ui://k2sprg26oc3d90";

	public static string Name = "UI_ShipAvatar";

	public static string GetURL()
	{
		return "ui://k2sprg26oc3d90";
	}

	public static UI_ShipAvatar CreateInstance()
	{
		return (UI_ShipAvatar)(object)UIPackage.CreateObject("IslandComeAgain", "ShipAvatar");
	}

	public static UI_ShipAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShipAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26oc3d90", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		IsMe = ((GComponent)this).GetController("IsMe");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		HeadPortrait = (UI_HeadPortrait)(object)((GComponent)this).GetChild("HeadPortrait");
		n2 = (UI_Component3)(object)((GComponent)this).GetChild("n2");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
	}
}
