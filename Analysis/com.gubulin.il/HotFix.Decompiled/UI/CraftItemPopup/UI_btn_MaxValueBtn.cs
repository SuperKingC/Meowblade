using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.CraftItemPopup;

public class UI_btn_MaxValueBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GTextField Title;

	public const string URL = "ui://4pn38ozntxb6lq";

	public static string Name = "UI_btn_MaxValueBtn";

	public static string GetURL()
	{
		return "ui://4pn38ozntxb6lq";
	}

	public static UI_btn_MaxValueBtn CreateInstance()
	{
		return (UI_btn_MaxValueBtn)(object)UIPackage.CreateObject("CraftItemPopup", "btn_MaxValueBtn");
	}

	public static UI_btn_MaxValueBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MaxValueBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozntxb6lq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://4pn38ozntxb6lq".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}
}
