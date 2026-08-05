using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ItemBtn : GButton
{
	public Controller button;

	public UI_TakeItemContent Content;

	public const string URL = "ui://47lbpgx9h7os2e";

	public static string Name = "UI_ItemBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx9h7os2e";
	}

	public static UI_ItemBtn CreateInstance()
	{
		return (UI_ItemBtn)(object)UIPackage.CreateObject("Tips", "ItemBtn");
	}

	public static UI_ItemBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ItemBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9h7os2e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Content = (UI_TakeItemContent)(object)((GComponent)this).GetChild("Content");
	}
}
