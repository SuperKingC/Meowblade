using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_DetailCom : GComponent
{
	public GRichTextField detail;

	public const string URL = "ui://edr57v33uynq2k";

	public static string Name = "UI_DetailCom";

	public static string GetURL()
	{
		return "ui://edr57v33uynq2k";
	}

	public static UI_DetailCom CreateInstance()
	{
		return (UI_DetailCom)(object)UIPackage.CreateObject("Mail", "DetailCom");
	}

	public static UI_DetailCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DetailCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33uynq2k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		detail = (GRichTextField)((GComponent)this).GetChild("detail");
	}
}
