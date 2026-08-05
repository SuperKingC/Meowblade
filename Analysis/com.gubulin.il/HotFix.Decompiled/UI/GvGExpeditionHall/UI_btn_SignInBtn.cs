using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_SignInBtn : GButton
{
	public Controller button;

	public GImage n8;

	public GTextField title;

	public const string URL = "ui://k19peou7dnvl30";

	public static string Name = "UI_btn_SignInBtn";

	public static string GetURL()
	{
		return "ui://k19peou7dnvl30";
	}

	public static UI_btn_SignInBtn CreateInstance()
	{
		return (UI_btn_SignInBtn)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_SignInBtn");
	}

	public static UI_btn_SignInBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SignInBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://k19peou7dnvl30".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
