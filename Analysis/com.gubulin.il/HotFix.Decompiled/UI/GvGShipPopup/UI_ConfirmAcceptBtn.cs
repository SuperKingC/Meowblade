using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_ConfirmAcceptBtn : GButton
{
	public GImage n122;

	public GImage n123;

	public GImage n124;

	public const string URL = "ui://pwrbvhpvnbpu3t";

	public static string Name = "UI_ConfirmAcceptBtn";

	public static string GetURL()
	{
		return "ui://pwrbvhpvnbpu3t";
	}

	public static UI_ConfirmAcceptBtn CreateInstance()
	{
		return (UI_ConfirmAcceptBtn)(object)UIPackage.CreateObject("GvGShipPopup", "ConfirmAcceptBtn");
	}

	public static UI_ConfirmAcceptBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmAcceptBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvnbpu3t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n122 = (GImage)((GComponent)this).GetChild("n122");
		n123 = (GImage)((GComponent)this).GetChild("n123");
		n124 = (GImage)((GComponent)this).GetChild("n124");
	}
}
