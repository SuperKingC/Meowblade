using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_receive : GButton
{
	public Controller button;

	public GImage n4;

	public GLoader n7;

	public const string URL = "ui://edr57v33oipia";

	public static string Name = "UI_receive";

	public static string GetURL()
	{
		return "ui://edr57v33oipia";
	}

	public static UI_receive CreateInstance()
	{
		return (UI_receive)(object)UIPackage.CreateObject("Mail", "receive");
	}

	public static UI_receive CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_receive).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipia", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n7 = (GLoader)((GComponent)this).GetChild("n7");
	}
}
