using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_Fillup : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField title;

	public const string URL = "ui://u6x0b1gnsvf66t";

	public static string Name = "UI_btn_Fillup";

	public static string GetURL()
	{
		return "ui://u6x0b1gnsvf66t";
	}

	public static UI_btn_Fillup CreateInstance()
	{
		return (UI_btn_Fillup)(object)UIPackage.CreateObject("GvGShipDetail", "btn_Fillup");
	}

	public static UI_btn_Fillup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Fillup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnsvf66t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://u6x0b1gnsvf66t".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
