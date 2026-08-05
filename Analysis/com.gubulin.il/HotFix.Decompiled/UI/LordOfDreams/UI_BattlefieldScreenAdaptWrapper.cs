using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_BattlefieldScreenAdaptWrapper : GComponent
{
	public GButton BackBtn;

	public UI_BossHealthBarBig BossHealthBar;

	public UI_GvGTotalDamageBattleField MyBattleInfo;

	public UI_BattleLogBtn BattleLogBtn;

	public const string URL = "ui://0i520nzm121eo59";

	public static string Name = "UI_BattlefieldScreenAdaptWrapper";

	public static string GetURL()
	{
		return "ui://0i520nzm121eo59";
	}

	public static UI_BattlefieldScreenAdaptWrapper CreateInstance()
	{
		return (UI_BattlefieldScreenAdaptWrapper)(object)UIPackage.CreateObject("LordOfDreams", "BattlefieldScreenAdaptWrapper");
	}

	public static UI_BattlefieldScreenAdaptWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BattlefieldScreenAdaptWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm121eo59", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		BossHealthBar = (UI_BossHealthBarBig)(object)((GComponent)this).GetChild("BossHealthBar");
		MyBattleInfo = (UI_GvGTotalDamageBattleField)(object)((GComponent)this).GetChild("MyBattleInfo");
		BattleLogBtn = (UI_BattleLogBtn)(object)((GComponent)this).GetChild("BattleLogBtn");
	}
}
