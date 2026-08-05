using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftBag;

public class UI_HelpDialog : GComponent
{
	public GImage back;

	public GTextField n6;

	public GTextField n2;

	public GTextField n4;

	public GTextField n5;

	public GTextField n14;

	public GImage n15;

	public const string URL = "ui://4fqsd8h6toms1c";

	public static string Name = "UI_HelpDialog";

	public static string GetURL()
	{
		return "ui://4fqsd8h6toms1c";
	}

	public static UI_HelpDialog CreateInstance()
	{
		return (UI_HelpDialog)(object)UIPackage.CreateObject("GiftBag", "HelpDialog");
	}

	public static UI_HelpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6toms1c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://4fqsd8h6toms1c".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://4fqsd8h6toms1c".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id3 = "ui://4fqsd8h6toms1c".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id3);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id4 = "ui://4fqsd8h6toms1c".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id4);
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id5 = "ui://4fqsd8h6toms1c".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id5);
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}
}
