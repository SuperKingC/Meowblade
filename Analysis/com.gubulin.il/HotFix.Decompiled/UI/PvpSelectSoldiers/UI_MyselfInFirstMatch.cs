using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_MyselfInFirstMatch : GComponent
{
	public Controller HasMedal;

	public Controller HasHornorTitle;

	public Controller HasMeScore;

	public Controller IsMeInShortlist;

	public GImage n41;

	public GLoader PlayerItemFrame;

	public GImage n47;

	public GImage n42;

	public UI_Avatar PlayerAvatar;

	public GTextField PlayerName;

	public GTextField ScoreTypeName;

	public GImage n48;

	public GTextField ScoreNumber;

	public GMovieClip n43;

	public GMovieClip n44;

	public GMovieClip n45;

	public GGroup EffGroup;

	public GTextField RankNumber;

	public GLoader HonorTitle;

	public GList MedalList;

	public GLoader ScoreBtn;

	public GGroup n39;

	public Transition t0;

	public const string URL = "ui://82mo10n5eja6jdrk";

	public static string Name = "UI_MyselfInFirstMatch";

	public static string GetURL()
	{
		return "ui://82mo10n5eja6jdrk";
	}

	public static UI_MyselfInFirstMatch CreateInstance()
	{
		return (UI_MyselfInFirstMatch)(object)UIPackage.CreateObject("PvpSelectSoldiers", "MyselfInFirstMatch");
	}

	public static UI_MyselfInFirstMatch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyselfInFirstMatch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5eja6jdrk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasMedal = ((GComponent)this).GetController("HasMedal");
		HasHornorTitle = ((GComponent)this).GetController("HasHornorTitle");
		HasMeScore = ((GComponent)this).GetController("HasMeScore");
		IsMeInShortlist = ((GComponent)this).GetController("IsMeInShortlist");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		PlayerItemFrame = (GLoader)((GComponent)this).GetChild("PlayerItemFrame");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		PlayerAvatar = (UI_Avatar)(object)((GComponent)this).GetChild("PlayerAvatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		ScoreTypeName = (GTextField)((GComponent)this).GetChild("ScoreTypeName");
		string id = "ui://82mo10n5eja6jdrk".Replace("ui://", "") + "-" + ((GObject)ScoreTypeName).id;
		((GObject)ScoreTypeName).text = LanguagesManager.GetDesc(id);
		n48 = (GImage)((GComponent)this).GetChild("n48");
		ScoreNumber = (GTextField)((GComponent)this).GetChild("ScoreNumber");
		n43 = (GMovieClip)((GComponent)this).GetChild("n43");
		n44 = (GMovieClip)((GComponent)this).GetChild("n44");
		n45 = (GMovieClip)((GComponent)this).GetChild("n45");
		EffGroup = (GGroup)((GComponent)this).GetChild("EffGroup");
		RankNumber = (GTextField)((GComponent)this).GetChild("RankNumber");
		HonorTitle = (GLoader)((GComponent)this).GetChild("HonorTitle");
		MedalList = (GList)((GComponent)this).GetChild("MedalList");
		ScoreBtn = (GLoader)((GComponent)this).GetChild("ScoreBtn");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
