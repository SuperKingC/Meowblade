using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_GvGPlayerAvatar : GComponent
{
	public Controller IsShowInfo;

	public Controller State;

	public Controller PlayerType;

	public GLoader n15;

	public GGroup n16;

	public GGroup n18;

	public UI_Avatar Avatar;

	public GLoader n9;

	public GGroup n10;

	public GMovieClip FightingIcon;

	public GGraph SfxLoader;

	public UI_GVGPlayerHolding Holding;

	public GGroup n14;

	public UI_PlayerInfo PlayerInfo;

	public GGroup n13;

	public const string URL = "ui://hd2s9kukxwnq45";

	public static string Name = "UI_GvGPlayerAvatar";

	public static string GetURL()
	{
		return "ui://hd2s9kukxwnq45";
	}

	public static UI_GvGPlayerAvatar CreateInstance()
	{
		return (UI_GvGPlayerAvatar)(object)UIPackage.CreateObject("GvGWorldMap2", "GvGPlayerAvatar");
	}

	public static UI_GvGPlayerAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGPlayerAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukxwnq45", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowInfo = ((GComponent)this).GetController("IsShowInfo");
		State = ((GComponent)this).GetController("State");
		PlayerType = ((GComponent)this).GetController("PlayerType");
		n15 = (GLoader)((GComponent)this).GetChild("n15");
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		n9 = (GLoader)((GComponent)this).GetChild("n9");
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		FightingIcon = (GMovieClip)((GComponent)this).GetChild("FightingIcon");
		SfxLoader = (GGraph)((GComponent)this).GetChild("SfxLoader");
		Holding = (UI_GVGPlayerHolding)(object)((GComponent)this).GetChild("Holding");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		PlayerInfo = (UI_PlayerInfo)(object)((GComponent)this).GetChild("PlayerInfo");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
	}
}
