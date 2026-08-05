using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_Announcements : GComponent
{
	public GRichTextField tip;

	public const string URL = "ui://k19peou7h9n16p7x";

	public static string Name = "UI_com_Announcements";

	public static string GetURL()
	{
		return "ui://k19peou7h9n16p7x";
	}

	public static UI_com_Announcements CreateInstance()
	{
		return (UI_com_Announcements)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_Announcements");
	}

	public static UI_com_Announcements CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Announcements).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7h9n16p7x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		tip = (GRichTextField)((GComponent)this).GetChild("tip");
	}
}
