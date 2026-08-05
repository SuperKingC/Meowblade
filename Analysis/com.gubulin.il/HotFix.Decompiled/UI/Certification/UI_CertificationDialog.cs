using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_CertificationDialog : GComponent
{
	public Controller Type;

	public GImage back;

	public GImage n8;

	public GImage n9;

	public GTextField content;

	public UI_GoToConfirmBtn certification;

	public UI_ExperienceBar experience;

	public GButton exitBtn;

	public UI_exchangeBtn CustomerServiceBtn;

	public const string URL = "ui://56q48tcqm13tk";

	public static string Name = "UI_CertificationDialog";

	public static string GetURL()
	{
		return "ui://56q48tcqm13tk";
	}

	public static UI_CertificationDialog CreateInstance()
	{
		return (UI_CertificationDialog)(object)UIPackage.CreateObject("Certification", "CertificationDialog");
	}

	public static UI_CertificationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		content = (GTextField)((GComponent)this).GetChild("content");
		string id = "ui://56q48tcqm13tk".Replace("ui://", "") + "-" + ((GObject)content).id;
		((GObject)content).text = LanguagesManager.GetDesc(id);
		certification = (UI_GoToConfirmBtn)(object)((GComponent)this).GetChild("certification");
		experience = (UI_ExperienceBar)(object)((GComponent)this).GetChild("experience");
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		CustomerServiceBtn = (UI_exchangeBtn)(object)((GComponent)this).GetChild("CustomerServiceBtn");
	}

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://56q48tcqm13tk".Replace("ui://", ""), ((GObject)content).id, Type.selectedIndex);
		((GObject)content).text = LanguagesManager.GetDesc(id);
	}
}
