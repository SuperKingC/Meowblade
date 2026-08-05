using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MonthCard;

public class UI_ContractCard : GComponent
{
	public Controller StatusController;

	public Controller RarityController;

	public Controller showAssistantBtn;

	public GImage back0;

	public GImage back1;

	public GMovieClip n75;

	public GMovieClip n76;

	public GImage n63;

	public GMovieClip n77;

	public GMovieClip n79;

	public GImage n64;

	public GGraph n65;

	public GGraph n66;

	public GGraph n68;

	public GGraph n69;

	public GGroup n67;

	public GImage n70;

	public UI_PrivilegeBtn PrivilegeBtn;

	public UI_ConfirmTakeBtn ConfirmTakeBtn;

	public GImage n73;

	public GImage n74;

	public GList SecondaryRewardList;

	public GTextField primaryBenefitTitle;

	public GLoader primaryBenefitIcon;

	public GTextField primaryBenefitNum;

	public GGroup n52;

	public UI_ConfirmBuyBtn ConfirmBuyBtn;

	public UI_ContinueBuyBtn ContinueBuyBtn;

	public UI_countdownBtn CountdownBtn;

	public UI_EffectiveSfxBack EffectiveSfxBack;

	public GGraph SfxBack;

	public GImage n58;

	public GImage n56;

	public GImage n57;

	public GLoader currencyIcon;

	public GGroup PriceImgs;

	public GTextField PriceText;

	public GGroup n62;

	public Transition LightBreathing;

	public const string URL = "ui://4ctl553sjgrlh";

	public static string Name = "UI_ContractCard";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://4ctl553sjgrlh".Replace("ui://", ""), ((GObject)ConfirmTakeBtn).id, StatusController.selectedIndex);
		((GButton)ConfirmTakeBtn).title = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://4ctl553sjgrlh";
	}

	public static UI_ContractCard CreateInstance()
	{
		return (UI_ContractCard)(object)UIPackage.CreateObject("MonthCard", "ContractCard");
	}

	public static UI_ContractCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ContractCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sjgrlh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StatusController = ((GComponent)this).GetController("StatusController");
		RarityController = ((GComponent)this).GetController("RarityController");
		showAssistantBtn = ((GComponent)this).GetController("showAssistantBtn");
		back0 = (GImage)((GComponent)this).GetChild("back0");
		back1 = (GImage)((GComponent)this).GetChild("back1");
		n75 = (GMovieClip)((GComponent)this).GetChild("n75");
		n76 = (GMovieClip)((GComponent)this).GetChild("n76");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n77 = (GMovieClip)((GComponent)this).GetChild("n77");
		n79 = (GMovieClip)((GComponent)this).GetChild("n79");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n65 = (GGraph)((GComponent)this).GetChild("n65");
		n66 = (GGraph)((GComponent)this).GetChild("n66");
		n68 = (GGraph)((GComponent)this).GetChild("n68");
		n69 = (GGraph)((GComponent)this).GetChild("n69");
		n67 = (GGroup)((GComponent)this).GetChild("n67");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		PrivilegeBtn = (UI_PrivilegeBtn)(object)((GComponent)this).GetChild("PrivilegeBtn");
		ConfirmTakeBtn = (UI_ConfirmTakeBtn)(object)((GComponent)this).GetChild("ConfirmTakeBtn");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		SecondaryRewardList = (GList)((GComponent)this).GetChild("SecondaryRewardList");
		primaryBenefitTitle = (GTextField)((GComponent)this).GetChild("primaryBenefitTitle");
		primaryBenefitIcon = (GLoader)((GComponent)this).GetChild("primaryBenefitIcon");
		primaryBenefitNum = (GTextField)((GComponent)this).GetChild("primaryBenefitNum");
		string id = "ui://4ctl553sjgrlh".Replace("ui://", "") + "-" + ((GObject)primaryBenefitNum).id;
		((GObject)primaryBenefitNum).text = LanguagesManager.GetDesc(id);
		n52 = (GGroup)((GComponent)this).GetChild("n52");
		ConfirmBuyBtn = (UI_ConfirmBuyBtn)(object)((GComponent)this).GetChild("ConfirmBuyBtn");
		ContinueBuyBtn = (UI_ContinueBuyBtn)(object)((GComponent)this).GetChild("ContinueBuyBtn");
		CountdownBtn = (UI_countdownBtn)(object)((GComponent)this).GetChild("CountdownBtn");
		EffectiveSfxBack = (UI_EffectiveSfxBack)(object)((GComponent)this).GetChild("EffectiveSfxBack");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		currencyIcon = (GLoader)((GComponent)this).GetChild("currencyIcon");
		PriceImgs = (GGroup)((GComponent)this).GetChild("PriceImgs");
		PriceText = (GTextField)((GComponent)this).GetChild("PriceText");
		n62 = (GGroup)((GComponent)this).GetChild("n62");
		LightBreathing = ((GComponent)this).GetTransition("LightBreathing");
	}
}
