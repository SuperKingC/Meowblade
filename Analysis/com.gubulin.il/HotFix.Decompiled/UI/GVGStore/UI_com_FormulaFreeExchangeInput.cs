using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_FormulaFreeExchangeInput : GComponent
{
	public Controller Type;

	public GImage n5;

	public GImage back;

	public GList Input;

	public GImage n2;

	public GImage n3;

	public GList Formulas;

	public GImage n6;

	public const string URL = "ui://fvc33k3g7nboj";

	public static string Name = "UI_com_FormulaFreeExchangeInput";

	private IDropDownController _dropDownController;

	public IDropDownController DropDownController => _dropDownController ?? (_dropDownController = new DropDownController(((GComponent)this).GetController("Type")));

	public static string GetURL()
	{
		return "ui://fvc33k3g7nboj";
	}

	public static UI_com_FormulaFreeExchangeInput CreateInstance()
	{
		return (UI_com_FormulaFreeExchangeInput)(object)UIPackage.CreateObject("GVGStore", "com_FormulaFreeExchangeInput");
	}

	public static UI_com_FormulaFreeExchangeInput CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaFreeExchangeInput).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3g7nboj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		back = (GImage)((GComponent)this).GetChild("back");
		Input = (GList)((GComponent)this).GetChild("Input");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Formulas = (GList)((GComponent)this).GetChild("Formulas");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
