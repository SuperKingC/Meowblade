using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_com_MBonusSlot : GComponent
{
	public Controller Type;

	public GImage n40;

	public GImage n38;

	public GGraph fxBack;

	public GLoader Icon;

	public GTextField Count;

	public const string URL = "ui://kozswd8hiqdsf34";

	public static string Name = "UI_com_MBonusSlot";

	public static string GetURL()
	{
		return "ui://kozswd8hiqdsf34";
	}

	public static UI_com_MBonusSlot CreateInstance()
	{
		return (UI_com_MBonusSlot)(object)UIPackage.CreateObject("SpecialActivity", "com_MBonusSlot");
	}

	public static UI_com_MBonusSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MBonusSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hiqdsf34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
