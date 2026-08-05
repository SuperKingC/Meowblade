using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_LiftoffBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GTextField title;

	public const string URL = "ui://7ymaonxteo5m4l";

	public static string Name = "UI_LiftoffBtn";

	public static string GetURL()
	{
		return "ui://7ymaonxteo5m4l";
	}

	public static UI_LiftoffBtn CreateInstance()
	{
		return (UI_LiftoffBtn)(object)UIPackage.CreateObject("GvGShipOverview", "LiftoffBtn");
	}

	public static UI_LiftoffBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LiftoffBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxteo5m4l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://7ymaonxteo5m4l".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
