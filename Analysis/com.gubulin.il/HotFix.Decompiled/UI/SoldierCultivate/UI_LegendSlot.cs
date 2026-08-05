using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_LegendSlot : GComponent
{
	public Controller SlotNum;

	public GImage n5;

	public GImage n6;

	public GImage n2;

	public GImage n3;

	public GList LegendItemSlots;

	public GImage n9;

	public GTextField Tip;

	public GImage note;

	public GButton NewDot;

	public Transition ShowNewDot;

	public const string URL = "ui://7dantnbiv5czta3";

	public static string Name = "UI_LegendSlot";

	public static string GetURL()
	{
		return "ui://7dantnbiv5czta3";
	}

	public static UI_LegendSlot CreateInstance()
	{
		return (UI_LegendSlot)(object)UIPackage.CreateObject("SoldierCultivate", "LegendSlot");
	}

	public static UI_LegendSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbiv5czta3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SlotNum = ((GComponent)this).GetController("SlotNum");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		LegendItemSlots = (GList)((GComponent)this).GetChild("LegendItemSlots");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://7dantnbiv5czta3".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
		NewDot = (GButton)((GComponent)this).GetChild("NewDot");
		ShowNewDot = ((GComponent)this).GetTransition("ShowNewDot");
	}
}
