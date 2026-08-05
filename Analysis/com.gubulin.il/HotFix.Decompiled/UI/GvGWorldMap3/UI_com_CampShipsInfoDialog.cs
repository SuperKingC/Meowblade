using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_CampShipsInfoDialog : GComponent
{
	public GImage n0;

	public GImage n2;

	public GTextField n3;

	public GList CampList;

	public const string URL = "ui://4eq8fgd2bqhp1w";

	public static string Name = "UI_com_CampShipsInfoDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2bqhp1w";
	}

	public static UI_com_CampShipsInfoDialog CreateInstance()
	{
		return (UI_com_CampShipsInfoDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_CampShipsInfoDialog");
	}

	public static UI_com_CampShipsInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampShipsInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bqhp1w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4eq8fgd2bqhp1w".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		CampList = (GList)((GComponent)this).GetChild("CampList");
	}
}
