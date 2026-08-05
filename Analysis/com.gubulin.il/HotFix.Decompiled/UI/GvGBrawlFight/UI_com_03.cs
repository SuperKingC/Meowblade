using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_03 : GComponent
{
	public GImage n23;

	public GImage n24;

	public GImage n25;

	public GImage n26;

	public GTextField n27;

	public GTextField n28;

	public GImage n29;

	public GList listSelf;

	public GList listCamp;

	public const string URL = "ui://hozu168rq3fm65";

	public static string Name = "UI_com_03";

	public static string GetURL()
	{
		return "ui://hozu168rq3fm65";
	}

	public static UI_com_03 CreateInstance()
	{
		return (UI_com_03)(object)UIPackage.CreateObject("GvGBrawlFight", "com_03");
	}

	public static UI_com_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rq3fm65", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id = "ui://hozu168rq3fm65".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id);
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id2 = "ui://hozu168rq3fm65".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id2);
		n29 = (GImage)((GComponent)this).GetChild("n29");
		listSelf = (GList)((GComponent)this).GetChild("listSelf");
		listCamp = (GList)((GComponent)this).GetChild("listCamp");
	}
}
