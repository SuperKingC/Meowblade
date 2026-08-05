using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_HelpDialog : GComponent
{
	public GImage back;

	public GTextField n6;

	public GTextField n11;

	public GTextField n12;

	public const string URL = "ui://29q48tv6h95m2m";

	public static string Name = "UI_HelpDialog";

	public static string GetURL()
	{
		return "ui://29q48tv6h95m2m";
	}

	public static UI_HelpDialog CreateInstance()
	{
		return (UI_HelpDialog)(object)UIPackage.CreateObject("GameActivity", "HelpDialog");
	}

	public static UI_HelpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6h95m2m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://29q48tv6h95m2m".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id2 = "ui://29q48tv6h95m2m".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id2);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id3 = "ui://29q48tv6h95m2m".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id3);
	}
}
