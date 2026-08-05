using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_BattleMiniMap : GComponent
{
	public Controller Type;

	public GTextField DefensiveWave;

	public GList offensiveProgressList;

	public const string URL = "ui://kqd1t06oc5l21k";

	public static string Name = "UI_BattleMiniMap";

	public static string GetURL()
	{
		return "ui://kqd1t06oc5l21k";
	}

	public static UI_BattleMiniMap CreateInstance()
	{
		return (UI_BattleMiniMap)(object)UIPackage.CreateObject("QuickBattle", "BattleMiniMap");
	}

	public static UI_BattleMiniMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BattleMiniMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06oc5l21k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		DefensiveWave = (GTextField)((GComponent)this).GetChild("DefensiveWave");
		string id = "ui://kqd1t06oc5l21k".Replace("ui://", "") + "-" + ((GObject)DefensiveWave).id;
		((GObject)DefensiveWave).text = LanguagesManager.GetDesc(id);
		offensiveProgressList = (GList)((GComponent)this).GetChild("offensiveProgressList");
	}
}
