using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_FastFillup : GButton
{
	public Controller button;

	public GImage n6;

	public GTextField title;

	public const string URL = "ui://u6x0b1gnsvf66v";

	public static string Name = "UI_btn_FastFillup";

	public static string GetURL()
	{
		return "ui://u6x0b1gnsvf66v";
	}

	public static UI_btn_FastFillup CreateInstance()
	{
		return (UI_btn_FastFillup)(object)UIPackage.CreateObject("GvGShipDetail", "btn_FastFillup");
	}

	public static UI_btn_FastFillup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FastFillup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnsvf66v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://u6x0b1gnsvf66v".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
