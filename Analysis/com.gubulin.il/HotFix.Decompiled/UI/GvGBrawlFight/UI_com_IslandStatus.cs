using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_IslandStatus : GComponent
{
	public Controller fightStatus;

	public Controller isFull;

	public GImage n14;

	public GTextField countText;

	public GTextField n16;

	public const string URL = "ui://hozu168r9ykh6m";

	public static string Name = "UI_com_IslandStatus";

	public static string GetURL()
	{
		return "ui://hozu168r9ykh6m";
	}

	public static UI_com_IslandStatus CreateInstance()
	{
		return (UI_com_IslandStatus)(object)UIPackage.CreateObject("GvGBrawlFight", "com_IslandStatus");
	}

	public static UI_com_IslandStatus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandStatus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168r9ykh6m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		fightStatus = ((GComponent)this).GetController("fightStatus");
		isFull = ((GComponent)this).GetController("isFull");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		countText = (GTextField)((GComponent)this).GetChild("countText");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id = "ui://hozu168r9ykh6m".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id);
	}
}
