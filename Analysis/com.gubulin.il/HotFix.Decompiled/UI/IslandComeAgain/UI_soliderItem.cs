using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_soliderItem : GButton
{
	public Controller button;

	public Controller Type;

	public GLoader iconFrame;

	public GLoader icon;

	public GLoader lvFrame;

	public GRichTextField lv;

	public GComponent SoulStoneLevel;

	public UI_LegendItemsBack LegendItemsBack;

	public GButton legendItem1;

	public GButton legendItem0;

	public GGroup LegendItems;

	public Transition Disappear;

	public const string URL = "ui://k2sprg26in7b1f";

	public static string Name = "UI_soliderItem";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b1f";
	}

	public static UI_soliderItem CreateInstance()
	{
		return (UI_soliderItem)(object)UIPackage.CreateObject("IslandComeAgain", "soliderItem");
	}

	public static UI_soliderItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_soliderItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b1f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		lv = (GRichTextField)((GComponent)this).GetChild("lv");
		string id = "ui://k2sprg26in7b1f".Replace("ui://", "") + "-" + ((GObject)lv).id;
		((GObject)lv).text = LanguagesManager.GetDesc(id);
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		LegendItemsBack = (UI_LegendItemsBack)(object)((GComponent)this).GetChild("LegendItemsBack");
		legendItem1 = (GButton)((GComponent)this).GetChild("legendItem1");
		legendItem0 = (GButton)((GComponent)this).GetChild("legendItem0");
		LegendItems = (GGroup)((GComponent)this).GetChild("LegendItems");
		Disappear = ((GComponent)this).GetTransition("Disappear");
	}
}
