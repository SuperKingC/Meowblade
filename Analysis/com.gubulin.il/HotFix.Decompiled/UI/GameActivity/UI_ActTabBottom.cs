using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_ActTabBottom : GButton
{
	public Controller button;

	public Controller backController;

	public Controller Status;

	public Controller TipFormat;

	public GImage n6;

	public GImage n7;

	public GTextField title;

	public GImage note;

	public GImage newLogo;

	public GTextField tip;

	public GImage n12;

	public const string URL = "ui://29q48tv6oa38n";

	public static string Name = "UI_ActTabBottom";

	public static string GetURL()
	{
		return "ui://29q48tv6oa38n";
	}

	public static UI_ActTabBottom CreateInstance()
	{
		return (UI_ActTabBottom)(object)UIPackage.CreateObject("GameActivity", "ActTabBottom");
	}

	public static UI_ActTabBottom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActTabBottom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6oa38n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		backController = ((GComponent)this).GetController("backController");
		Status = ((GComponent)this).GetController("Status");
		TipFormat = ((GComponent)this).GetController("TipFormat");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://29q48tv6oa38n".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
		newLogo = (GImage)((GComponent)this).GetChild("newLogo");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://29q48tv6oa38n".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
