using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_MailBoxContent : GComponent
{
	public GGraph n4;

	public GGraph SpineBack;

	public const string URL = "ui://j611zmymgyg0v43f";

	public static string Name = "UI_MailBoxContent";

	public static string GetURL()
	{
		return "ui://j611zmymgyg0v43f";
	}

	public static UI_MailBoxContent CreateInstance()
	{
		return (UI_MailBoxContent)(object)UIPackage.CreateObject("MainCity", "MailBoxContent");
	}

	public static UI_MailBoxContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MailBoxContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymgyg0v43f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
	}
}
