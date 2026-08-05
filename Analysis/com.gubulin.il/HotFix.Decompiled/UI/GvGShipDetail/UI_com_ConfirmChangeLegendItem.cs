using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_ConfirmChangeLegendItem : GComponent
{
	public GImage n0;

	public UI_btn_ChangeLegendItem Confirm;

	public GTextField n2;

	public UI_btn_DoNotShowAgain DoNotShowAgain;

	public GTextField n4;

	public const string URL = "ui://u6x0b1gnoip462";

	public static string Name = "UI_com_ConfirmChangeLegendItem";

	public static string GetURL()
	{
		return "ui://u6x0b1gnoip462";
	}

	public static UI_com_ConfirmChangeLegendItem CreateInstance()
	{
		return (UI_com_ConfirmChangeLegendItem)(object)UIPackage.CreateObject("GvGShipDetail", "com_ConfirmChangeLegendItem");
	}

	public static UI_com_ConfirmChangeLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ConfirmChangeLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnoip462", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Confirm = (UI_btn_ChangeLegendItem)(object)((GComponent)this).GetChild("Confirm");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://u6x0b1gnoip462".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		DoNotShowAgain = (UI_btn_DoNotShowAgain)(object)((GComponent)this).GetChild("DoNotShowAgain");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://u6x0b1gnoip462".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
	}
}
