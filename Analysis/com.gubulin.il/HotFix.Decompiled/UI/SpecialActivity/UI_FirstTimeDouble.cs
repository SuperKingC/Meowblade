using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_FirstTimeDouble : GButton
{
	public Controller button;

	public Controller Stauts;

	public GImage back;

	public GTextField title;

	public GTextField time;

	public const string URL = "ui://kozswd8hndja6";

	public static string Name = "UI_FirstTimeDouble";

	public static string GetURL()
	{
		return "ui://kozswd8hndja6";
	}

	public static UI_FirstTimeDouble CreateInstance()
	{
		return (UI_FirstTimeDouble)(object)UIPackage.CreateObject("SpecialActivity", "FirstTimeDouble");
	}

	public static UI_FirstTimeDouble CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FirstTimeDouble).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndja6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Stauts = ((GComponent)this).GetController("Stauts");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kozswd8hndja6".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		time = (GTextField)((GComponent)this).GetChild("time");
		string id2 = "ui://kozswd8hndja6".Replace("ui://", "") + "-" + ((GObject)time).id;
		((GObject)time).text = LanguagesManager.GetDesc(id2);
	}
}
