using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_SwitchShipMode : GButton
{
	public Controller button;

	public GImage n14;

	public GImage n16;

	public GImage n17;

	public GImage n15;

	public GImage n18;

	public const string URL = "ui://ebc4ciwrts801z";

	public static string Name = "UI_btn_SwitchShipMode";

	public static string GetURL()
	{
		return "ui://ebc4ciwrts801z";
	}

	public static UI_btn_SwitchShipMode CreateInstance()
	{
		return (UI_btn_SwitchShipMode)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_SwitchShipMode");
	}

	public static UI_btn_SwitchShipMode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SwitchShipMode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrts801z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n18 = (GImage)((GComponent)this).GetChild("n18");
	}
}
