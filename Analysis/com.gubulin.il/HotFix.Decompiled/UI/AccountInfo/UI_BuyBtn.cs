using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_BuyBtn : GButton
{
	public Controller button;

	public GImage n0;

	public GTextField n1;

	public const string URL = "ui://b9yxt7u0gz0s2b";

	public static string Name = "UI_BuyBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0gz0s2b";
	}

	public static UI_BuyBtn CreateInstance()
	{
		return (UI_BuyBtn)(object)UIPackage.CreateObject("AccountInfo", "BuyBtn");
	}

	public static UI_BuyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0gz0s2b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://b9yxt7u0gz0s2b".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
	}
}
