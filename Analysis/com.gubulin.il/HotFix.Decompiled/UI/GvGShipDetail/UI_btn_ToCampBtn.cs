using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_ToCampBtn : GButton
{
	public Controller button;

	public GImage n0;

	public GImage n1;

	public const string URL = "ui://u6x0b1gnzpu41k";

	public static string Name = "UI_btn_ToCampBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnzpu41k";
	}

	public static UI_btn_ToCampBtn CreateInstance()
	{
		return (UI_btn_ToCampBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_ToCampBtn");
	}

	public static UI_btn_ToCampBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ToCampBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnzpu41k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
