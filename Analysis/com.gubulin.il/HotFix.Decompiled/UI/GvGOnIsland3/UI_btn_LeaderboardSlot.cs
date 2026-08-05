using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_LeaderboardSlot : GButton
{
	public Controller TypeController;

	public Controller RankingType;

	public Controller ScoreType;

	public UI_com_Avatar Avatar;

	public GLoader n2;

	public GImage n13;

	public GTextField PlayerName;

	public GTextField Content;

	public GImage n11;

	public GTextField Ranking;

	public GImage n15;

	public GImage n16;

	public GLoader n17;

	public const string URL = "ui://ebc4ciwrl44l1p";

	public static string Name = "UI_btn_LeaderboardSlot";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l1p";
	}

	public static UI_btn_LeaderboardSlot CreateInstance()
	{
		return (UI_btn_LeaderboardSlot)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_LeaderboardSlot");
	}

	public static UI_btn_LeaderboardSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_LeaderboardSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l1p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TypeController = ((GComponent)this).GetController("TypeController");
		RankingType = ((GComponent)this).GetController("RankingType");
		ScoreType = ((GComponent)this).GetController("ScoreType");
		Avatar = (UI_com_Avatar)(object)((GComponent)this).GetChild("Avatar");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		Content = (GTextField)((GComponent)this).GetChild("Content");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GLoader)((GComponent)this).GetChild("n17");
	}
}
