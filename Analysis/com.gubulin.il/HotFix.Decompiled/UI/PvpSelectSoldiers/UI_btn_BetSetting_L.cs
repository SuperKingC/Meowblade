using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_BetSetting_L : GButton
{
	public Controller IsMeIn;

	public Controller ColorSet;

	public Controller HasBet;

	public Controller IsBingo;

	public Controller IsLocked;

	public GLoader FlagFrame;

	public GTextField title;

	public GImage DevilRibbon;

	public GImage n98;

	public UI_BingoIcon BingoIcon;

	public GImage n101;

	public const string URL = "ui://82mo10n5uwtxjds8";

	public static string Name = "UI_btn_BetSetting_L";

	public static string GetURL()
	{
		return "ui://82mo10n5uwtxjds8";
	}

	public static UI_btn_BetSetting_L CreateInstance()
	{
		return (UI_btn_BetSetting_L)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_BetSetting_L");
	}

	public static UI_btn_BetSetting_L CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BetSetting_L).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5uwtxjds8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsMeIn = ((GComponent)this).GetController("IsMeIn");
		ColorSet = ((GComponent)this).GetController("ColorSet");
		HasBet = ((GComponent)this).GetController("HasBet");
		IsBingo = ((GComponent)this).GetController("IsBingo");
		IsLocked = ((GComponent)this).GetController("IsLocked");
		FlagFrame = (GLoader)((GComponent)this).GetChild("FlagFrame");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5uwtxjds8".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		DevilRibbon = (GImage)((GComponent)this).GetChild("DevilRibbon");
		n98 = (GImage)((GComponent)this).GetChild("n98");
		BingoIcon = (UI_BingoIcon)(object)((GComponent)this).GetChild("BingoIcon");
		n101 = (GImage)((GComponent)this).GetChild("n101");
	}
}
