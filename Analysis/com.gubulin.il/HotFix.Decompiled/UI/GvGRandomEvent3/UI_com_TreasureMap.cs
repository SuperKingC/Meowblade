using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_TreasureMap : GComponent
{
	public UI_dec_ScrollBg n4;

	public UI_dec_TitleText n7;

	public GImage n5;

	public GImage n6;

	public UI_btn_TreasureMapCanncel CancelEvent;

	public UI_btn_TreasureMapLocation Location;

	public GTextField Desc;

	public GButton Close;

	public Transition t0;

	public const string URL = "ui://p4ocf6q0dc6m9";

	public static string Name = "UI_com_TreasureMap";

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6m9";
	}

	public static UI_com_TreasureMap CreateInstance()
	{
		return (UI_com_TreasureMap)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_TreasureMap");
	}

	public static UI_com_TreasureMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TreasureMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6m9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (UI_dec_ScrollBg)(object)((GComponent)this).GetChild("n4");
		n7 = (UI_dec_TitleText)(object)((GComponent)this).GetChild("n7");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		CancelEvent = (UI_btn_TreasureMapCanncel)(object)((GComponent)this).GetChild("CancelEvent");
		Location = (UI_btn_TreasureMapLocation)(object)((GComponent)this).GetChild("Location");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		Close = (GButton)((GComponent)this).GetChild("Close");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
