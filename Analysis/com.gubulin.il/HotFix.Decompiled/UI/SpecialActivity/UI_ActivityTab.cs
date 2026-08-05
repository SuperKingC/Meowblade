using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_ActivityTab : GButton
{
	public Controller button;

	public GImage n4;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://kozswd8hndjad";

	public static string Name = "UI_ActivityTab";

	public static string GetURL()
	{
		return "ui://kozswd8hndjad";
	}

	public static UI_ActivityTab CreateInstance()
	{
		return (UI_ActivityTab)(object)UIPackage.CreateObject("SpecialActivity", "ActivityTab");
	}

	public static UI_ActivityTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActivityTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndjad", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kozswd8hndjad".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
