using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_CampShipsInfoDialog : GComponent
{
	public GGraph n0;

	public GGraph n2;

	public GTextField n3;

	public GList CampList;

	public const string URL = "ui://k2sprg26oc3d8t";

	public static string Name = "UI_CampShipsInfoDialog";

	public static string GetURL()
	{
		return "ui://k2sprg26oc3d8t";
	}

	public static UI_CampShipsInfoDialog CreateInstance()
	{
		return (UI_CampShipsInfoDialog)(object)UIPackage.CreateObject("IslandComeAgain", "CampShipsInfoDialog");
	}

	public static UI_CampShipsInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CampShipsInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26oc3d8t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://k2sprg26oc3d8t".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		CampList = (GList)((GComponent)this).GetChild("CampList");
	}
}
