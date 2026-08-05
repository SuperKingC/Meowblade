using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecords;

public class UI_EnemyInfomationBar : GComponent
{
	public GImage iconBack;

	public GLoader Iconloader;

	public GLoader Frameloader;

	public GGroup n7;

	public GTextField ArmyGroupLevel;

	public GTextField ArmyGroupName;

	public UI_RankingListAvatar Avatar;

	public const string URL = "ui://dxmilktydzls17";

	public static string Name = "UI_EnemyInfomationBar";

	public static string GetURL()
	{
		return "ui://dxmilktydzls17";
	}

	public static UI_EnemyInfomationBar CreateInstance()
	{
		return (UI_EnemyInfomationBar)(object)UIPackage.CreateObject("GvGBattleRecords", "EnemyInfomationBar");
	}

	public static UI_EnemyInfomationBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyInfomationBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://dxmilktydzls17", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		Iconloader = (GLoader)((GComponent)this).GetChild("Iconloader");
		Frameloader = (GLoader)((GComponent)this).GetChild("Frameloader");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
		ArmyGroupLevel = (GTextField)((GComponent)this).GetChild("ArmyGroupLevel");
		ArmyGroupName = (GTextField)((GComponent)this).GetChild("ArmyGroupName");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
	}
}
