using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_FundBonusBtn : GButton
{
	public Controller button;

	public Controller Day;

	public UI_FundRewardBtn Content;

	public GTextField dayName;

	public const string URL = "ui://29q48tv6n4413u";

	public static string Name = "UI_FundBonusBtn";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://29q48tv6n4413u".Replace("ui://", ""), ((GObject)dayName).id, Day.selectedIndex);
		((GObject)dayName).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://29q48tv6n4413u";
	}

	public static UI_FundBonusBtn CreateInstance()
	{
		return (UI_FundBonusBtn)(object)UIPackage.CreateObject("GameActivity", "FundBonusBtn");
	}

	public static UI_FundBonusBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FundBonusBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6n4413u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Day = ((GComponent)this).GetController("Day");
		Content = (UI_FundRewardBtn)(object)((GComponent)this).GetChild("Content");
		dayName = (GTextField)((GComponent)this).GetChild("dayName");
		string id = "ui://29q48tv6n4413u".Replace("ui://", "") + "-" + ((GObject)dayName).id;
		((GObject)dayName).text = LanguagesManager.GetDesc(id);
	}
}
