using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_PropItemLong : GComponent
{
	public Controller State;

	public Controller HasTip;

	public GTextField EffectRange;

	public GTextField PropName;

	public GTextField PropEffect;

	public GImage n82;

	public GImage n84;

	public GImage n85;

	public const string URL = "ui://pwlamcyxusns1o";

	public static string Name = "UI_PropItemLong";

	public static string GetURL()
	{
		return "ui://pwlamcyxusns1o";
	}

	public static UI_PropItemLong CreateInstance()
	{
		return (UI_PropItemLong)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "PropItemLong");
	}

	public static UI_PropItemLong CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PropItemLong).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxusns1o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		HasTip = ((GComponent)this).GetController("HasTip");
		EffectRange = (GTextField)((GComponent)this).GetChild("EffectRange");
		PropName = (GTextField)((GComponent)this).GetChild("PropName");
		PropEffect = (GTextField)((GComponent)this).GetChild("PropEffect");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
	}
}
