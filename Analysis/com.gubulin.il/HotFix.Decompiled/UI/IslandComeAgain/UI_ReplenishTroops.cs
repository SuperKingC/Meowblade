using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ReplenishTroops : GButton
{
	public Controller button;

	public Controller Type;

	public UI_ReplenishBtnDark Dark;

	public GImage n8;

	public GTextField n3;

	public GTextField n4;

	public GTextField Countdown;

	public const string URL = "ui://k2sprg26in7b2u";

	public static string Name = "UI_ReplenishTroops";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b2u";
	}

	public static UI_ReplenishTroops CreateInstance()
	{
		return (UI_ReplenishTroops)(object)UIPackage.CreateObject("IslandComeAgain", "ReplenishTroops");
	}

	public static UI_ReplenishTroops CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReplenishTroops).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b2u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://k2sprg26in7b2u".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://k2sprg26in7b2u".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
	}
}
