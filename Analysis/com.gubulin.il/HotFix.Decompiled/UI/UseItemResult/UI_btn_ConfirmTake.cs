using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_btn_ConfirmTake : GButton
{
	public Controller button;

	public GImage back;

	public GTextField title;

	public GImage n5;

	public const string URL = "ui://800w3r8rmzqrc";

	public static string Name = "UI_btn_ConfirmTake";

	public static string GetURL()
	{
		return "ui://800w3r8rmzqrc";
	}

	public static UI_btn_ConfirmTake CreateInstance()
	{
		return (UI_btn_ConfirmTake)(object)UIPackage.CreateObject("UseItemResult", "btn_ConfirmTake");
	}

	public static UI_btn_ConfirmTake CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmTake).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rmzqrc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://800w3r8rmzqrc".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
