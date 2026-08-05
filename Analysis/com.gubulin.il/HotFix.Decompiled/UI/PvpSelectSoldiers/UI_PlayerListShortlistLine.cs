using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PlayerListShortlistLine : GComponent
{
	public Controller SchedulePage;

	public GImage n36;

	public GImage n37;

	public GTextField ScoreTypeName;

	public const string URL = "ui://82mo10n5exsyjdqx";

	public static string Name = "UI_PlayerListShortlistLine";

	public static string GetURL()
	{
		return "ui://82mo10n5exsyjdqx";
	}

	public static UI_PlayerListShortlistLine CreateInstance()
	{
		return (UI_PlayerListShortlistLine)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PlayerListShortlistLine");
	}

	public static UI_PlayerListShortlistLine CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayerListShortlistLine).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5exsyjdqx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		SchedulePage = ((GComponent)this).GetController("SchedulePage");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		ScoreTypeName = (GTextField)((GComponent)this).GetChild("ScoreTypeName");
		string id = "ui://82mo10n5exsyjdqx".Replace("ui://", "") + "-" + ((GObject)ScoreTypeName).id;
		((GObject)ScoreTypeName).text = LanguagesManager.GetDesc(id);
	}
}
