using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_FundRewardBtn2 : GButton
{
	public Controller button;

	public Controller receiveController;

	public GImage n11;

	public GImage n12;

	public GImage n17;

	public GImage iconBack;

	public GGraph squareSfxBack;

	public GGraph activatedSfxBack;

	public GLoader icon;

	public GTextField num;

	public GImage n13;

	public GImage n14;

	public GTextField Tip;

	public GButton ReceivedBtn;

	public GGraph cumulativeSfxBack;

	public GMovieClip n16;

	public Transition t0;

	public const string URL = "ui://29q48tv6962vaf";

	public static string Name = "UI_FundRewardBtn2";

	public static string GetURL()
	{
		return "ui://29q48tv6962vaf";
	}

	public static UI_FundRewardBtn2 CreateInstance()
	{
		return (UI_FundRewardBtn2)(object)UIPackage.CreateObject("GameActivity", "FundRewardBtn2");
	}

	public static UI_FundRewardBtn2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FundRewardBtn2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6962vaf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		receiveController = ((GComponent)this).GetController("receiveController");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		squareSfxBack = (GGraph)((GComponent)this).GetChild("squareSfxBack");
		activatedSfxBack = (GGraph)((GComponent)this).GetChild("activatedSfxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://29q48tv6962vaf".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id2 = "ui://29q48tv6962vaf".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id2);
		ReceivedBtn = (GButton)((GComponent)this).GetChild("ReceivedBtn");
		cumulativeSfxBack = (GGraph)((GComponent)this).GetChild("cumulativeSfxBack");
		n16 = (GMovieClip)((GComponent)this).GetChild("n16");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
