using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_PlayerInfo : GComponent
{
	public GGraph n1;

	public GTextField PlayerName;

	public GImage n4;

	public GTextField SoldierNum;

	public GGroup wrapperGroup;

	public const string URL = "ui://0i520nzmrecpobk";

	public static string Name = "UI_PlayerInfo";

	public static string GetURL()
	{
		return "ui://0i520nzmrecpobk";
	}

	public static UI_PlayerInfo CreateInstance()
	{
		return (UI_PlayerInfo)(object)UIPackage.CreateObject("LordOfDreams", "PlayerInfo");
	}

	public static UI_PlayerInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayerInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmrecpobk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		SoldierNum = (GTextField)((GComponent)this).GetChild("SoldierNum");
		string id = "ui://0i520nzmrecpobk".Replace("ui://", "") + "-" + ((GObject)SoldierNum).id;
		((GObject)SoldierNum).text = LanguagesManager.GetDesc(id);
		wrapperGroup = (GGroup)((GComponent)this).GetChild("wrapperGroup");
	}
}
