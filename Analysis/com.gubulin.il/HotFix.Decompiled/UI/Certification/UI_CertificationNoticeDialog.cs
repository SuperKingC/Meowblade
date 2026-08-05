using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_CertificationNoticeDialog : GComponent
{
	public GImage back;

	public GTextField title;

	public GTextField content;

	public UI_certificationBtn confirmBtn;

	public const string URL = "ui://56q48tcqm13tc";

	public static string Name = "UI_CertificationNoticeDialog";

	public static string GetURL()
	{
		return "ui://56q48tcqm13tc";
	}

	public static UI_CertificationNoticeDialog CreateInstance()
	{
		return (UI_CertificationNoticeDialog)(object)UIPackage.CreateObject("Certification", "CertificationNoticeDialog");
	}

	public static UI_CertificationNoticeDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationNoticeDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://56q48tcqm13tc".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		content = (GTextField)((GComponent)this).GetChild("content");
		string id2 = "ui://56q48tcqm13tc".Replace("ui://", "") + "-" + ((GObject)content).id;
		((GObject)content).text = LanguagesManager.GetDesc(id2);
		confirmBtn = (UI_certificationBtn)(object)((GComponent)this).GetChild("confirmBtn");
	}
}
