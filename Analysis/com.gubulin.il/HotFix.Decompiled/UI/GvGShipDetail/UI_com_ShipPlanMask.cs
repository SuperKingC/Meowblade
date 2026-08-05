using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_ShipPlanMask : GComponent
{
	public GImage n0;

	public GImage n1;

	public GTextField n2;

	public GTextField n3;

	public const string URL = "ui://u6x0b1gnefz67k";

	public static string Name = "UI_com_ShipPlanMask";

	public static string GetURL()
	{
		return "ui://u6x0b1gnefz67k";
	}

	public static UI_com_ShipPlanMask CreateInstance()
	{
		return (UI_com_ShipPlanMask)(object)UIPackage.CreateObject("GvGShipDetail", "com_ShipPlanMask");
	}

	public static UI_com_ShipPlanMask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipPlanMask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnefz67k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://u6x0b1gnefz67k".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://u6x0b1gnefz67k".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
	}
}
