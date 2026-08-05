using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_CampPlayer : GComponent
{
	public Controller IsMe;

	public GComponent ProfileDisplay;

	public UI_com_Component3 n7;

	public GImage n2;

	public GTextField ShipNumber;

	public GLoader n3;

	public const string URL = "ui://4eq8fgd2qf7c7w";

	public static string Name = "UI_com_CampPlayer";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qf7c7w";
	}

	public static UI_com_CampPlayer CreateInstance()
	{
		return (UI_com_CampPlayer)(object)UIPackage.CreateObject("GvGWorldMap3", "com_CampPlayer");
	}

	public static UI_com_CampPlayer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampPlayer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qf7c7w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsMe = ((GComponent)this).GetController("IsMe");
		ProfileDisplay = (GComponent)((GComponent)this).GetChild("ProfileDisplay");
		n7 = (UI_com_Component3)(object)((GComponent)this).GetChild("n7");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		ShipNumber = (GTextField)((GComponent)this).GetChild("ShipNumber");
		n3 = (GLoader)((GComponent)this).GetChild("n3");
	}
}
