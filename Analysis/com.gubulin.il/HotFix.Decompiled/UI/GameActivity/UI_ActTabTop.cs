using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_ActTabTop : GButton
{
	public Controller button;

	public Controller backController;

	public Controller Status;

	public Controller TipFormat;

	public GImage n3;

	public GImage n4;

	public GTextField title;

	public GImage note;

	public GImage newLogo;

	public GTextField tip;

	public GImage n9;

	public GImage n10;

	public const string URL = "ui://29q48tv6oa38m";

	public static string Name = "UI_ActTabTop";

	public static string GetURL()
	{
		return "ui://29q48tv6oa38m";
	}

	public static UI_ActTabTop CreateInstance()
	{
		return (UI_ActTabTop)(object)UIPackage.CreateObject("GameActivity", "ActTabTop");
	}

	public static UI_ActTabTop CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActTabTop).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6oa38m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		backController = ((GComponent)this).GetController("backController");
		Status = ((GComponent)this).GetController("Status");
		TipFormat = ((GComponent)this).GetController("TipFormat");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://29q48tv6oa38m".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
		newLogo = (GImage)((GComponent)this).GetChild("newLogo");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://29q48tv6oa38m".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
