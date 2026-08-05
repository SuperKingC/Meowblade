using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_FinalTopPlayerNo1 : GButton
{
	public Controller HasMedal;

	public Controller HasHornorTitle;

	public Controller IsBingo;

	public GLoader PlayerItemFrame;

	public UI_Avatar PlayerAvatar;

	public GLoader RankTop3;

	public GImage n41;

	public GTextField PlayerName;

	public GLoader HonorTitle;

	public GList MedalList;

	public GLoader battleLogBtn;

	public UI_BingoIcon BingoIcon;

	public const string URL = "ui://82mo10n5sn0gjdt5";

	public static string Name = "UI_btn_FinalTopPlayerNo1";

	public static string GetURL()
	{
		return "ui://82mo10n5sn0gjdt5";
	}

	public static UI_btn_FinalTopPlayerNo1 CreateInstance()
	{
		return (UI_btn_FinalTopPlayerNo1)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_FinalTopPlayerNo1");
	}

	public static UI_btn_FinalTopPlayerNo1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FinalTopPlayerNo1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5sn0gjdt5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasMedal = ((GComponent)this).GetController("HasMedal");
		HasHornorTitle = ((GComponent)this).GetController("HasHornorTitle");
		IsBingo = ((GComponent)this).GetController("IsBingo");
		PlayerItemFrame = (GLoader)((GComponent)this).GetChild("PlayerItemFrame");
		PlayerAvatar = (UI_Avatar)(object)((GComponent)this).GetChild("PlayerAvatar");
		RankTop3 = (GLoader)((GComponent)this).GetChild("RankTop3");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		HonorTitle = (GLoader)((GComponent)this).GetChild("HonorTitle");
		MedalList = (GList)((GComponent)this).GetChild("MedalList");
		battleLogBtn = (GLoader)((GComponent)this).GetChild("battleLogBtn");
		BingoIcon = (UI_BingoIcon)(object)((GComponent)this).GetChild("BingoIcon");
	}
}
