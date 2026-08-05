using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ExchangeShelf : GComponent
{
	public Controller IsExchangeMoneyExceedLimit;

	public GImage n15;

	public GImage n16;

	public GImage n39;

	public GImage n18;

	public GImage n40;

	public GImage n20;

	public GImage n21;

	public GImage n32;

	public GTextField n33;

	public UI_mc_Slot Currency;

	public UI_mc_Slot Money;

	public GImage n36;

	public UI_btn_Exchange Exchange;

	public GGroup n38;

	public GTextField n31;

	public GTextField n41;

	public Transition t0;

	public const string URL = "ui://k2sprg26laau6v";

	public static string Name = "UI_ExchangeShelf";

	public static string GetURL()
	{
		return "ui://k2sprg26laau6v";
	}

	public static UI_ExchangeShelf CreateInstance()
	{
		return (UI_ExchangeShelf)(object)UIPackage.CreateObject("IslandComeAgain", "ExchangeShelf");
	}

	public static UI_ExchangeShelf CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExchangeShelf).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau6v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsExchangeMoneyExceedLimit = ((GComponent)this).GetController("IsExchangeMoneyExceedLimit");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id = "ui://k2sprg26laau6v".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id);
		Currency = (UI_mc_Slot)(object)((GComponent)this).GetChild("Currency");
		Money = (UI_mc_Slot)(object)((GComponent)this).GetChild("Money");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		Exchange = (UI_btn_Exchange)(object)((GComponent)this).GetChild("Exchange");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id2 = "ui://k2sprg26laau6v".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id2);
		n41 = (GTextField)((GComponent)this).GetChild("n41");
		string id3 = "ui://k2sprg26laau6v".Replace("ui://", "") + "-" + ((GObject)n41).id;
		((GObject)n41).text = LanguagesManager.GetDesc(id3);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
