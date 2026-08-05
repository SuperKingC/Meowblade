using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_EnterGVG : GButton
{
	public Controller button;

	public GImage n7;

	public GTextField title;

	public const string URL = "ui://kozswd8hrz06f2g";

	public static string Name = "UI_EnterGVG";

	public static string GetURL()
	{
		return "ui://kozswd8hrz06f2g";
	}

	public static UI_EnterGVG CreateInstance()
	{
		return (UI_EnterGVG)(object)UIPackage.CreateObject("SpecialActivity", "EnterGVG");
	}

	public static UI_EnterGVG CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnterGVG).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hrz06f2g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kozswd8hrz06f2g".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
