using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_com_EffectSwitchItem : GComponent
{
	public Controller Selected;

	public Controller IsSelectable;

	public GImage frame;

	public GImage n7;

	public GImage n9;

	public GTextField title;

	public UI_SubAttributeBack main;

	public UI_SubAttributeBack sub;

	public GGroup n5;

	public GImage n10;

	public GImage checkMark;

	public const string URL = "ui://b9wlonaqcl002";

	public static string Name = "UI_com_EffectSwitchItem";

	public static string GetURL()
	{
		return "ui://b9wlonaqcl002";
	}

	public static UI_com_EffectSwitchItem CreateInstance()
	{
		return (UI_com_EffectSwitchItem)(object)UIPackage.CreateObject("LegendItemCultivation", "com_EffectSwitchItem");
	}

	public static UI_com_EffectSwitchItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_EffectSwitchItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqcl002", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Selected = ((GComponent)this).GetController("Selected");
		IsSelectable = ((GComponent)this).GetController("IsSelectable");
		frame = (GImage)((GComponent)this).GetChild("frame");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9wlonaqcl002".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		main = (UI_SubAttributeBack)(object)((GComponent)this).GetChild("main");
		sub = (UI_SubAttributeBack)(object)((GComponent)this).GetChild("sub");
		n5 = (GGroup)((GComponent)this).GetChild("n5");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		checkMark = (GImage)((GComponent)this).GetChild("checkMark");
	}
}
