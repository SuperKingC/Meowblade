using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_Strategy : GButton
{
	public Controller isDown;

	public Controller CampId;

	public Controller isHide;

	public GLoader Icon;

	public GGraph hideIcon;

	public GImage n7;

	public GImage n8;

	public const string URL = "ui://hozu168rvb402q";

	public static string Name = "UI_btn_Strategy";

	public static string GetURL()
	{
		return "ui://hozu168rvb402q";
	}

	public static UI_btn_Strategy CreateInstance()
	{
		return (UI_btn_Strategy)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_Strategy");
	}

	public static UI_btn_Strategy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Strategy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rvb402q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isDown = ((GComponent)this).GetController("isDown");
		CampId = ((GComponent)this).GetController("CampId");
		isHide = ((GComponent)this).GetController("isHide");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		hideIcon = (GGraph)((GComponent)this).GetChild("hideIcon");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
