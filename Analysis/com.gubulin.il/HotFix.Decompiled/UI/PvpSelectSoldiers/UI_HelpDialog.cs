using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_HelpDialog : GComponent
{
	public GImage back;

	public GRichTextField n14;

	public GTextField n15;

	public UI_btn_01 goToBtn;

	public const string URL = "ui://82mo10n5jp4vdnz";

	public static string Name = "UI_HelpDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5jp4vdnz";
	}

	public static UI_HelpDialog CreateInstance()
	{
		return (UI_HelpDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "HelpDialog");
	}

	public static UI_HelpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5jp4vdnz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n14 = (GRichTextField)((GComponent)this).GetChild("n14");
		string id = "ui://82mo10n5jp4vdnz".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id2 = "ui://82mo10n5jp4vdnz".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id2);
		goToBtn = (UI_btn_01)(object)((GComponent)this).GetChild("goToBtn");
	}
}
