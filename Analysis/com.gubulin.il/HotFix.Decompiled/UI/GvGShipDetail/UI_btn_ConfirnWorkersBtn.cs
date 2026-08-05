using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_ConfirnWorkersBtn : GButton
{
	public GImage n102;

	public GImage n103;

	public const string URL = "ui://u6x0b1gnw9n032";

	public static string Name = "UI_btn_ConfirnWorkersBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnw9n032";
	}

	public static UI_btn_ConfirnWorkersBtn CreateInstance()
	{
		return (UI_btn_ConfirnWorkersBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_ConfirnWorkersBtn");
	}

	public static UI_btn_ConfirnWorkersBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirnWorkersBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnw9n032", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n102 = (GImage)((GComponent)this).GetChild("n102");
		n103 = (GImage)((GComponent)this).GetChild("n103");
	}
}
