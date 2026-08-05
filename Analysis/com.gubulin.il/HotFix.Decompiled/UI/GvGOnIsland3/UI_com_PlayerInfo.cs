using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_PlayerInfo : GComponent
{
	public Controller CampId;

	public Controller BuffType;

	public GImage n1;

	public GTextField PlayerName;

	public GImage n4;

	public GTextField SoldierNum;

	public GGroup wrapperGroup;

	public GImage n6;

	public const string URL = "ui://ebc4ciwrjkzvq2h";

	public static string Name = "UI_com_PlayerInfo";

	public static string GetURL()
	{
		return "ui://ebc4ciwrjkzvq2h";
	}

	public static UI_com_PlayerInfo CreateInstance()
	{
		return (UI_com_PlayerInfo)(object)UIPackage.CreateObject("GvGOnIsland3", "com_PlayerInfo");
	}

	public static UI_com_PlayerInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PlayerInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrjkzvq2h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		BuffType = ((GComponent)this).GetController("BuffType");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		SoldierNum = (GTextField)((GComponent)this).GetChild("SoldierNum");
		string id = "ui://ebc4ciwrjkzvq2h".Replace("ui://", "") + "-" + ((GObject)SoldierNum).id;
		((GObject)SoldierNum).text = LanguagesManager.GetDesc(id);
		wrapperGroup = (GGroup)((GComponent)this).GetChild("wrapperGroup");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
