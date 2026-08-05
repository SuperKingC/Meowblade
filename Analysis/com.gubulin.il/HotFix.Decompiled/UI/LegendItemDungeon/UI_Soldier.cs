using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_Soldier : GButton
{
	public Controller button;

	public Controller Type;

	public Controller State;

	public GLoader iconFrame;

	public GLoader icon;

	public GLoader lvFrame;

	public GImage n51;

	public GRichTextField lv;

	public GComponent SoulStoneLevel;

	public GImage numNote2;

	public GRichTextField num2;

	public GGroup NumSelected;

	public Transition breath;

	public const string URL = "ui://2eraz3j9fyeyt";

	public static string Name = "UI_Soldier";

	public static string GetURL()
	{
		return "ui://2eraz3j9fyeyt";
	}

	public static UI_Soldier CreateInstance()
	{
		return (UI_Soldier)(object)UIPackage.CreateObject("LegendItemDungeon", "Soldier");
	}

	public static UI_Soldier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Soldier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9fyeyt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		lv = (GRichTextField)((GComponent)this).GetChild("lv");
		string id = "ui://2eraz3j9fyeyt".Replace("ui://", "") + "-" + ((GObject)lv).id;
		((GObject)lv).text = LanguagesManager.GetDesc(id);
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		numNote2 = (GImage)((GComponent)this).GetChild("numNote2");
		num2 = (GRichTextField)((GComponent)this).GetChild("num2");
		string id2 = "ui://2eraz3j9fyeyt".Replace("ui://", "") + "-" + ((GObject)num2).id;
		((GObject)num2).text = LanguagesManager.GetDesc(id2);
		NumSelected = (GGroup)((GComponent)this).GetChild("NumSelected");
		breath = ((GComponent)this).GetTransition("breath");
	}
}
