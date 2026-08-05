using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PaymentOptions;

public class UI_WeChatPayBtn : GButton
{
	public Controller button;

	public GImage n4;

	public GTextField n5;

	public const string URL = "ui://jy8z3hj6gpwa8";

	public static string Name = "UI_WeChatPayBtn";

	public static string GetURL()
	{
		return "ui://jy8z3hj6gpwa8";
	}

	public static UI_WeChatPayBtn CreateInstance()
	{
		return (UI_WeChatPayBtn)(object)UIPackage.CreateObject("PaymentOptions", "WeChatPayBtn");
	}

	public static UI_WeChatPayBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WeChatPayBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jy8z3hj6gpwa8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://jy8z3hj6gpwa8".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
