using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ProgressSettlementDisplayingBonus : GComponent
{
	public GImage n3;

	public GImage n4;

	public GLoader BonusIcon;

	public GTextField Desc;

	public const string URL = "ui://4eq8fgd2ko68dg";

	public static string Name = "UI_com_ProgressSettlementDisplayingBonus";

	public static string GetURL()
	{
		return "ui://4eq8fgd2ko68dg";
	}

	public static UI_com_ProgressSettlementDisplayingBonus CreateInstance()
	{
		return (UI_com_ProgressSettlementDisplayingBonus)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ProgressSettlementDisplayingBonus");
	}

	public static UI_com_ProgressSettlementDisplayingBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProgressSettlementDisplayingBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2ko68dg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		BonusIcon = (GLoader)((GComponent)this).GetChild("BonusIcon");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
	}
}
