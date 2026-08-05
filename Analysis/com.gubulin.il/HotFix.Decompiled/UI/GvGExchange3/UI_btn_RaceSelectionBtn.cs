using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_RaceSelectionBtn : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n130;

	public GImage n131;

	public GImage n132;

	public GComponent RaceType;

	public const string URL = "ui://tt2iq07ofnl225";

	public static string Name = "UI_btn_RaceSelectionBtn";

	public static string GetURL()
	{
		return "ui://tt2iq07ofnl225";
	}

	public static UI_btn_RaceSelectionBtn CreateInstance()
	{
		return (UI_btn_RaceSelectionBtn)(object)UIPackage.CreateObject("GvGExchange3", "btn_RaceSelectionBtn");
	}

	public static UI_btn_RaceSelectionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RaceSelectionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07ofnl225", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n130 = (GImage)((GComponent)this).GetChild("n130");
		n131 = (GImage)((GComponent)this).GetChild("n131");
		n132 = (GImage)((GComponent)this).GetChild("n132");
		RaceType = (GComponent)((GComponent)this).GetChild("RaceType");
	}
}
