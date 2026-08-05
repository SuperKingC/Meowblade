using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_remove : GButton
{
	public Controller button;

	public GImage background;

	public GImage n4;

	public const string URL = "ui://edr57v33oipi8";

	public static string Name = "UI_remove";

	public static string GetURL()
	{
		return "ui://edr57v33oipi8";
	}

	public static UI_remove CreateInstance()
	{
		return (UI_remove)(object)UIPackage.CreateObject("Mail", "remove");
	}

	public static UI_remove CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_remove).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipi8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
