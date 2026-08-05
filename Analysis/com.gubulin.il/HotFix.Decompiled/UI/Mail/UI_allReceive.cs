using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_allReceive : GButton
{
	public Controller button;

	public GImage n5;

	public GLoader icon;

	public const string URL = "ui://edr57v33oipi6";

	public static string Name = "UI_allReceive";

	public static string GetURL()
	{
		return "ui://edr57v33oipi6";
	}

	public static UI_allReceive CreateInstance()
	{
		return (UI_allReceive)(object)UIPackage.CreateObject("Mail", "allReceive");
	}

	public static UI_allReceive CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_allReceive).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipi6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
