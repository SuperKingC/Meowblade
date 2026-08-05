using FairyGUI;
using FairyGUI.Utils;

namespace UI.MonthCard;

public class UI_SecondaryRewardBtn : GButton
{
	public Controller button;

	public Controller RarityController;

	public GGraph n10;

	public GTextField title;

	public GLoader Icon;

	public GTextField num;

	public const string URL = "ui://4ctl553savmfe";

	public static string Name = "UI_SecondaryRewardBtn";

	public static string GetURL()
	{
		return "ui://4ctl553savmfe";
	}

	public static UI_SecondaryRewardBtn CreateInstance()
	{
		return (UI_SecondaryRewardBtn)(object)UIPackage.CreateObject("MonthCard", "SecondaryRewardBtn");
	}

	public static UI_SecondaryRewardBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SecondaryRewardBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553savmfe", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RarityController = ((GComponent)this).GetController("RarityController");
		n10 = (GGraph)((GComponent)this).GetChild("n10");
		title = (GTextField)((GComponent)this).GetChild("title");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
