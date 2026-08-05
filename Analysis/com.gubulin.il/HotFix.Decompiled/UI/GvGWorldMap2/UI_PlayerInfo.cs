using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_PlayerInfo : GComponent
{
	public Controller CampId;

	public GImage n1;

	public GTextField PlayerName;

	public GImage n4;

	public GTextField SoldierNum;

	public GGroup wrapperGroup;

	public const string URL = "ui://hd2s9kukxwnq46";

	public static string Name = "UI_PlayerInfo";

	public static string GetURL()
	{
		return "ui://hd2s9kukxwnq46";
	}

	public static UI_PlayerInfo CreateInstance()
	{
		return (UI_PlayerInfo)(object)UIPackage.CreateObject("GvGWorldMap2", "PlayerInfo");
	}

	public static UI_PlayerInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayerInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukxwnq46", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		SoldierNum = (GTextField)((GComponent)this).GetChild("SoldierNum");
		string id = "ui://hd2s9kukxwnq46".Replace("ui://", "") + "-" + ((GObject)SoldierNum).id;
		((GObject)SoldierNum).text = LanguagesManager.GetDesc(id);
		wrapperGroup = (GGroup)((GComponent)this).GetChild("wrapperGroup");
	}
}
