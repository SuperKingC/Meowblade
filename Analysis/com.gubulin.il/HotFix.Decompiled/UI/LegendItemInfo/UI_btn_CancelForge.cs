using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemInfo;

public class UI_btn_CancelForge : GButton
{
	public Controller button;

	public GImage n8;

	public GTextField Title;

	public const string URL = "ui://lzvt5p2vaz6vg";

	public static string Name = "UI_btn_CancelForge";

	public static string GetURL()
	{
		return "ui://lzvt5p2vaz6vg";
	}

	public static UI_btn_CancelForge CreateInstance()
	{
		return (UI_btn_CancelForge)(object)UIPackage.CreateObject("LegendItemInfo", "btn_CancelForge");
	}

	public static UI_btn_CancelForge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CancelForge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vaz6vg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://lzvt5p2vaz6vg".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}
}
