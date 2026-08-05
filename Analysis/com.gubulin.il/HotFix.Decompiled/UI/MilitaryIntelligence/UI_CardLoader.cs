using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryIntelligence;

public class UI_CardLoader : GComponent
{
	public UI_CardInstanceZones card0;

	public UI_CardExpedition card1;

	public GList cardList;

	public const string URL = "ui://nfd5v46uk67ua";

	public static string Name = "UI_CardLoader";

	public static string GetURL()
	{
		return "ui://nfd5v46uk67ua";
	}

	public static UI_CardLoader CreateInstance()
	{
		return (UI_CardLoader)(object)UIPackage.CreateObject("MilitaryIntelligence", "CardLoader");
	}

	public static UI_CardLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uk67ua", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		card0 = (UI_CardInstanceZones)(object)((GComponent)this).GetChild("card0");
		card1 = (UI_CardExpedition)(object)((GComponent)this).GetChild("card1");
		cardList = (GList)((GComponent)this).GetChild("cardList");
	}
}
