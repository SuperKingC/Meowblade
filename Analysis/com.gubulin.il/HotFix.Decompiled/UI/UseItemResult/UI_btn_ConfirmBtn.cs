using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UseItemResult;

public class UI_btn_ConfirmBtn : GButton
{
	public Controller button;

	public GImage background;

	public GTextField title;

	public const string URL = "ui://800w3r8rez1c1";

	public static string Name = "UI_btn_ConfirmBtn";

	public static string GetURL()
	{
		return "ui://800w3r8rez1c1";
	}

	public static UI_btn_ConfirmBtn CreateInstance()
	{
		return (UI_btn_ConfirmBtn)(object)UIPackage.CreateObject("UseItemResult", "btn_ConfirmBtn");
	}

	public static UI_btn_ConfirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://800w3r8rez1c1".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
