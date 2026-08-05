using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_Calendar : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n3;

	public GTextField Date;

	public GImage redPoint;

	public const string URL = "ui://hozu168rk7me4z";

	public static string Name = "UI_btn_Calendar";

	public static string GetURL()
	{
		return "ui://hozu168rk7me4z";
	}

	public static UI_btn_Calendar CreateInstance()
	{
		return (UI_btn_Calendar)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_Calendar");
	}

	public static UI_btn_Calendar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Calendar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rk7me4z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Date = (GTextField)((GComponent)this).GetChild("Date");
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
	}
}
