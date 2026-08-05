using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_IslandMenu : GComponent
{
	public GImage n82;

	public GImage n85;

	public GTextField IslandName;

	public UI_btn_Zoom Zoom;

	public UI_btn_CheckAbility CheckIslandBuff;

	public const string URL = "ui://ebc4ciwrts8027";

	public static string Name = "UI_com_IslandMenu";

	public static string GetURL()
	{
		return "ui://ebc4ciwrts8027";
	}

	public static UI_com_IslandMenu CreateInstance()
	{
		return (UI_com_IslandMenu)(object)UIPackage.CreateObject("GvGOnIsland3", "com_IslandMenu");
	}

	public static UI_com_IslandMenu CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandMenu).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrts8027", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		Zoom = (UI_btn_Zoom)(object)((GComponent)this).GetChild("Zoom");
		CheckIslandBuff = (UI_btn_CheckAbility)(object)((GComponent)this).GetChild("CheckIslandBuff");
	}
}
