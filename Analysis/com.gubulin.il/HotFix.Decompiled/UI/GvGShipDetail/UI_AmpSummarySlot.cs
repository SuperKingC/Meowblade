using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_AmpSummarySlot : GComponent
{
	public Controller Type;

	public GImage n98;

	public GImage n97;

	public GImage n94;

	public GLoader n95;

	public GTextField Total;

	public const string URL = "ui://u6x0b1gndxsb2a";

	public static string Name = "UI_AmpSummarySlot";

	public static string GetURL()
	{
		return "ui://u6x0b1gndxsb2a";
	}

	public static UI_AmpSummarySlot CreateInstance()
	{
		return (UI_AmpSummarySlot)(object)UIPackage.CreateObject("GvGShipDetail", "AmpSummarySlot");
	}

	public static UI_AmpSummarySlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AmpSummarySlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gndxsb2a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n98 = (GImage)((GComponent)this).GetChild("n98");
		n97 = (GImage)((GComponent)this).GetChild("n97");
		n94 = (GImage)((GComponent)this).GetChild("n94");
		n95 = (GLoader)((GComponent)this).GetChild("n95");
		Total = (GTextField)((GComponent)this).GetChild("Total");
	}
}
