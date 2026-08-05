using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_ChandeProperty : GComponent
{
	public Controller TyepController;

	public Controller Type;

	public GImage ContentBack;

	public GRichTextField attribute;

	public GRichTextField attribute_max2Line;

	public GImage n10;

	public GTextField Title;

	public GTextField Index;

	public GGraph n17;

	public UI_CostItemAndNum CostItemAndNum;

	public UI_ChangePropetryCancel Cancel;

	public UI_ChangePropetryConfirm Confirm;

	public UI_ChangePropetry ChangePropetry;

	public GGraph attributeSfxBack;

	public GGraph n22;

	public const string URL = "ui://b9wlonaqmpf91e";

	public static string Name = "UI_ChandeProperty";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://b9wlonaqmpf91e".Replace("ui://", ""), ((GObject)Title).id, Type.selectedIndex);
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91e";
	}

	public static UI_ChandeProperty CreateInstance()
	{
		return (UI_ChandeProperty)(object)UIPackage.CreateObject("LegendItemCultivation", "ChandeProperty");
	}

	public static UI_ChandeProperty CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChandeProperty).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TyepController = ((GComponent)this).GetController("TyepController");
		Type = ((GComponent)this).GetController("Type");
		ContentBack = (GImage)((GComponent)this).GetChild("ContentBack");
		attribute = (GRichTextField)((GComponent)this).GetChild("attribute");
		attribute_max2Line = (GRichTextField)((GComponent)this).GetChild("attribute_max2Line");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://b9wlonaqmpf91e".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		Index = (GTextField)((GComponent)this).GetChild("Index");
		n17 = (GGraph)((GComponent)this).GetChild("n17");
		CostItemAndNum = (UI_CostItemAndNum)(object)((GComponent)this).GetChild("CostItemAndNum");
		Cancel = (UI_ChangePropetryCancel)(object)((GComponent)this).GetChild("Cancel");
		Confirm = (UI_ChangePropetryConfirm)(object)((GComponent)this).GetChild("Confirm");
		ChangePropetry = (UI_ChangePropetry)(object)((GComponent)this).GetChild("ChangePropetry");
		attributeSfxBack = (GGraph)((GComponent)this).GetChild("attributeSfxBack");
		n22 = (GGraph)((GComponent)this).GetChild("n22");
	}

	public string GetControllerText(int index)
	{
		string id = string.Format("{0}-{1}-texts_{2}", "ui://b9wlonaqmpf91e".Replace("ui://", ""), ((GObject)Title).id, index);
		return LanguagesManager.GetDesc(id);
	}
}
