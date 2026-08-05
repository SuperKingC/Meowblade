using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_com_MChildBonusSlot : GComponent
{
	public GImage n41;

	public GLoader Icon;

	public GTextField Count;

	public const string URL = "ui://kozswd8hiqdsf36";

	public static string Name = "UI_com_MChildBonusSlot";

	public static string GetURL()
	{
		return "ui://kozswd8hiqdsf36";
	}

	public static UI_com_MChildBonusSlot CreateInstance()
	{
		return (UI_com_MChildBonusSlot)(object)UIPackage.CreateObject("SpecialActivity", "com_MChildBonusSlot");
	}

	public static UI_com_MChildBonusSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MChildBonusSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hiqdsf36", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n41 = (GImage)((GComponent)this).GetChild("n41");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
