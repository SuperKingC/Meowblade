using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_OptionalBlueprintAddAttribute : GComponent
{
	public Controller Type;

	public Controller isSelect;

	public GImage selectProperty;

	public GImage n21;

	public GGroup n27;

	public GImage n26;

	public GImage n24;

	public GImage n25;

	public GImage n23;

	public GImage selectPropertyOutline;

	public GImage n22;

	public GImage n16;

	public GTextField n13;

	public GTextField n15;

	public GTextField n19;

	public GTextField n28;

	public GGroup n20;

	public Transition t0;

	public const string URL = "ui://h09dvkcgb8pv5ltdv";

	public static string Name = "UI_btn_OptionalBlueprintAddAttribute";

	public static string GetURL()
	{
		return "ui://h09dvkcgb8pv5ltdv";
	}

	public static UI_btn_OptionalBlueprintAddAttribute CreateInstance()
	{
		return (UI_btn_OptionalBlueprintAddAttribute)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_OptionalBlueprintAddAttribute");
	}

	public static UI_btn_OptionalBlueprintAddAttribute CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_OptionalBlueprintAddAttribute).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgb8pv5ltdv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		isSelect = ((GComponent)this).GetController("isSelect");
		selectProperty = (GImage)((GComponent)this).GetChild("selectProperty");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n27 = (GGroup)((GComponent)this).GetChild("n27");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		selectPropertyOutline = (GImage)((GComponent)this).GetChild("selectPropertyOutline");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://h09dvkcgb8pv5ltdv".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id2 = "ui://h09dvkcgb8pv5ltdv".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id2);
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id3 = "ui://h09dvkcgb8pv5ltdv".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id3);
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id4 = "ui://h09dvkcgb8pv5ltdv".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id4);
		n20 = (GGroup)((GComponent)this).GetChild("n20");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
