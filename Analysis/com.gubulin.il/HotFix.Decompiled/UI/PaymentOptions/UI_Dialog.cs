using FairyGUI;
using FairyGUI.Utils;

namespace UI.PaymentOptions;

public class UI_Dialog : GComponent
{
	public GImage Back;

	public UI_AlipayBtn alipayBtn;

	public UI_WeChatPayBtn weChatPayBtn;

	public GImage n5;

	public const string URL = "ui://jy8z3hj6gpwa1";

	public static string Name = "UI_Dialog";

	public static string GetURL()
	{
		return "ui://jy8z3hj6gpwa1";
	}

	public static UI_Dialog CreateInstance()
	{
		return (UI_Dialog)(object)UIPackage.CreateObject("PaymentOptions", "Dialog");
	}

	public static UI_Dialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Dialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jy8z3hj6gpwa1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Back = (GImage)((GComponent)this).GetChild("Back");
		alipayBtn = (UI_AlipayBtn)(object)((GComponent)this).GetChild("alipayBtn");
		weChatPayBtn = (UI_WeChatPayBtn)(object)((GComponent)this).GetChild("weChatPayBtn");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
