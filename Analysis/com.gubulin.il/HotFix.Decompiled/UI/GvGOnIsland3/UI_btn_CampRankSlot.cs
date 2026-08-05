using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_CampRankSlot : GButton
{
	public Controller TypeController;

	public Controller CampType;

	public Controller ScoreType;

	public GLoader Avatar;

	public GLoader n2;

	public GImage n13;

	public GTextField PlayerName;

	public GTextField Content;

	public GTextField Ranking;

	public GLoader n16;

	public const string URL = "ui://ebc4ciwrj962q6k";

	public static string Name = "UI_btn_CampRankSlot";

	public static string GetURL()
	{
		return "ui://ebc4ciwrj962q6k";
	}

	public static UI_btn_CampRankSlot CreateInstance()
	{
		return (UI_btn_CampRankSlot)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_CampRankSlot");
	}

	public static UI_btn_CampRankSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CampRankSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrj962q6k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
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
		((GComponent)this).ConstructFromXML(xml);
		TypeController = ((GComponent)this).GetController("TypeController");
		CampType = ((GComponent)this).GetController("CampType");
		ScoreType = ((GComponent)this).GetController("ScoreType");
		Avatar = (GLoader)((GComponent)this).GetChild("Avatar");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		Content = (GTextField)((GComponent)this).GetChild("Content");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		n16 = (GLoader)((GComponent)this).GetChild("n16");
	}
}
