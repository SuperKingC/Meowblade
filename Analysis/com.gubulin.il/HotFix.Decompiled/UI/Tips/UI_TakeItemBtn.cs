using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_TakeItemBtn : GButton
{
	public Controller button;

	public UI_TakeItemContent_Large Content;

	public GImage n8;

	public const string URL = "ui://47lbpgx9vur65j";

	public static string Name = "UI_TakeItemBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx9vur65j";
	}

	public static UI_TakeItemBtn CreateInstance()
	{
		return (UI_TakeItemBtn)(object)UIPackage.CreateObject("Tips", "TakeItemBtn");
	}

	public static UI_TakeItemBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TakeItemBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9vur65j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Content = (UI_TakeItemContent_Large)(object)((GComponent)this).GetChild("Content");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
