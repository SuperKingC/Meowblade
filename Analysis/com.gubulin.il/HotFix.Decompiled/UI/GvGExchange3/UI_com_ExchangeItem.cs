using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_ExchangeItem : GComponent
{
	public Controller Enough;

	public Controller IsBonus;

	public GLoader Icon;

	public GTextField ReqCnt;

	public GTextField BonusCnt;

	public const string URL = "ui://tt2iq07odwxtg";

	public static string Name = "UI_com_ExchangeItem";

	public static string GetURL()
	{
		return "ui://tt2iq07odwxtg";
	}

	public static UI_com_ExchangeItem CreateInstance()
	{
		return (UI_com_ExchangeItem)(object)UIPackage.CreateObject("GvGExchange3", "com_ExchangeItem");
	}

	public static UI_com_ExchangeItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ExchangeItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxtg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Enough = ((GComponent)this).GetController("Enough");
		IsBonus = ((GComponent)this).GetController("IsBonus");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		ReqCnt = (GTextField)((GComponent)this).GetChild("ReqCnt");
		BonusCnt = (GTextField)((GComponent)this).GetChild("BonusCnt");
	}
}
