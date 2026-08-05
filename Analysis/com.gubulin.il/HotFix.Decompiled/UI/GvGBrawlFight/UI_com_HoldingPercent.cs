using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_HoldingPercent : GComponent
{
	public Controller CampId;

	public GImage n8;

	public GImage n0;

	public GImage n9;

	public GTextField ShipCount;

	public GTextField n17;

	public GTextField islandOccupiedCount;

	public GLoader n1;

	public const string URL = "ui://hozu168rkzqx31";

	public static string Name = "UI_com_HoldingPercent";

	public static string GetURL()
	{
		return "ui://hozu168rkzqx31";
	}

	public static UI_com_HoldingPercent CreateInstance()
	{
		return (UI_com_HoldingPercent)(object)UIPackage.CreateObject("GvGBrawlFight", "com_HoldingPercent");
	}

	public static UI_com_HoldingPercent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HoldingPercent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rkzqx31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		ShipCount = (GTextField)((GComponent)this).GetChild("ShipCount");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id = "ui://hozu168rkzqx31".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id);
		islandOccupiedCount = (GTextField)((GComponent)this).GetChild("islandOccupiedCount");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
	}
}
