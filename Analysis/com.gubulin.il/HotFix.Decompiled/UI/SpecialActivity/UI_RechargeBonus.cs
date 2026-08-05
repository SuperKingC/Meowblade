using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_RechargeBonus : GButton
{
	public Controller button;

	public Controller ReceiveStatus;

	public GImage back;

	public GTextField title;

	public GTextField num;

	public UI_receiveBtn receiveBtn;

	public GList BonusList;

	public GGraph mask;

	public Transition disappear;

	public const string URL = "ui://kozswd8hqyx61d";

	public static string Name = "UI_RechargeBonus";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://kozswd8hfxue1j".Replace("ui://", ""), ((GObject)receiveBtn).id, ReceiveStatus.selectedIndex);
		((GObject)receiveBtn).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://kozswd8hqyx61d";
	}

	public static UI_RechargeBonus CreateInstance()
	{
		return (UI_RechargeBonus)(object)UIPackage.CreateObject("SpecialActivity", "RechargeBonus");
	}

	public static UI_RechargeBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hqyx61d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ReceiveStatus = ((GComponent)this).GetController("ReceiveStatus");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kozswd8hqyx61d".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		receiveBtn = (UI_receiveBtn)(object)((GComponent)this).GetChild("receiveBtn");
		BonusList = (GList)((GComponent)this).GetChild("BonusList");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		disappear = ((GComponent)this).GetTransition("disappear");
	}
}
