using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_TodayBestRecord : GComponent
{
	public Controller IsNotEmpty;

	public Controller IsMe;

	public GImage n9;

	public UI_com_ShipAvatarSmall Avatar;

	public GTextField UserName;

	public GImage n2;

	public GTextField Damage;

	public GTextField n5;

	public UI_com_CampRank Rank;

	public GTextField MyRanking;

	public GGroup n8;

	public const string URL = "ui://4eq8fgd2g8des7w";

	public static string Name = "UI_com_TodayBestRecord";

	public static string GetURL()
	{
		return "ui://4eq8fgd2g8des7w";
	}

	public static UI_com_TodayBestRecord CreateInstance()
	{
		return (UI_com_TodayBestRecord)(object)UIPackage.CreateObject("GvGWorldMap3", "com_TodayBestRecord");
	}

	public static UI_com_TodayBestRecord CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TodayBestRecord).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2g8des7w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsNotEmpty = ((GComponent)this).GetController("IsNotEmpty");
		IsMe = ((GComponent)this).GetController("IsMe");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		Avatar = (UI_com_ShipAvatarSmall)(object)((GComponent)this).GetChild("Avatar");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Damage = (GTextField)((GComponent)this).GetChild("Damage");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://4eq8fgd2g8des7w".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		Rank = (UI_com_CampRank)(object)((GComponent)this).GetChild("Rank");
		MyRanking = (GTextField)((GComponent)this).GetChild("MyRanking");
		n8 = (GGroup)((GComponent)this).GetChild("n8");
	}
}
