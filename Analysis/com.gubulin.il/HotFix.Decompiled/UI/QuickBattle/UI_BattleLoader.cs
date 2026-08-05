using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_BattleLoader : GComponent
{
	public Controller Type;

	public GImage Back;

	public UI_QuickBattleStage BattleStage;

	public Transition Move;

	public const string URL = "ui://kqd1t06of2584";

	public static string Name = "UI_BattleLoader";

	public static string GetURL()
	{
		return "ui://kqd1t06of2584";
	}

	public static UI_BattleLoader CreateInstance()
	{
		return (UI_BattleLoader)(object)UIPackage.CreateObject("QuickBattle", "BattleLoader");
	}

	public static UI_BattleLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BattleLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2584", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Back = (GImage)((GComponent)this).GetChild("Back");
		BattleStage = (UI_QuickBattleStage)(object)((GComponent)this).GetChild("BattleStage");
		Move = ((GComponent)this).GetTransition("Move");
	}
}
