using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_ShipOverview : GComponent
{
	public GImage n108;

	public GImage n109;

	public GTextField ShipsCount;

	public GImage n111;

	public GTextField n112;

	public const string URL = "ui://4eq8fgd2eoq9d9";

	public static string Name = "UI_btn_ShipOverview";

	public static string GetURL()
	{
		return "ui://4eq8fgd2eoq9d9";
	}

	public static UI_btn_ShipOverview CreateInstance()
	{
		return (UI_btn_ShipOverview)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_ShipOverview");
	}

	public static UI_btn_ShipOverview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ShipOverview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2eoq9d9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n108 = (GImage)((GComponent)this).GetChild("n108");
		n109 = (GImage)((GComponent)this).GetChild("n109");
		ShipsCount = (GTextField)((GComponent)this).GetChild("ShipsCount");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		n112 = (GTextField)((GComponent)this).GetChild("n112");
		string id = "ui://4eq8fgd2eoq9d9".Replace("ui://", "") + "-" + ((GObject)n112).id;
		((GObject)n112).text = LanguagesManager.GetDesc(id);
	}
}
