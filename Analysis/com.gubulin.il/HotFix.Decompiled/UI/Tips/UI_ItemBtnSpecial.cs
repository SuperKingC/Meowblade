using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ItemBtnSpecial : GButton
{
	public Controller button;

	public Controller type;

	public GImage n10;

	public GImage n8;

	public GImage n9;

	public UI_TakeItemContent Content;

	public UI_btn_01 helpBtn;

	public Transition t0;

	public const string URL = "ui://47lbpgx9otto3c";

	public static string Name = "UI_ItemBtnSpecial";

	public static string GetURL()
	{
		return "ui://47lbpgx9otto3c";
	}

	public static UI_ItemBtnSpecial CreateInstance()
	{
		return (UI_ItemBtnSpecial)(object)UIPackage.CreateObject("Tips", "ItemBtnSpecial");
	}

	public static UI_ItemBtnSpecial CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ItemBtnSpecial).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9otto3c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		type = ((GComponent)this).GetController("type");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		Content = (UI_TakeItemContent)(object)((GComponent)this).GetChild("Content");
		helpBtn = (UI_btn_01)(object)((GComponent)this).GetChild("helpBtn");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
