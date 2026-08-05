using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_Copy : GButton
{
	public Controller button;

	public GImage n3;

	public GGraph n4;

	public GImage n6;

	public const string URL = "ui://edr57v3311ja64g";

	public static string Name = "UI_Copy";

	public static string GetURL()
	{
		return "ui://edr57v3311ja64g";
	}

	public static UI_Copy CreateInstance()
	{
		return (UI_Copy)(object)UIPackage.CreateObject("Mail", "Copy");
	}

	public static UI_Copy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Copy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v3311ja64g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
