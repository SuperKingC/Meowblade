using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;

namespace UI.PvpSelectSoldiers;

public class UI_IdleBonus : GButton
{
	public Controller button;

	public Controller BoxState;

	public GImage n7;

	public GImage n5;

	public GImage n6;

	public GGraph TextBack;

	public GTextField BonusNumber;

	public const string URL = "ui://82mo10n5x1jlddb";

	public static string Name = "UI_IdleBonus";

	public static string GetURL()
	{
		return "ui://82mo10n5x1jlddb";
	}

	public static UI_IdleBonus CreateInstance()
	{
		return (UI_IdleBonus)(object)UIPackage.CreateObject("PvpSelectSoldiers", "IdleBonus");
	}

	public static UI_IdleBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IdleBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5x1jlddb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		BoxState = ((GComponent)this).GetController("BoxState");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		TextBack = (GGraph)((GComponent)this).GetChild("TextBack");
		BonusNumber = (GTextField)((GComponent)this).GetChild("BonusNumber");
	}

	public bool CanGetBonus()
	{
		if (((GObject)BonusNumber).data == null)
		{
			((GObject)BonusNumber).data = 0;
		}
		int num = (int)((GObject)BonusNumber).data;
		return num > 0;
	}

	public void UpdateIdleBoxState()
	{
		if (RankDataHelper.GetWaitForClaimIdleBonusNum() >= 1000)
		{
			BoxState.selectedIndex = 1;
		}
		else
		{
			BoxState.selectedIndex = 0;
		}
		if (((GObject)BonusNumber).data == null)
		{
			((GObject)BonusNumber).data = 0;
		}
		int num = (int)((GObject)BonusNumber).data;
		UiHelper.NumberTextChangeGTween(num, RankDataHelper.GetWaitForClaimIdleBonusNum(), BonusNumber, 1f, (EaseType)19);
		((GObject)BonusNumber).data = RankDataHelper.GetWaitForClaimIdleBonusNum();
	}
}
