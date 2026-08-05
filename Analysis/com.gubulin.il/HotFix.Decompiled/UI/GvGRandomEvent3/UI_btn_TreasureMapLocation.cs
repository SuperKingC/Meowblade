using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_btn_TreasureMapLocation : GButton
{
	public Controller button;

	public GImage n7;

	public GImage n8;

	public const string URL = "ui://p4ocf6q0dc6mb";

	public static string Name = "UI_btn_TreasureMapLocation";

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6mb";
	}

	public static UI_btn_TreasureMapLocation CreateInstance()
	{
		return (UI_btn_TreasureMapLocation)(object)UIPackage.CreateObject("GvGRandomEvent3", "btn_TreasureMapLocation");
	}

	public static UI_btn_TreasureMapLocation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TreasureMapLocation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6mb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
