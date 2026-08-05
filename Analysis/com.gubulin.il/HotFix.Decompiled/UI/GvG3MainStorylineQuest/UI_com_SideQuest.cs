using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_SideQuest : GComponent
{
	public Controller Status;

	public Controller Claimed;

	public GImage n0;

	public GImage n1;

	public GTextField QuestDesc;

	public GLoader RewardIcon;

	public GImage n2;

	public GTextField BonusNumber;

	public const string URL = "ui://249h3k3dvihg26";

	public static string Name = "UI_com_SideQuest";

	public static string GetURL()
	{
		return "ui://249h3k3dvihg26";
	}

	public static UI_com_SideQuest CreateInstance()
	{
		return (UI_com_SideQuest)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_SideQuest");
	}

	public static UI_com_SideQuest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SideQuest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg26", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Claimed = ((GComponent)this).GetController("Claimed");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		QuestDesc = (GTextField)((GComponent)this).GetChild("QuestDesc");
		RewardIcon = (GLoader)((GComponent)this).GetChild("RewardIcon");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		BonusNumber = (GTextField)((GComponent)this).GetChild("BonusNumber");
	}
}
