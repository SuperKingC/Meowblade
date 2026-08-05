using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_CertificationTipDialog : GComponent
{
	public GImage back;

	public GTextField title;

	public GTextField content;

	public UI_goToCertificationBtn goToCertificationBtn;

	public const string URL = "ui://56q48tcqjbid5";

	public static string Name = "UI_CertificationTipDialog";

	public static string GetURL()
	{
		return "ui://56q48tcqjbid5";
	}

	public static UI_CertificationTipDialog CreateInstance()
	{
		return (UI_CertificationTipDialog)(object)UIPackage.CreateObject("Certification", "CertificationTipDialog");
	}

	public static UI_CertificationTipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationTipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://56q48tcqjbid5".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		content = (GTextField)((GComponent)this).GetChild("content");
		string id2 = "ui://56q48tcqjbid5".Replace("ui://", "") + "-" + ((GObject)content).id;
		((GObject)content).text = LanguagesManager.GetDesc(id2);
		goToCertificationBtn = (UI_goToCertificationBtn)(object)((GComponent)this).GetChild("goToCertificationBtn");
	}
}
