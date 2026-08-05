using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_btn_ConfirmBtn2 : GButton
{
	public Controller button;

	public GImage n8;

	public GTextField n10;

	public const string URL = "ui://vheg8vabnfmew";

	public static string Name = "UI_btn_ConfirmBtn2";

	public static string GetURL()
	{
		return "ui://vheg8vabnfmew";
	}

	public static UI_btn_ConfirmBtn2 CreateInstance()
	{
		return (UI_btn_ConfirmBtn2)(object)UIPackage.CreateObject("GvGPlayerCommand3", "btn_ConfirmBtn2");
	}

	public static UI_btn_ConfirmBtn2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmBtn2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabnfmew", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://vheg8vabnfmew".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
	}
}
