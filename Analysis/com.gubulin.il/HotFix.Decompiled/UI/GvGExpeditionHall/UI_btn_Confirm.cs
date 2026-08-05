using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_Confirm : GButton
{
	public Controller button;

	public GImage n9;

	public GTextField title0;

	public const string URL = "ui://k19peou795pe6p91";

	public static string Name = "UI_btn_Confirm";

	public static string GetURL()
	{
		return "ui://k19peou795pe6p91";
	}

	public static UI_btn_Confirm CreateInstance()
	{
		return (UI_btn_Confirm)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_Confirm");
	}

	public static UI_btn_Confirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Confirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou795pe6p91", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		string id = "ui://k19peou795pe6p91".Replace("ui://", "") + "-" + ((GObject)title0).id;
		((GObject)title0).text = LanguagesManager.GetDesc(id);
	}
}
