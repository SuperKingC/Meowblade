using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_LegendItemForgeConfirm : GComponent
{
	public GImage back;

	public GTextField n1;

	public GTextField n2;

	public GTextField n3;

	public UI_com_LegendItem MainLegendItem;

	public GList CostLegendItems;

	public UI_btn_forge Confirm;

	public UI_btn_CancelForge Cancel;

	public const string URL = "ui://h09dvkcgpqzh33";

	public static string Name = "UI_com_LegendItemForgeConfirm";

	public static string GetURL()
	{
		return "ui://h09dvkcgpqzh33";
	}

	public static UI_com_LegendItemForgeConfirm CreateInstance()
	{
		return (UI_com_LegendItemForgeConfirm)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_LegendItemForgeConfirm");
	}

	public static UI_com_LegendItemForgeConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LegendItemForgeConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgpqzh33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://h09dvkcgpqzh33".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://h09dvkcgpqzh33".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id3 = "ui://h09dvkcgpqzh33".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id3);
		MainLegendItem = (UI_com_LegendItem)(object)((GComponent)this).GetChild("MainLegendItem");
		CostLegendItems = (GList)((GComponent)this).GetChild("CostLegendItems");
		Confirm = (UI_btn_forge)(object)((GComponent)this).GetChild("Confirm");
		Cancel = (UI_btn_CancelForge)(object)((GComponent)this).GetChild("Cancel");
	}
}
