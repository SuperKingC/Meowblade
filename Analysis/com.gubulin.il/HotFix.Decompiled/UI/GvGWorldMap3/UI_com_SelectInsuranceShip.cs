using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_SelectInsuranceShip : GComponent
{
	public GImage n0;

	public GImage n4;

	public GTextField Tip;

	public GButton Confirm;

	public GList Ships;

	public const string URL = "ui://4eq8fgd2eo52b6sdc";

	public static string Name = "UI_com_SelectInsuranceShip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2eo52b6sdc";
	}

	public static UI_com_SelectInsuranceShip CreateInstance()
	{
		return (UI_com_SelectInsuranceShip)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SelectInsuranceShip");
	}

	public static UI_com_SelectInsuranceShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SelectInsuranceShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2eo52b6sdc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id = "ui://4eq8fgd2eo52b6sdc".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id);
		Confirm = (GButton)((GComponent)this).GetChild("Confirm");
		Ships = (GList)((GComponent)this).GetChild("Ships");
	}
}
