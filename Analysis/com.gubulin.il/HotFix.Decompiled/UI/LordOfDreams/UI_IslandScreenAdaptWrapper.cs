using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_IslandScreenAdaptWrapper : GComponent
{
	public GButton BackBtn;

	public UI_DamageLeaderboard DamageLeaderboard;

	public UI_BattleLogBtn BattleLogBtn;

	public UI_MyDamagePanel MyDamagePanel;

	public UI_BossHealthBarBig BossHealthBar;

	public GGraph BossIconGuider;

	public const string URL = "ui://0i520nzmzsih2c";

	public static string Name = "UI_IslandScreenAdaptWrapper";

	public static string GetURL()
	{
		return "ui://0i520nzmzsih2c";
	}

	public static UI_IslandScreenAdaptWrapper CreateInstance()
	{
		return (UI_IslandScreenAdaptWrapper)(object)UIPackage.CreateObject("LordOfDreams", "IslandScreenAdaptWrapper");
	}

	public static UI_IslandScreenAdaptWrapper CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandScreenAdaptWrapper).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmzsih2c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		DamageLeaderboard = (UI_DamageLeaderboard)(object)((GComponent)this).GetChild("DamageLeaderboard");
		BattleLogBtn = (UI_BattleLogBtn)(object)((GComponent)this).GetChild("BattleLogBtn");
		MyDamagePanel = (UI_MyDamagePanel)(object)((GComponent)this).GetChild("MyDamagePanel");
		BossHealthBar = (UI_BossHealthBarBig)(object)((GComponent)this).GetChild("BossHealthBar");
		BossIconGuider = (GGraph)((GComponent)this).GetChild("BossIconGuider");
	}
}
