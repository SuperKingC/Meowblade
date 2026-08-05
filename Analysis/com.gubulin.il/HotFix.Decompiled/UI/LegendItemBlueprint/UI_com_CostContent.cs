using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_CostContent : GComponent
{
	public GImage n1;

	public GTextField n2;

	public UI_com_LegendItemCost MainLegendItem;

	public GTextField n6;

	public GTextField n7;

	public GList CostLegendItems;

	public GTextField n9;

	public GList CostItems;

	public const string URL = "ui://h09dvkcgjpqa15";

	public static string Name = "UI_com_CostContent";

	public static string GetURL()
	{
		return "ui://h09dvkcgjpqa15";
	}

	public static UI_com_CostContent CreateInstance()
	{
		return (UI_com_CostContent)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_CostContent");
	}

	public static UI_com_CostContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CostContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgjpqa15", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://h09dvkcgjpqa15".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		MainLegendItem = (UI_com_LegendItemCost)(object)((GComponent)this).GetChild("MainLegendItem");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://h09dvkcgjpqa15".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://h09dvkcgjpqa15".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		CostLegendItems = (GList)((GComponent)this).GetChild("CostLegendItems");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id4 = "ui://h09dvkcgjpqa15".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id4);
		CostItems = (GList)((GComponent)this).GetChild("CostItems");
	}
}
