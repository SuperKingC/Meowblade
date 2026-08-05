using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_UnlockPeakDialog : GComponent
{
	public GImage back;

	public UI_PeakBattleHelp PeakBattleHelp;

	public UI_ConfirmUnlockTopTournament RefreshCardBtn;

	public GImage n40;

	public GImage n41;

	public const string URL = "ui://82mo10n5x1jldde";

	public static string Name = "UI_UnlockPeakDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5x1jldde";
	}

	public static UI_UnlockPeakDialog CreateInstance()
	{
		return (UI_UnlockPeakDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "UnlockPeakDialog");
	}

	public static UI_UnlockPeakDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockPeakDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5x1jldde", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		PeakBattleHelp = (UI_PeakBattleHelp)(object)((GComponent)this).GetChild("PeakBattleHelp");
		RefreshCardBtn = (UI_ConfirmUnlockTopTournament)(object)((GComponent)this).GetChild("RefreshCardBtn");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GImage)((GComponent)this).GetChild("n41");
	}
}
