using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.EnemyIntroduction;

public class UI_LegendSlot : GComponent
{
	public Controller SlotNum;

	public GImage n5;

	public GImage n6;

	public GImage n2;

	public GImage n3;

	public GList LegendItemSlots;

	public GTextField Tip;

	public const string URL = "ui://rn232z3erqrej4";

	public static string Name = "UI_LegendSlot";

	public static string GetURL()
	{
		return "ui://rn232z3erqrej4";
	}

	public static UI_LegendSlot CreateInstance()
	{
		return (UI_LegendSlot)(object)UIPackage.CreateObject("EnemyIntroduction", "LegendSlot");
	}

	public static UI_LegendSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3erqrej4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		SlotNum = ((GComponent)this).GetController("SlotNum");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		LegendItemSlots = (GList)((GComponent)this).GetChild("LegendItemSlots");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://rn232z3erqrej4".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
	}
}
