using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_MaxValueBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GTextField title;

	public const string URL = "ui://47lbpgx9otto3g";

	public static string Name = "UI_MaxValueBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx9otto3g";
	}

	public static UI_MaxValueBtn CreateInstance()
	{
		return (UI_MaxValueBtn)(object)UIPackage.CreateObject("Tips", "MaxValueBtn");
	}

	public static UI_MaxValueBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MaxValueBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9otto3g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://47lbpgx9otto3g".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
