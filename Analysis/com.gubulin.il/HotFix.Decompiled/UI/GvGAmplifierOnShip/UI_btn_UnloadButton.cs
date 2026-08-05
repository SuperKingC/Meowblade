using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_btn_UnloadButton : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://pwlamcyxw71h11";

	public static string Name = "UI_btn_UnloadButton";

	public static string GetURL()
	{
		return "ui://pwlamcyxw71h11";
	}

	public static UI_btn_UnloadButton CreateInstance()
	{
		return (UI_btn_UnloadButton)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "btn_UnloadButton");
	}

	public static UI_btn_UnloadButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_UnloadButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxw71h11", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
