using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_delete : GButton
{
	public Controller button;

	public GImage n4;

	public GLoader n8;

	public const string URL = "ui://edr57v33oipir";

	public static string Name = "UI_delete";

	public static string GetURL()
	{
		return "ui://edr57v33oipir";
	}

	public static UI_delete CreateInstance()
	{
		return (UI_delete)(object)UIPackage.CreateObject("Mail", "delete");
	}

	public static UI_delete CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_delete).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipir", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GLoader)((GComponent)this).GetChild("n8");
	}
}
