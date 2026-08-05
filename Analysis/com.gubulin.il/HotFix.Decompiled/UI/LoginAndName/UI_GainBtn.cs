using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_GainBtn : GButton
{
	public Controller button;

	public Controller PageController;

	public GImage n6;

	public GTextField title;

	public const string URL = "ui://yb3s7uv7bw1c23";

	public static string Name = "UI_GainBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7bw1c23";
	}

	public static UI_GainBtn CreateInstance()
	{
		return (UI_GainBtn)(object)UIPackage.CreateObject("LoginAndName", "GainBtn");
	}

	public static UI_GainBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GainBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7bw1c23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		PageController = ((GComponent)this).GetController("PageController");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://yb3s7uv7bw1c23".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
