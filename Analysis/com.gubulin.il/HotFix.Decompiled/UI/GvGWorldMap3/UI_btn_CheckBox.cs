using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_CheckBox : GButton
{
	public Controller button;

	public GImage n142;

	public GImage n143;

	public const string URL = "ui://4eq8fgd2yew4f8";

	public static string Name = "UI_btn_CheckBox";

	public static string GetURL()
	{
		return "ui://4eq8fgd2yew4f8";
	}

	public static UI_btn_CheckBox CreateInstance()
	{
		return (UI_btn_CheckBox)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_CheckBox");
	}

	public static UI_btn_CheckBox CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CheckBox).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2yew4f8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n143 = (GImage)((GComponent)this).GetChild("n143");
	}
}
