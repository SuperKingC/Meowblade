using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_PropSelectionBtn : GButton
{
	public Controller button;

	public GImage n141;

	public GTextField PropName;

	public GImage n143;

	public GImage n144;

	public const string URL = "ui://tt2iq07ofnl223";

	public static string Name = "UI_btn_PropSelectionBtn";

	public static string GetURL()
	{
		return "ui://tt2iq07ofnl223";
	}

	public static UI_btn_PropSelectionBtn CreateInstance()
	{
		return (UI_btn_PropSelectionBtn)(object)UIPackage.CreateObject("GvGExchange3", "btn_PropSelectionBtn");
	}

	public static UI_btn_PropSelectionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PropSelectionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07ofnl223", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n141 = (GImage)((GComponent)this).GetChild("n141");
		PropName = (GTextField)((GComponent)this).GetChild("PropName");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		n144 = (GImage)((GComponent)this).GetChild("n144");
	}
}
