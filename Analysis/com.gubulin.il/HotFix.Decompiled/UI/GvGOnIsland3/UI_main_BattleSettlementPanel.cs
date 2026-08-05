using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_main_BattleSettlementPanel : GComponent
{
	public GGraph back;

	public UI_com_BattleSettlementDialog Dialog;

	public Transition t0;

	public const string URL = "ui://ebc4ciwr9t3hq4h";

	public static string Name = "UI_main_BattleSettlementPanel";

	public static string GetURL()
	{
		return "ui://ebc4ciwr9t3hq4h";
	}

	public static UI_main_BattleSettlementPanel CreateInstance()
	{
		return (UI_main_BattleSettlementPanel)(object)UIPackage.CreateObject("GvGOnIsland3", "main_BattleSettlementPanel");
	}

	public static UI_main_BattleSettlementPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BattleSettlementPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwr9t3hq4h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_BattleSettlementDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
