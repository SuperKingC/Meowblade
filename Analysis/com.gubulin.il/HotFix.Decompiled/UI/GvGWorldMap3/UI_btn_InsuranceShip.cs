using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_InsuranceShip : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n3;

	public GLoader ShipIcon;

	public GTextField ShipName;

	public const string URL = "ui://4eq8fgd2eo52b6sde";

	public static string Name = "UI_btn_InsuranceShip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2eo52b6sde";
	}

	public static UI_btn_InsuranceShip CreateInstance()
	{
		return (UI_btn_InsuranceShip)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_InsuranceShip");
	}

	public static UI_btn_InsuranceShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_InsuranceShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2eo52b6sde", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		ShipIcon = (GLoader)((GComponent)this).GetChild("ShipIcon");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
	}
}
