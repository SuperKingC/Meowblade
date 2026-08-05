using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_btn_CheckBox : GButton
{
	public Controller button;

	public GImage n142;

	public GImage n143;

	public const string URL = "ui://pwrbvhpvmtfp7j";

	public static string Name = "UI_btn_CheckBox";

	public static string GetURL()
	{
		return "ui://pwrbvhpvmtfp7j";
	}

	public static UI_btn_CheckBox CreateInstance()
	{
		return (UI_btn_CheckBox)(object)UIPackage.CreateObject("GvGShipPopup", "btn_CheckBox");
	}

	public static UI_btn_CheckBox CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CheckBox).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvmtfp7j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n143 = (GImage)((GComponent)this).GetChild("n143");
	}
}
