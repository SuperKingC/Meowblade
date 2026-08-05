using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_EarningsDetial : GComponent
{
	public GImage n12;

	public GImage n13;

	public GTextField n0;

	public GLoader icon;

	public GTextField output;

	public GButton MoneyExclamationMarkBtn;

	public GTextField moneyStock;

	public GImage n15;

	public GTextField n8;

	public GButton TotalExclamationMarkBtn;

	public GList earnings;

	public const string URL = "ui://c9n2h0ksf258a1";

	public static string Name = "UI_EarningsDetial";

	public static string GetURL()
	{
		return "ui://c9n2h0ksf258a1";
	}

	public static UI_EarningsDetial CreateInstance()
	{
		return (UI_EarningsDetial)(object)UIPackage.CreateObject("WorldMap", "EarningsDetial");
	}

	public static UI_EarningsDetial CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EarningsDetial).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksf258a1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://c9n2h0ksf258a1".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		output = (GTextField)((GComponent)this).GetChild("output");
		string id2 = "ui://c9n2h0ksf258a1".Replace("ui://", "") + "-" + ((GObject)output).id;
		((GObject)output).text = LanguagesManager.GetDesc(id2);
		MoneyExclamationMarkBtn = (GButton)((GComponent)this).GetChild("MoneyExclamationMarkBtn");
		moneyStock = (GTextField)((GComponent)this).GetChild("moneyStock");
		string id3 = "ui://c9n2h0ksf258a1".Replace("ui://", "") + "-" + ((GObject)moneyStock).id;
		((GObject)moneyStock).text = LanguagesManager.GetDesc(id3);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://c9n2h0ksf258a1".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
		TotalExclamationMarkBtn = (GButton)((GComponent)this).GetChild("TotalExclamationMarkBtn");
		earnings = (GList)((GComponent)this).GetChild("earnings");
	}
}
