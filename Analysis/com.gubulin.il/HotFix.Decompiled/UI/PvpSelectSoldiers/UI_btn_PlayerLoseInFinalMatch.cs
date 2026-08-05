using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_PlayerLoseInFinalMatch : GButton
{
	public GLoader PlayerItemFrame;

	public UI_Avatar PlayerAvatar;

	public GTextField PlayerName;

	public GImage BattleReportIcon;

	public GTextField title;

	public GGroup n39;

	public const string URL = "ui://82mo10n5sn0gjdsw";

	public static string Name = "UI_btn_PlayerLoseInFinalMatch";

	public static string GetURL()
	{
		return "ui://82mo10n5sn0gjdsw";
	}

	public static UI_btn_PlayerLoseInFinalMatch CreateInstance()
	{
		return (UI_btn_PlayerLoseInFinalMatch)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_PlayerLoseInFinalMatch");
	}

	public static UI_btn_PlayerLoseInFinalMatch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PlayerLoseInFinalMatch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5sn0gjdsw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PlayerItemFrame = (GLoader)((GComponent)this).GetChild("PlayerItemFrame");
		PlayerAvatar = (UI_Avatar)(object)((GComponent)this).GetChild("PlayerAvatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		BattleReportIcon = (GImage)((GComponent)this).GetChild("BattleReportIcon");
		title = (GTextField)((GComponent)this).GetChild("title");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
	}
}
