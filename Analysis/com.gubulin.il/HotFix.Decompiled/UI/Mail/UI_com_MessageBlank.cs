using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_com_MessageBlank : GComponent
{
	public GGraph bg;

	public const string URL = "ui://edr57v33in0546";

	public static string Name = "UI_com_MessageBlank";

	public static string GetURL()
	{
		return "ui://edr57v33in0546";
	}

	public static UI_com_MessageBlank CreateInstance()
	{
		return (UI_com_MessageBlank)(object)UIPackage.CreateObject("Mail", "com_MessageBlank");
	}

	public static UI_com_MessageBlank CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MessageBlank).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33in0546", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		bg = (GGraph)((GComponent)this).GetChild("bg");
	}
}
