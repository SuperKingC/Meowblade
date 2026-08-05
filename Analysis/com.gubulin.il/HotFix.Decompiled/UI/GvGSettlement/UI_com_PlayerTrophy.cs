using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_PlayerTrophy : GComponent
{
	public Controller RankingType;

	public Controller CampId;

	public Controller IsFirst;

	public GImage n112;

	public GLoader TrophyIcon;

	public GTextField TypeText;

	public GTextField RankingData;

	public GGroup n119;

	public const string URL = "ui://91jxdrkam9tad";

	public static string Name = "UI_com_PlayerTrophy";

	public static string GetURL()
	{
		return "ui://91jxdrkam9tad";
	}

	public static UI_com_PlayerTrophy CreateInstance()
	{
		return (UI_com_PlayerTrophy)(object)UIPackage.CreateObject("GvGSettlement", "com_PlayerTrophy");
	}

	public static UI_com_PlayerTrophy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PlayerTrophy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkam9tad", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		RankingType = ((GComponent)this).GetController("RankingType");
		CampId = ((GComponent)this).GetController("CampId");
		IsFirst = ((GComponent)this).GetController("IsFirst");
		n112 = (GImage)((GComponent)this).GetChild("n112");
		TrophyIcon = (GLoader)((GComponent)this).GetChild("TrophyIcon");
		TypeText = (GTextField)((GComponent)this).GetChild("TypeText");
		RankingData = (GTextField)((GComponent)this).GetChild("RankingData");
		n119 = (GGroup)((GComponent)this).GetChild("n119");
	}
}
