using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_targetBtn : GButton
{
	public Controller button;

	public Controller ReceiveStatus;

	public GImage n22;

	public GGraph n23;

	public GTextField title;

	public GTextField num;

	public GButton gotoBtn;

	public UI_receiveBtn receiveBtn;

	public GGraph fxBack;

	public GLoader rewardIcon;

	public GTextField rewardNum;

	public GGraph mask;

	public Transition disappear;

	public const string URL = "ui://29q48tv6gawy1b";

	public static string Name = "UI_targetBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6gawy1b";
	}

	public static UI_targetBtn CreateInstance()
	{
		return (UI_targetBtn)(object)UIPackage.CreateObject("GameActivity", "targetBtn");
	}

	public static UI_targetBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_targetBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawy1b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ReceiveStatus = ((GComponent)this).GetController("ReceiveStatus");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GGraph)((GComponent)this).GetChild("n23");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://29q48tv6gawy1b".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		gotoBtn = (GButton)((GComponent)this).GetChild("gotoBtn");
		receiveBtn = (UI_receiveBtn)(object)((GComponent)this).GetChild("receiveBtn");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		disappear = ((GComponent)this).GetTransition("disappear");
	}
}
