using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_CloseAnnouncements : GButton
{
	public Controller button;

	public GImage n7;

	public const string URL = "ui://k19peou7h9n16p7y";

	public static string Name = "UI_btn_CloseAnnouncements";

	public static string GetURL()
	{
		return "ui://k19peou7h9n16p7y";
	}

	public static UI_btn_CloseAnnouncements CreateInstance()
	{
		return (UI_btn_CloseAnnouncements)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_CloseAnnouncements");
	}

	public static UI_btn_CloseAnnouncements CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CloseAnnouncements).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7h9n16p7y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
