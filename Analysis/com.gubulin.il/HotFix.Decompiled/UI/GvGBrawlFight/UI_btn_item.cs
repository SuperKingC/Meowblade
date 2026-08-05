using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_item : GButton
{
	public Controller button;

	public GLoader itemIcon;

	public GTextField rewardCount;

	public const string URL = "ui://hozu168ro7e45s";

	public static string Name = "UI_btn_item";

	public static string GetURL()
	{
		return "ui://hozu168ro7e45s";
	}

	public static UI_btn_item CreateInstance()
	{
		return (UI_btn_item)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_item");
	}

	public static UI_btn_item CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_item).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168ro7e45s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		itemIcon = (GLoader)((GComponent)this).GetChild("itemIcon");
		rewardCount = (GTextField)((GComponent)this).GetChild("rewardCount");
		string id = "ui://hozu168ro7e45s".Replace("ui://", "") + "-" + ((GObject)rewardCount).id;
		((GObject)rewardCount).text = LanguagesManager.GetDesc(id);
	}
}
