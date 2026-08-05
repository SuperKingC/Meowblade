using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_btn_Receive : GButton
{
	public Controller button;

	public Controller RedDot;

	public GImage n8;

	public GLoader icon;

	public GImage n10;

	public const string URL = "ui://pobej4q7mo53h";

	public static string Name = "UI_btn_Receive";

	public static string GetURL()
	{
		return "ui://pobej4q7mo53h";
	}

	public static UI_btn_Receive CreateInstance()
	{
		return (UI_btn_Receive)(object)UIPackage.CreateObject("GvG3SupplyDepot", "btn_Receive");
	}

	public static UI_btn_Receive CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Receive).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mo53h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RedDot = ((GComponent)this).GetController("RedDot");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
