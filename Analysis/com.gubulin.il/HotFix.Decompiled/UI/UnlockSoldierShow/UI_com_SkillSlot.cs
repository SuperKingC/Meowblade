using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_com_SkillSlot : GButton
{
	public Controller button;

	public Controller IsUnlock;

	public GImage n21;

	public GLoader SkillIconLoader;

	public GImage n23;

	public GTextField SkillName;

	public GImage n25;

	public GImage n20;

	public const string URL = "ui://ia1am3ehbutlt23";

	public static string Name = "UI_com_SkillSlot";

	public static string GetURL()
	{
		return "ui://ia1am3ehbutlt23";
	}

	public static UI_com_SkillSlot CreateInstance()
	{
		return (UI_com_SkillSlot)(object)UIPackage.CreateObject("UnlockSoldierShow", "com_SkillSlot");
	}

	public static UI_com_SkillSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SkillSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehbutlt23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsUnlock = ((GComponent)this).GetController("IsUnlock");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		SkillIconLoader = (GLoader)((GComponent)this).GetChild("SkillIconLoader");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		SkillName = (GTextField)((GComponent)this).GetChild("SkillName");
		string id = "ui://ia1am3ehbutlt23".Replace("ui://", "") + "-" + ((GObject)SkillName).id;
		((GObject)SkillName).text = LanguagesManager.GetDesc(id);
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n20 = (GImage)((GComponent)this).GetChild("n20");
	}
}
