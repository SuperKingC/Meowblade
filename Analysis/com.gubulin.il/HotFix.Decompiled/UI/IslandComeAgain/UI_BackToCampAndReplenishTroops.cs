using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_BackToCampAndReplenishTroops : GButton
{
	public Controller button;

	public Controller Type;

	public UI_ReplenishBtnDark Dark;

	public GImage n8;

	public GTextField n3;

	public GTextField n4;

	public GTextField Countdown;

	public const string URL = "ui://k2sprg26t0sv9h";

	public static string Name = "UI_BackToCampAndReplenishTroops";

	public static string GetURL()
	{
		return "ui://k2sprg26t0sv9h";
	}

	public static UI_BackToCampAndReplenishTroops CreateInstance()
	{
		return (UI_BackToCampAndReplenishTroops)(object)UIPackage.CreateObject("IslandComeAgain", "BackToCampAndReplenishTroops");
	}

	public static UI_BackToCampAndReplenishTroops CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BackToCampAndReplenishTroops).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26t0sv9h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Dark = (UI_ReplenishBtnDark)(object)((GComponent)this).GetChild("Dark");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://k2sprg26t0sv9h".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://k2sprg26t0sv9h".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
	}
}
