using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_DontShowBtn : GButton
{
	public Controller button;

	public GGraph n6;

	public GImage bg;

	public GImage n5;

	public GTextField tip;

	public const string URL = "ui://47lbpgx9w1r55n";

	public static string Name = "UI_DontShowBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx9w1r55n";
	}

	public static UI_DontShowBtn CreateInstance()
	{
		return (UI_DontShowBtn)(object)UIPackage.CreateObject("Tips", "DontShowBtn");
	}

	public static UI_DontShowBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DontShowBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9w1r55n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://47lbpgx9w1r55n".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
	}
}
