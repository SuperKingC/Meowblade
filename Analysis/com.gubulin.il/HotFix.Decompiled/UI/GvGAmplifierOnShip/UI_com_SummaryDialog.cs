using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_com_SummaryDialog : GComponent
{
	public Controller Type;

	public UI_com_ShipAmpSummary Summary1;

	public UI_com_ShipAmpSummary Summary2;

	public UI_btn_ConfirmBtn ConfirmBtn;

	public GImage n188;

	public Transition t0;

	public const string URL = "ui://pwlamcyxj7e71n";

	public static string Name = "UI_com_SummaryDialog";

	public static string GetURL()
	{
		return "ui://pwlamcyxj7e71n";
	}

	public static UI_com_SummaryDialog CreateInstance()
	{
		return (UI_com_SummaryDialog)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "com_SummaryDialog");
	}

	public static UI_com_SummaryDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SummaryDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxj7e71n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Summary1 = (UI_com_ShipAmpSummary)(object)((GComponent)this).GetChild("Summary1");
		Summary2 = (UI_com_ShipAmpSummary)(object)((GComponent)this).GetChild("Summary2");
		ConfirmBtn = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		n188 = (GImage)((GComponent)this).GetChild("n188");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
