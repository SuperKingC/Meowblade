using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_com_MBonusLineSlot : GComponent
{
	public Controller NoChildBonus;

	public GImage n42;

	public GTextField ChildBonusListTitle;

	public GList ChildBonusList;

	public GList BonusList;

	public GImage n43;

	public const string URL = "ui://kozswd8hiqdsf37";

	public static string Name = "UI_com_MBonusLineSlot";

	public static string GetURL()
	{
		return "ui://kozswd8hiqdsf37";
	}

	public static UI_com_MBonusLineSlot CreateInstance()
	{
		return (UI_com_MBonusLineSlot)(object)UIPackage.CreateObject("SpecialActivity", "com_MBonusLineSlot");
	}

	public static UI_com_MBonusLineSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MBonusLineSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hiqdsf37", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		NoChildBonus = ((GComponent)this).GetController("NoChildBonus");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		ChildBonusListTitle = (GTextField)((GComponent)this).GetChild("ChildBonusListTitle");
		ChildBonusList = (GList)((GComponent)this).GetChild("ChildBonusList");
		BonusList = (GList)((GComponent)this).GetChild("BonusList");
		n43 = (GImage)((GComponent)this).GetChild("n43");
	}
}
