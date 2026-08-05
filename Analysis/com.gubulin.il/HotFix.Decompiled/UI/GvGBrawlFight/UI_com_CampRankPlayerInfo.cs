using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_CampRankPlayerInfo : GComponent
{
	public Controller IsMvp;

	public Controller HasIsland;

	public GImage back;

	public GImage n8;

	public GImage n9;

	public GImage n3;

	public GImage n10;

	public GComponent Avatar;

	public GList Islands;

	public GTextField n6;

	public GTextField PlayerName;

	public GLoader n11;

	public GTextField Score;

	public GGroup n13;

	public const string URL = "ui://hozu168rhd0n9f";

	public static string Name = "UI_com_CampRankPlayerInfo";

	public static string GetURL()
	{
		return "ui://hozu168rhd0n9f";
	}

	public static UI_com_CampRankPlayerInfo CreateInstance()
	{
		return (UI_com_CampRankPlayerInfo)(object)UIPackage.CreateObject("GvGBrawlFight", "com_CampRankPlayerInfo");
	}

	public static UI_com_CampRankPlayerInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampRankPlayerInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rhd0n9f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsMvp = ((GComponent)this).GetController("IsMvp");
		HasIsland = ((GComponent)this).GetController("HasIsland");
		back = (GImage)((GComponent)this).GetChild("back");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Avatar = (GComponent)((GComponent)this).GetChild("Avatar");
		Islands = (GList)((GComponent)this).GetChild("Islands");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://hozu168rhd0n9f".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		n11 = (GLoader)((GComponent)this).GetChild("n11");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
	}
}
