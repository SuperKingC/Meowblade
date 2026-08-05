using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_IncomeBtn : GButton
{
	public Controller button;

	public GTextField IncomeTitle;

	public GLoader icon;

	public GTextField curIncome;

	public GTextField nextIncome;

	public GImage n10;

	public Transition ShowIncome;

	public const string URL = "ui://hda5vzklv93k32";

	public static string Name = "UI_IncomeBtn";

	public static string GetURL()
	{
		return "ui://hda5vzklv93k32";
	}

	public static UI_IncomeBtn CreateInstance()
	{
		return (UI_IncomeBtn)(object)UIPackage.CreateObject("GameEndPanels", "IncomeBtn");
	}

	public static UI_IncomeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IncomeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklv93k32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IncomeTitle = (GTextField)((GComponent)this).GetChild("IncomeTitle");
		string id = "ui://hda5vzklv93k32".Replace("ui://", "") + "-" + ((GObject)IncomeTitle).id;
		((GObject)IncomeTitle).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		curIncome = (GTextField)((GComponent)this).GetChild("curIncome");
		string id2 = "ui://hda5vzklv93k32".Replace("ui://", "") + "-" + ((GObject)curIncome).id;
		((GObject)curIncome).text = LanguagesManager.GetDesc(id2);
		nextIncome = (GTextField)((GComponent)this).GetChild("nextIncome");
		string id3 = "ui://hda5vzklv93k32".Replace("ui://", "") + "-" + ((GObject)nextIncome).id;
		((GObject)nextIncome).text = LanguagesManager.GetDesc(id3);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		ShowIncome = ((GComponent)this).GetTransition("ShowIncome");
	}
}
