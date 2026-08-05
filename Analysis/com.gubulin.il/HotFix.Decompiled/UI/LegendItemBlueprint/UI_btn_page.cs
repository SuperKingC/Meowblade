using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_page : GButton
{
	public Controller button;

	public Controller Status;

	public GGraph n4;

	public GImage n3;

	public GImage n5;

	public GTextField n6;

	public GTextField n7;

	public const string URL = "ui://h09dvkcgaupt5ltfx";

	public static string Name = "UI_btn_page";

	public static string GetURL()
	{
		return "ui://h09dvkcgaupt5ltfx";
	}

	public static UI_btn_page CreateInstance()
	{
		return (UI_btn_page)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_page");
	}

	public static UI_btn_page CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_page).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgaupt5ltfx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://h09dvkcgaupt5ltfx".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://h09dvkcgaupt5ltfx".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
	}
}
