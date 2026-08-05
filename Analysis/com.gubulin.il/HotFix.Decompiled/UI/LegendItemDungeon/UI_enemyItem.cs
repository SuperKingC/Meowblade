using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_enemyItem : GButton
{
	public Controller button;

	public GImage background;

	public GLoader iconFrame;

	public GLoader icon;

	public GComponent SoulStoneLevel;

	public GLoader lvFrame;

	public GRichTextField lv;

	public GImage n48;

	public GTextField num;

	public GImage n46;

	public GGroup n47;

	public Transition Disappear;

	public const string URL = "ui://2eraz3j9ldt62j";

	public static string Name = "UI_enemyItem";

	public static string GetURL()
	{
		return "ui://2eraz3j9ldt62j";
	}

	public static UI_enemyItem CreateInstance()
	{
		return (UI_enemyItem)(object)UIPackage.CreateObject("LegendItemDungeon", "enemyItem");
	}

	public static UI_enemyItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_enemyItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9ldt62j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		lv = (GRichTextField)((GComponent)this).GetChild("lv");
		string id = "ui://2eraz3j9ldt62j".Replace("ui://", "") + "-" + ((GObject)lv).id;
		((GObject)lv).text = LanguagesManager.GetDesc(id);
		n48 = (GImage)((GComponent)this).GetChild("n48");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id2 = "ui://2eraz3j9ldt62j".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id2);
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GGroup)((GComponent)this).GetChild("n47");
		Disappear = ((GComponent)this).GetTransition("Disappear");
	}
}
