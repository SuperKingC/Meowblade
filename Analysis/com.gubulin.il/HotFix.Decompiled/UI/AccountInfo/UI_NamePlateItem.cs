using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_NamePlateItem : GButton
{
	public Controller button;

	public Controller status;

	public Controller info;

	public GImage n134;

	public GLoader Icon;

	public GTextField TimeLimit;

	public GImage n133;

	public GImage n136;

	public UI_ItemPrice Price;

	public const string URL = "ui://b9yxt7u0ed273j";

	public static string Name = "UI_NamePlateItem";

	public static string GetURL()
	{
		return "ui://b9yxt7u0ed273j";
	}

	public static UI_NamePlateItem CreateInstance()
	{
		return (UI_NamePlateItem)(object)UIPackage.CreateObject("AccountInfo", "NamePlateItem");
	}

	public static UI_NamePlateItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NamePlateItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0ed273j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		status = ((GComponent)this).GetController("status");
		info = ((GComponent)this).GetController("info");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		TimeLimit = (GTextField)((GComponent)this).GetChild("TimeLimit");
		string id = "ui://b9yxt7u0ed273j".Replace("ui://", "") + "-" + ((GObject)TimeLimit).id;
		((GObject)TimeLimit).text = LanguagesManager.GetDesc(id);
		n133 = (GImage)((GComponent)this).GetChild("n133");
		n136 = (GImage)((GComponent)this).GetChild("n136");
		Price = (UI_ItemPrice)(object)((GComponent)this).GetChild("Price");
	}
}
