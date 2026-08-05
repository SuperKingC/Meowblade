using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_BattleSettlementDialog : GComponent
{
	public Controller BattleResult;

	public GImage back;

	public GImage n1;

	public GImage n2;

	public UI_btn_ConfirmBtn ConfirmBrn;

	public GTextField n4;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public UI_com_CampName n8;

	public const string URL = "ui://ebc4ciwr9t3hq4a";

	public static string Name = "UI_com_BattleSettlementDialog";

	public static string GetURL()
	{
		return "ui://ebc4ciwr9t3hq4a";
	}

	public static UI_com_BattleSettlementDialog CreateInstance()
	{
		return (UI_com_BattleSettlementDialog)(object)UIPackage.CreateObject("GvGOnIsland3", "com_BattleSettlementDialog");
	}

	public static UI_com_BattleSettlementDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BattleSettlementDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwr9t3hq4a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BattleResult = ((GComponent)this).GetController("BattleResult");
		back = (GImage)((GComponent)this).GetChild("back");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		ConfirmBrn = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBrn");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://ebc4ciwr9t3hq4a".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://ebc4ciwr9t3hq4a".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		n8 = (UI_com_CampName)(object)((GComponent)this).GetChild("n8");
	}
}
