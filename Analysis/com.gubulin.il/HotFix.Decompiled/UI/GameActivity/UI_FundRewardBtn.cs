using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_FundRewardBtn : GButton
{
	public Controller button;

	public Controller receiveController;

	public GImage iconBack;

	public GGraph squareSfxBack;

	public GGraph activatedSfxBack;

	public GLoader icon;

	public GTextField num;

	public GButton ReceivedBtn;

	public GGraph cumulativeSfxBack;

	public GTextField tip;

	public const string URL = "ui://29q48tv6n4413v";

	public static string Name = "UI_FundRewardBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6n4413v";
	}

	public static UI_FundRewardBtn CreateInstance()
	{
		return (UI_FundRewardBtn)(object)UIPackage.CreateObject("GameActivity", "FundRewardBtn");
	}

	public static UI_FundRewardBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FundRewardBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6n4413v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		receiveController = ((GComponent)this).GetController("receiveController");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		squareSfxBack = (GGraph)((GComponent)this).GetChild("squareSfxBack");
		activatedSfxBack = (GGraph)((GComponent)this).GetChild("activatedSfxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://29q48tv6n4413v".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		ReceivedBtn = (GButton)((GComponent)this).GetChild("ReceivedBtn");
		cumulativeSfxBack = (GGraph)((GComponent)this).GetChild("cumulativeSfxBack");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://29q48tv6n4413v".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
	}
}
