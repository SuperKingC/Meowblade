using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_btn_Increase : GButton
{
	public Controller button;

	public GImage n8;

	public GLoader icon;

	public const string URL = "ui://pobej4q7uadoa";

	public static string Name = "UI_btn_Increase";

	public static string GetURL()
	{
		return "ui://pobej4q7uadoa";
	}

	public static UI_btn_Increase CreateInstance()
	{
		return (UI_btn_Increase)(object)UIPackage.CreateObject("GvG3SupplyDepot", "btn_Increase");
	}

	public static UI_btn_Increase CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Increase).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7uadoa", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
