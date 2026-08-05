using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_btn_ConfirmBuy : GButton
{
	public Controller button;

	public GImage back;

	public GTextField title;

	public GImage n7;

	public const string URL = "ui://p4ocf6q09ewlk";

	public static string Name = "UI_btn_ConfirmBuy";

	public static string GetURL()
	{
		return "ui://p4ocf6q09ewlk";
	}

	public static UI_btn_ConfirmBuy CreateInstance()
	{
		return (UI_btn_ConfirmBuy)(object)UIPackage.CreateObject("GvGRandomEvent3", "btn_ConfirmBuy");
	}

	public static UI_btn_ConfirmBuy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmBuy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q09ewlk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://p4ocf6q09ewlk".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
