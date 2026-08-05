using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_LegendItemEvoConfirm : GComponent
{
	public GImage chooseListBack;

	public GTextField n3;

	public GTextField n4;

	public GImage n9;

	public GImage arrowIcon;

	public GTextField n7;

	public GGroup n11;

	public UI_com_LegendItem EvoLegendItem;

	public UI_btn_forge Confirm;

	public GTextField n6;

	public const string URL = "ui://h09dvkcgpqzh31";

	public static string Name = "UI_com_LegendItemEvoConfirm";

	public static string GetURL()
	{
		return "ui://h09dvkcgpqzh31";
	}

	public static UI_com_LegendItemEvoConfirm CreateInstance()
	{
		return (UI_com_LegendItemEvoConfirm)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_LegendItemEvoConfirm");
	}

	public static UI_com_LegendItemEvoConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LegendItemEvoConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgpqzh31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		chooseListBack = (GImage)((GComponent)this).GetChild("chooseListBack");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://h09dvkcgpqzh31".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://h09dvkcgpqzh31".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n9 = (GImage)((GComponent)this).GetChild("n9");
		arrowIcon = (GImage)((GComponent)this).GetChild("arrowIcon");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://h09dvkcgpqzh31".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		n11 = (GGroup)((GComponent)this).GetChild("n11");
		EvoLegendItem = (UI_com_LegendItem)(object)((GComponent)this).GetChild("EvoLegendItem");
		Confirm = (UI_btn_forge)(object)((GComponent)this).GetChild("Confirm");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id4 = "ui://h09dvkcgpqzh31".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id4);
	}
}
