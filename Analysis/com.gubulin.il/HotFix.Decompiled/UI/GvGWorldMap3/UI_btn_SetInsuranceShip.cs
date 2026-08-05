using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_SetInsuranceShip : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://4eq8fgd2aibkb6sdr";

	public static string Name = "UI_btn_SetInsuranceShip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2aibkb6sdr";
	}

	public static UI_btn_SetInsuranceShip CreateInstance()
	{
		return (UI_btn_SetInsuranceShip)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_SetInsuranceShip");
	}

	public static UI_btn_SetInsuranceShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SetInsuranceShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2aibkb6sdr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
