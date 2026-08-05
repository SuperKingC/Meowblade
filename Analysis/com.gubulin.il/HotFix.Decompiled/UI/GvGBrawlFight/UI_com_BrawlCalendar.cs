using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlCalendar : GComponent
{
	public GImage n0;

	public GImage n3;

	public GList ClaimedInfos;

	public GTextField n2;

	public const string URL = "ui://hozu168rnyh53g";

	public static string Name = "UI_com_BrawlCalendar";

	public static string GetURL()
	{
		return "ui://hozu168rnyh53g";
	}

	public static UI_com_BrawlCalendar CreateInstance()
	{
		return (UI_com_BrawlCalendar)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlCalendar");
	}

	public static UI_com_BrawlCalendar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlCalendar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnyh53g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		ClaimedInfos = (GList)((GComponent)this).GetChild("ClaimedInfos");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://hozu168rnyh53g".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
	}
}
