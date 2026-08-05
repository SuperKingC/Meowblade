using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_btn_Buy : GButton
{
	public Controller button;

	public Controller CanBuy;

	public GImage n6;

	public GTextField n4;

	public GTextField PurchaseLimit;

	public const string URL = "ui://p4ocf6q0dc6md";

	public static string Name = "UI_btn_Buy";

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6md";
	}

	public static UI_btn_Buy CreateInstance()
	{
		return (UI_btn_Buy)(object)UIPackage.CreateObject("GvGRandomEvent3", "btn_Buy");
	}

	public static UI_btn_Buy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Buy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6md", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		CanBuy = ((GComponent)this).GetController("CanBuy");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://p4ocf6q0dc6md".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		PurchaseLimit = (GTextField)((GComponent)this).GetChild("PurchaseLimit");
		string id2 = "ui://p4ocf6q0dc6md".Replace("ui://", "") + "-" + ((GObject)PurchaseLimit).id;
		((GObject)PurchaseLimit).text = LanguagesManager.GetDesc(id2);
	}
}
