using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_DoNotShowAgain : GButton
{
	public Controller button;

	public GGraph n7;

	public GImage bg;

	public GImage n5;

	public GTextField n8;

	public const string URL = "ui://fvc33k3gwzfo39";

	public static string Name = "UI_btn_DoNotShowAgain";

	public static string GetURL()
	{
		return "ui://fvc33k3gwzfo39";
	}

	public static UI_btn_DoNotShowAgain CreateInstance()
	{
		return (UI_btn_DoNotShowAgain)(object)UIPackage.CreateObject("GVGStore", "btn_DoNotShowAgain");
	}

	public static UI_btn_DoNotShowAgain CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_DoNotShowAgain).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gwzfo39", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://fvc33k3gwzfo39".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
	}
}
