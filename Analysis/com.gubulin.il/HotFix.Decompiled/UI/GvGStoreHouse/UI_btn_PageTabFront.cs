using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGStoreHouse;

public class UI_btn_PageTabFront : GButton
{
	public Controller button;

	public GImage n2;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://6ym14r0dk58y5";

	public static string Name = "UI_btn_PageTabFront";

	public static string GetURL()
	{
		return "ui://6ym14r0dk58y5";
	}

	public static UI_btn_PageTabFront CreateInstance()
	{
		return (UI_btn_PageTabFront)(object)UIPackage.CreateObject("GvGStoreHouse", "btn_PageTabFront");
	}

	public static UI_btn_PageTabFront CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PageTabFront).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://6ym14r0dk58y5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://6ym14r0dk58y5".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
