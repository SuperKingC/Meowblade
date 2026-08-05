using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PvpBattleLogDialog : GComponent
{
	public Controller Type;

	public GImage Background;

	public GImage n6;

	public GList BattleLogList;

	public UI_LogFilter Filter;

	public GTextField n11;

	public const string URL = "ui://82mo10n5uk8wbg";

	public static string Name = "UI_PvpBattleLogDialog";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://82mo10n5uk8wbg".Replace("ui://", ""), ((GObject)n11).id, Type.selectedIndex);
		((GObject)n11).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://82mo10n5uk8wbg";
	}

	public static UI_PvpBattleLogDialog CreateInstance()
	{
		return (UI_PvpBattleLogDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpBattleLogDialog");
	}

	public static UI_PvpBattleLogDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpBattleLogDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5uk8wbg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		BattleLogList = (GList)((GComponent)this).GetChild("BattleLogList");
		Filter = (UI_LogFilter)(object)((GComponent)this).GetChild("Filter");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://82mo10n5uk8wbg".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
	}
}
