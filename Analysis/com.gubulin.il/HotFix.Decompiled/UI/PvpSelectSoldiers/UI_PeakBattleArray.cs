using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PeakBattleArray : GButton
{
	public Controller button;

	public Controller HighLight;

	public GImage n6;

	public GImage n7;

	public Transition t0;

	public const string URL = "ui://82mo10n5x1jldda";

	public static string Name = "UI_PeakBattleArray";

	public static string GetURL()
	{
		return "ui://82mo10n5x1jldda";
	}

	public static UI_PeakBattleArray CreateInstance()
	{
		return (UI_PeakBattleArray)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PeakBattleArray");
	}

	public static UI_PeakBattleArray CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PeakBattleArray).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5x1jldda", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		HighLight = ((GComponent)this).GetController("HighLight");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
