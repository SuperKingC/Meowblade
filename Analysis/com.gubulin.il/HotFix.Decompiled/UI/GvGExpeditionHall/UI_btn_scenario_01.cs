using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_scenario_01 : GButton
{
	public Controller button;

	public GGraph n0;

	public GGraph n2;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://k19peou7gshy6p8j";

	public static string Name = "UI_btn_scenario_01";

	public static string GetURL()
	{
		return "ui://k19peou7gshy6p8j";
	}

	public static UI_btn_scenario_01 CreateInstance()
	{
		return (UI_btn_scenario_01)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_scenario_01");
	}

	public static UI_btn_scenario_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_scenario_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7gshy6p8j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
