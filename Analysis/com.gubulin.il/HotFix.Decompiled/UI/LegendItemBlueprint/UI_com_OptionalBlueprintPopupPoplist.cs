using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_OptionalBlueprintPopupPoplist : GComponent
{
	public Controller selectPop;

	public GImage selectMainBg;

	public GList mainItemList;

	public UI_com_OptionalBlueprintAttributeList attributeList;

	public UI_com_OptionalBlueprintAttributeListSub subGeneralList;

	public UI_com_ScrollOptionalBlueprint scrollArrow;

	public GImage n14;

	public GGraph closePop;

	public GImage n149;

	public GLoader n151;

	public const string URL = "ui://h09dvkcgb8pv5ltdx";

	public static string Name = "UI_com_OptionalBlueprintPopupPoplist";

	public static string GetURL()
	{
		return "ui://h09dvkcgb8pv5ltdx";
	}

	public static UI_com_OptionalBlueprintPopupPoplist CreateInstance()
	{
		return (UI_com_OptionalBlueprintPopupPoplist)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_OptionalBlueprintPopupPoplist");
	}

	public static UI_com_OptionalBlueprintPopupPoplist CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OptionalBlueprintPopupPoplist).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgb8pv5ltdx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		selectPop = ((GComponent)this).GetController("selectPop");
		selectMainBg = (GImage)((GComponent)this).GetChild("selectMainBg");
		mainItemList = (GList)((GComponent)this).GetChild("mainItemList");
		attributeList = (UI_com_OptionalBlueprintAttributeList)(object)((GComponent)this).GetChild("attributeList");
		subGeneralList = (UI_com_OptionalBlueprintAttributeListSub)(object)((GComponent)this).GetChild("subGeneralList");
		scrollArrow = (UI_com_ScrollOptionalBlueprint)(object)((GComponent)this).GetChild("scrollArrow");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		closePop = (GGraph)((GComponent)this).GetChild("closePop");
		n149 = (GImage)((GComponent)this).GetChild("n149");
		n151 = (GLoader)((GComponent)this).GetChild("n151");
	}
}
