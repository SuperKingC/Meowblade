using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PushFirstTopup;

public class UI_RechargeBtn : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField title;

	public const string URL = "ui://r9ncs56ehni6v44h";

	public static string Name = "UI_RechargeBtn";

	public static string GetURL()
	{
		return "ui://r9ncs56ehni6v44h";
	}

	public static UI_RechargeBtn CreateInstance()
	{
		return (UI_RechargeBtn)(object)UIPackage.CreateObject("PushFirstTopup", "RechargeBtn");
	}

	public static UI_RechargeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r9ncs56ehni6v44h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://r9ncs56ehni6v44h".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
