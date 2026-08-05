using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftBag;

public class UI_HotSaleItem : GButton
{
	public Controller button;

	public GLoader icon;

	public GTextField num;

	public const string URL = "ui://4fqsd8h6avmff";

	public static string Name = "UI_HotSaleItem";

	public static string GetURL()
	{
		return "ui://4fqsd8h6avmff";
	}

	public static UI_HotSaleItem CreateInstance()
	{
		return (UI_HotSaleItem)(object)UIPackage.CreateObject("GiftBag", "HotSaleItem");
	}

	public static UI_HotSaleItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HotSaleItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmff", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://4fqsd8h6avmff".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
	}
}
