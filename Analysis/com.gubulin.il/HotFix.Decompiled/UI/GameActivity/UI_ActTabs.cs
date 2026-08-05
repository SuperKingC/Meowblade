using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_ActTabs : GButton
{
	public Controller button;

	public Controller backController;

	public Controller Status;

	public Controller TipFormat;

	public Controller Type;

	public GImage n15;

	public GImage n18;

	public GTextField title;

	public GImage note;

	public GTextField tip;

	public GImage newLogo;

	public GImage n9;

	public GImage timeLimit;

	public GGroup cornerMark;

	public const string URL = "ui://29q48tv6n44141";

	public static string Name = "UI_ActTabs";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://29q48tv6n44141".Replace("ui://", ""), ((GObject)tip).id, TipFormat.selectedIndex);
		((GObject)tip).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://29q48tv6n44141";
	}

	public static UI_ActTabs CreateInstance()
	{
		return (UI_ActTabs)(object)UIPackage.CreateObject("GameActivity", "ActTabs");
	}

	public static UI_ActTabs CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActTabs).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6n44141", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		backController = ((GComponent)this).GetController("backController");
		Status = ((GComponent)this).GetController("Status");
		TipFormat = ((GComponent)this).GetController("TipFormat");
		Type = ((GComponent)this).GetController("Type");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://29q48tv6n44141".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://29q48tv6n44141".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		newLogo = (GImage)((GComponent)this).GetChild("newLogo");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		timeLimit = (GImage)((GComponent)this).GetChild("timeLimit");
		cornerMark = (GGroup)((GComponent)this).GetChild("cornerMark");
	}
}
