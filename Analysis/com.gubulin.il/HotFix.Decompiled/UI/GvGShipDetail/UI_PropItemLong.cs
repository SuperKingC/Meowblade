using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_PropItemLong : GComponent
{
	public Controller HasTip;

	public GTextField EffectRange;

	public GTextField PropName;

	public GTextField PropEffect;

	public GImage n82;

	public const string URL = "ui://u6x0b1gnzpu41s";

	public static string Name = "UI_PropItemLong";

	public static string GetURL()
	{
		return "ui://u6x0b1gnzpu41s";
	}

	public static UI_PropItemLong CreateInstance()
	{
		return (UI_PropItemLong)(object)UIPackage.CreateObject("GvGShipDetail", "PropItemLong");
	}

	public static UI_PropItemLong CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PropItemLong).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnzpu41s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		HasTip = ((GComponent)this).GetController("HasTip");
		EffectRange = (GTextField)((GComponent)this).GetChild("EffectRange");
		PropName = (GTextField)((GComponent)this).GetChild("PropName");
		PropEffect = (GTextField)((GComponent)this).GetChild("PropEffect");
		n82 = (GImage)((GComponent)this).GetChild("n82");
	}
}
