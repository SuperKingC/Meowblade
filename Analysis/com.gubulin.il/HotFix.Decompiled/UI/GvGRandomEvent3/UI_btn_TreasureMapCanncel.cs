using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_btn_TreasureMapCanncel : GButton
{
	public Controller button;

	public GImage n7;

	public const string URL = "ui://p4ocf6q0whk918";

	public static string Name = "UI_btn_TreasureMapCanncel";

	public static string GetURL()
	{
		return "ui://p4ocf6q0whk918";
	}

	public static UI_btn_TreasureMapCanncel CreateInstance()
	{
		return (UI_btn_TreasureMapCanncel)(object)UIPackage.CreateObject("GvGRandomEvent3", "btn_TreasureMapCanncel");
	}

	public static UI_btn_TreasureMapCanncel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TreasureMapCanncel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0whk918", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
