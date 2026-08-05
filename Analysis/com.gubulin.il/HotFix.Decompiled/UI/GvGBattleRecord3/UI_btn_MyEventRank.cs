using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_MyEventRank : GButton
{
	public Controller button;

	public Controller Rank;

	public Controller Winner;

	public GLoader n22;

	public UI_com_UserAvatarSmall UserIcon;

	public GTextField RankData;

	public GTextField UserName;

	public GImage n20;

	public GTextField n14;

	public GLoader n16;

	public GTextField Ranking;

	public GImage n18;

	public GGroup RankGroup;

	public GImage n26;

	public Transition t0;

	public const string URL = "ui://b3fc6085c5kp3u";

	public static string Name = "UI_btn_MyEventRank";

	public static string GetURL()
	{
		return "ui://b3fc6085c5kp3u";
	}

	public static UI_btn_MyEventRank CreateInstance()
	{
		return (UI_btn_MyEventRank)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_MyEventRank");
	}

	public static UI_btn_MyEventRank CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MyEventRank).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085c5kp3u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Rank = ((GComponent)this).GetController("Rank");
		Winner = ((GComponent)this).GetController("Winner");
		n22 = (GLoader)((GComponent)this).GetChild("n22");
		UserIcon = (UI_com_UserAvatarSmall)(object)((GComponent)this).GetChild("UserIcon");
		RankData = (GTextField)((GComponent)this).GetChild("RankData");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id = "ui://b3fc6085c5kp3u".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		n16 = (GLoader)((GComponent)this).GetChild("n16");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		RankGroup = (GGroup)((GComponent)this).GetChild("RankGroup");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
