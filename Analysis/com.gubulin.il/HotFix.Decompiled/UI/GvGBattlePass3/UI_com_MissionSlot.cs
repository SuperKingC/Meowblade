using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_com_MissionSlot : GComponent
{
	public GImage back;

	public GImage n14;

	public GTextField Title;

	public GLoader LevelIcon;

	public GTextField LevelText;

	public const string URL = "ui://bfjg32huq1eq3t";

	public static string Name = "UI_com_MissionSlot";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq3t";
	}

	public static UI_com_MissionSlot CreateInstance()
	{
		return (UI_com_MissionSlot)(object)UIPackage.CreateObject("GvGBattlePass3", "com_MissionSlot");
	}

	public static UI_com_MissionSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MissionSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq3t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		LevelText = (GTextField)((GComponent)this).GetChild("LevelText");
	}
}
