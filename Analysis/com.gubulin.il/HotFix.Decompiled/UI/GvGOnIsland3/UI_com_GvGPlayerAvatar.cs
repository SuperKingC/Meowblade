using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_GvGPlayerAvatar : GComponent
{
	public Controller IsShowInfo;

	public Controller State;

	public Controller PlayerType;

	public UI_eff_AvatarMe n15;

	public GGroup n16;

	public GGroup n18;

	public UI_com_Avatar Avatar;

	public GImage n20;

	public UI_eff_AvatarTarget n9;

	public GGroup n10;

	public GMovieClip FightingIcon;

	public GGraph SfxLoader;

	public UI_com_GVGPlayerHolding Holding;

	public GGroup n14;

	public UI_com_PlayerInfo PlayerInfo;

	public GGroup n13;

	public GGroup n19;

	public UI_com_GVGPlayerReforming HoldingBrawlFight;

	public GGroup progressBar;

	public Transition ShipMoveIn;

	public const string URL = "ui://ebc4ciwrjkzvq29";

	public static string Name = "UI_com_GvGPlayerAvatar";

	public static string GetURL()
	{
		return "ui://ebc4ciwrjkzvq29";
	}

	public static UI_com_GvGPlayerAvatar CreateInstance()
	{
		return (UI_com_GvGPlayerAvatar)(object)UIPackage.CreateObject("GvGOnIsland3", "com_GvGPlayerAvatar");
	}

	public static UI_com_GvGPlayerAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GvGPlayerAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrjkzvq29", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowInfo = ((GComponent)this).GetController("IsShowInfo");
		State = ((GComponent)this).GetController("State");
		PlayerType = ((GComponent)this).GetController("PlayerType");
		n15 = (UI_eff_AvatarMe)(object)((GComponent)this).GetChild("n15");
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		Avatar = (UI_com_Avatar)(object)((GComponent)this).GetChild("Avatar");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n9 = (UI_eff_AvatarTarget)(object)((GComponent)this).GetChild("n9");
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		FightingIcon = (GMovieClip)((GComponent)this).GetChild("FightingIcon");
		SfxLoader = (GGraph)((GComponent)this).GetChild("SfxLoader");
		Holding = (UI_com_GVGPlayerHolding)(object)((GComponent)this).GetChild("Holding");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		PlayerInfo = (UI_com_PlayerInfo)(object)((GComponent)this).GetChild("PlayerInfo");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		n19 = (GGroup)((GComponent)this).GetChild("n19");
		HoldingBrawlFight = (UI_com_GVGPlayerReforming)(object)((GComponent)this).GetChild("HoldingBrawlFight");
		progressBar = (GGroup)((GComponent)this).GetChild("progressBar");
		ShipMoveIn = ((GComponent)this).GetTransition("ShipMoveIn");
	}
}
